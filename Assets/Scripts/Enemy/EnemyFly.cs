using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyFly : MonoBehaviour
{
    [SerializeField] EnemyCtrl enemyCtrl;
    [SerializeField] Rigidbody2D body;
    [SerializeField] Animator animator;
    [SerializeField] Transform point1, point2;
    [SerializeField] Vector3 target = Vector3.zero;
    [SerializeField] float moveForce, moveForceCurrent;
    [SerializeField] bool facingRight = true;
    [SerializeField] float timeCount, timeLimit, timeLimitOld;

    private void Start()
    {
        body = transform.parent.GetComponent<Rigidbody2D>();
        target = point1.position;
      
        moveForceCurrent = moveForce;
        timeLimitOld = timeLimit;
    }

    private void Update()
    {
       
        this.Moving();
    }

    void Moving()
    {
        CheckDistance(point1, point2);
        Vector3 dir = target - this.transform.parent.position;
        dir.Normalize();

        this.body.velocity = dir * moveForce;

        this.SetAnim();
        this.Flip();
    }

    void CheckDistance(Transform point1, Transform point2)
    {
        if(enemyCtrl.EnemyCollision.Dying)
        {
            moveForce = 0;
            return;
        }

        moveForce = moveForceCurrent;
        if ((GameManager.Instance.Player.transform.position.x - this.transform.parent.position.x > -2f && 
            GameManager.Instance.Player.transform.position.x - this.transform.parent.position.x < 0.5f && 
            PlayerController.Instance.PlayerMove.FacingRight) 
            || (GameManager.Instance.Player.transform.position.x - this.transform.parent.position.x < 2f &&
            GameManager.Instance.Player.transform.position.x - this.transform.parent.position.x > -0.5f &&
            !PlayerController.Instance.PlayerMove.FacingRight))
        {
            target = point2.position;
        }
        if (Vector2.Distance(target, this.transform.parent.position) <= 0.5f)
        {
            moveForce = 0;
            timeCount += Time.deltaTime;
            if (timeCount < timeLimit) return;
            timeCount = 0;
            target = point1.position;
        }
       
    }

    public void SetMoveForce(float moveForce)
    {
        this.moveForce = moveForce;
    }

    void SetAnim()
    {
        if(enemyCtrl.EnemyCollision.Dying) enemyCtrl.animation3.SetAnim(AnimationCtrl.EnemyAnimationState2.IsHitted);
        else
        {
            if (this.body.velocity.y >= 0)
            {
                if (this.target == point2.position)
                    enemyCtrl.animation3.SetAnim(AnimationCtrl.EnemyAnimationState2.Ground);
                else
                    enemyCtrl.animation3.SetAnim(AnimationCtrl.EnemyAnimationState2.Idle);
            }
            else
                enemyCtrl.animation3.SetAnim(AnimationCtrl.EnemyAnimationState2.Fall);
        }
        
    }

    void Flip()
    {
        if (this.body.velocity.x > 0 && !facingRight)
            this.FipX();
        else if(this.body.velocity.x < 0 && facingRight)
            this.FipX();
    }

    void FipX()
    {
        facingRight = !facingRight;
        this.transform.parent.Rotate(0, 180, 0);
    }   
}
