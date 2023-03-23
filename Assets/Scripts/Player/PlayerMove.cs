using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] ParticleSystem dust;
    [SerializeField] Rigidbody2D body;
    [SerializeField] float moveForce;
    [SerializeField] float jumpForce;
    [SerializeField] bool facingRight = true;

    [Header("Collision Info")]
    [SerializeField] float groundCheckDistance;
    [SerializeField] float groundCheckRadius;
    [SerializeField] LayerMask whatIsGround, whatIsWall;
    [SerializeField] bool isGrounded;
    [SerializeField] bool canDoubleJump;

    [Header("WallCollision Info")]
    
    [SerializeField] float wallCheckDistance, wallSlideSpeed;
    [SerializeField] bool isWallDetected;
    [SerializeField] bool canWallSlide;
    [SerializeField] bool isWallSliding;

    [Header("WallJump Info")]
    [SerializeField] float facingDirection = 1;
    [SerializeField] Vector2 wallJumpDirection;

    [SerializeField] float timeCount;
    [SerializeField] float timeLimit;
    [SerializeField] bool outOfWall;

    public Rigidbody2D Body { get => body;}
    public bool FacingRight { get => facingRight; }


    private void Start()
    {
        StartCoroutine(waitForStart());
    }
    void Update()
    {
        this.Moving();
        this.JumpController();
        this.CollisionCheck();
        this.FlipController();
        this.StateAnimation();
        this.WallSlideFast();
    }

    void Moving()
    {
        if (isWallDetected) this.canDoubleJump = true;
        if (this.isGrounded) this.canDoubleJump = true;  

        if (canWallSlide)
        {
            this.body.velocity = new Vector2(this.body.velocity.x, this.body.velocity.y * wallSlideSpeed);
            this.isWallSliding = true;
        }

        this.CheckMove();    
    }

    void WallSlideFast()
    {
        if (InputManager.Instance.MovementY < 0)
            canWallSlide = false;
    }

    void CheckMove()
    {
        float movementX = InputManager.Instance.MovementX;
        this.body.velocity = new Vector2(moveForce * movementX, this.body.velocity.y);
        if (InputManager.Instance.MovementX != 0 && isGrounded)
            dust.Play();
    }

    void FlipController()
    {
        if (this.body.velocity.x > 0 && !facingRight)
            this.Flip();
        else if (this.body.velocity.x < 0 && facingRight)
            this.Flip();
        //if (this.body.velocity.x != 0 && isGrounded) dust.gameObject.SetActive(true);
        //else dust.gameObject.SetActive(false);

    }

    void Flip()
    {
        facingDirection = facingDirection * -1;
        this.facingRight = !this.facingRight;
        this.transform.parent.Rotate(0, 180, 0);
    }

    void JumpController()
    {
        if (this.body.velocity.y > 0) this.outOfWall = false;
        if (InputManager.Instance.Jump) this.JumpCheck();
    }

    void JumpCheck()
    {
        if (isWallSliding) this.WallJump();
        else if (isGrounded) this.Jump();
        else if (this.outOfWall && this.body.velocity.y <= 0)
        {
            this.Jump();
            this.outOfWall = false;
        }
        else if (canDoubleJump)
        {
            this.canDoubleJump = false;
            this.Jump();
        }

        canWallSlide = false;
    }

    void Jump()
    {
        dust.Play();
        //this.body.velocity = new Vector2(this.body.velocity.x, 0);    
        //this.body.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        this.body.velocity = new Vector2(this.body.velocity.x, jumpForce);
        //AudioCtrl.Instance.PlaySound(AudioCtrl.Instance.AudioJump);
        AudioCtrl.Instance.GetAudioPool(AudioCtrl.Instance.AudioJump, AudioCtrl.Instance.AudioJumps);
    }

    void WallJump()
    {
        dust.Play();
        this.body.velocity = new Vector2(wallJumpDirection.x * -facingDirection, jumpForce);
        AudioCtrl.Instance.GetAudioPool(AudioCtrl.Instance.AudioJump, AudioCtrl.Instance.AudioJumps);
    }
    void StateAnimation()
    {
        if (PlayerController.Instance.PlayerAnimation.StateAnim == AnimationCtrl.AnimationState.IsHitted)
        {
            timeCount += Time.deltaTime;
            if (timeCount < timeLimit) return;
            timeCount = 0;
        }        

        if (this.body.velocity.x != 0) PlayerController.Instance.PlayerAnimation.MovingAnim();
        else PlayerController.Instance.PlayerAnimation.IdleAnim();

        if (this.body.velocity.y > 0)
        {
            if (canDoubleJump)
                PlayerController.Instance.PlayerAnimation.JumpAnim();
            else
                PlayerController.Instance.PlayerAnimation.DoubleJumpAnim();
        }
        else if (this.body.velocity.y < 0) PlayerController.Instance.PlayerAnimation.FallAnim();

        if (isWallSliding && !isGrounded) PlayerController.Instance.PlayerAnimation.WallSlideAnim();
    }

    public void SetMoveForce(float moveForce)
    {
        this.moveForce = moveForce;
    }

    void CollisionCheck()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
        isWallDetected = Physics2D.Raycast(transform.position, Vector2.right * facingDirection, wallCheckDistance, whatIsWall);

        if (isWallDetected && this.body.velocity.y < 0)
            this.canWallSlide = true;

        if (!isWallDetected)
        {
            this.canWallSlide = false;
            this.isWallSliding = false;
        }

        if (isGrounded || isWallDetected) outOfWall = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + wallCheckDistance * facingDirection, transform.position.y));
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundCheckDistance));
    }

    IEnumerator waitForStart()
    {
        yield return new WaitUntil(() => isGrounded);
        this.moveForce = 5f;
    }
}
