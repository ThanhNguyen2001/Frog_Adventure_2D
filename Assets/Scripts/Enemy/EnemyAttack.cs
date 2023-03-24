using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] EnemyCtrl enemyCtrl;
    [SerializeField] EnemyAnimation5 enemyAnimation5;
    [SerializeField] Rigidbody2D body;
    [SerializeField] Animator animator;
    [SerializeField] Vector3 dir;
    [SerializeField] float moveForce, moveForceCurrent;
    [SerializeField] bool facingRight = true;
    [SerializeField] float timeCount, timeLimit, timeLimitOld;
    [SerializeField] Transform player;

    [SerializeField] float wallCheckDistance;
    [SerializeField] LayerMask layerMask;
    [SerializeField] bool isWallDetected;
    [SerializeField] float facingDir = 1;
    [SerializeField] float moveY;
    private void Update()
    {
        this.WallCheck();
        this.Moving();
        this.SetAnim();
    }

    void Moving()
    {
        if((player.position.y - this.transform.position.y > -0.5f) && (player.position.y - this.transform.position.y < 2f) &&
            Mathf.Abs(player.position.x - this.transform.position.x) < 7f )
        {
            moveForce += moveForceCurrent;
            if (moveForce >= 10)
                moveForce = 10;
            this.body.velocity = new Vector2(moveForce * transform.right.x, this.body.velocity.y);
        }   
    }

    void SetAnim()
    {
        
        if (enemyCtrl.EnemyCollision.Dying) enemyAnimation5.SetAnim(AnimationCtrl.EnemyAnimationState4.IsHitted);
        else
        {
            Debug.Log("ok");
            if (this.body.velocity.x != 0)
                enemyAnimation5.SetAnim(AnimationCtrl.EnemyAnimationState4.Run);
            else
                enemyAnimation5.SetAnim(AnimationCtrl.EnemyAnimationState4.Idle);
        }

    }

    void Flip()
    {
        if (this.body.velocity.x > 0 && !facingRight)
            this.FlipX();
        else if (this.body.velocity.x < 0 && facingRight)
            this.FlipX();
    }

    void FlipX()
    {
        facingDir = -facingDir;
        facingRight = !facingRight;
        this.transform.parent.Rotate(0, 180, 0);
    }

    void WallCheck()
    {
        isWallDetected = Physics2D.Raycast(transform.position, Vector2.right, wallCheckDistance * facingDir, layerMask);
        if (isWallDetected)
        {
            this.body.AddForce(new Vector2(0, moveY), ForceMode2D.Impulse);
            moveForce = 0;
            FlipX();
        }
            
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + wallCheckDistance * facingDir, transform.position.y));
    }
}
