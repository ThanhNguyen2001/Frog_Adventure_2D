using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] EnemyCtrl enemyCtrl;
    [SerializeField] EnemyAnimation5 enemyAnimation5;
    [SerializeField] Rigidbody2D body;
    [SerializeField] Animator animator;
    [SerializeField] float moveForce, moveForceCurrent;
    [SerializeField] bool facingRight = true;
    [SerializeField] float timeCount, timeLimit;

    [SerializeField] float wallCheckDistance;
    [SerializeField] LayerMask layerMask;
    [SerializeField] bool isWallDetected;
    [SerializeField] float facingDir = 1;
    [SerializeField] float moveY;
    [SerializeField] bool isHitWall;
    private void Update()
    {
        this.WallCheck();
        this.Moving();
        this.SetAnim();
    }

    void Moving()
    {
        if (enemyCtrl.EnemyCollision.Dying)
        {
            this.body.velocity = new Vector2(0f, 0f);
            return;
        }

        if ((GameManager.Instance.Player.transform.position.y - this.transform.parent.transform.parent.position.y > -1f) && (GameManager.Instance.Player.transform.position.y - this.transform.parent.transform.parent.position.y < 4f) &&
            Mathf.Abs(GameManager.Instance.Player.transform.position.x - this.transform.parent.transform.parent.position.x) < 4f)
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
           
            if (this.body.velocity.x != 0)
                enemyAnimation5.SetAnim(AnimationCtrl.EnemyAnimationState4.Run);           
            else
                enemyAnimation5.SetAnim(AnimationCtrl.EnemyAnimationState4.Idle);

            if(isHitWall)
            {
                enemyAnimation5.SetAnim(AnimationCtrl.EnemyAnimationState4.HitWall);
                timeCount += Time.deltaTime;
                if (timeCount < timeLimit) return;
                timeCount = 0;
                isHitWall = false;
            }
                
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
            this.isHitWall = true;
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
