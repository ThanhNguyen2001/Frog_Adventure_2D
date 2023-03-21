using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyRun : MonoBehaviour
{
    [SerializeField] EnemyCtrl enemyCtrl;
    [SerializeField] EnemyAnimation2 enemyAnimation2;
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
        target = point2.position;
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

        if (Vector2.Distance(GameManager.Instance.Player.transform.position, this.transform.parent.position) <= 7f)
        {
            timeLimit = 0;
            moveForce = moveForceCurrent + 5f;
        }
        else
        {
            timeLimit = timeLimitOld;
            moveForce = moveForceCurrent;
        }
        
        if (Vector2.Distance(target, this.transform.parent.position) <= 0.5f)
        {
            moveForce = 0;
            timeCount += Time.deltaTime;
            if (timeCount < timeLimit) return;
            timeCount = 0;
            if (target == point2.position)
                target = point1.position;
            else if (target == point1.position)
                target = point2.position;
        }
    }

    public void SetMoveForce(float moveForce)
    {
        this.moveForce = moveForce;
    }

    void SetAnim()
    {
        if(enemyCtrl.EnemyCollision.Dying) enemyAnimation2.SetAnim(AnimationCtrl.EnemyAnimationState1.IsHitted);
        else
        {
            if (Vector2.Distance(GameManager.Instance.Player.transform.position, this.transform.parent.position) <= 5f)
                enemyAnimation2.SetAnim(AnimationCtrl.EnemyAnimationState1.Run);
            else
            {
                if (this.body.velocity.x != 0)
                    enemyAnimation2.SetAnim(AnimationCtrl.EnemyAnimationState1.Moving);
                else
                    enemyAnimation2.SetAnim(AnimationCtrl.EnemyAnimationState1.Idle);
            }
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
