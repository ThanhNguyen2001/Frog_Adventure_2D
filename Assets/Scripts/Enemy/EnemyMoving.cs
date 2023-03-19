using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMoving : MonoBehaviour
{
    [SerializeField] EnemyCtrl enemyCtrl;
    [SerializeField] Rigidbody2D body;
    [SerializeField] Animator animator;
    [SerializeField] Transform point1, point2;
    [SerializeField] Vector3 target = Vector3.zero;
    [SerializeField] float moveForce, moveForceCurrent;
    [SerializeField] bool facingRight = true;
    [SerializeField] float timeCount, timeLimit;

    private void Start()
    {
        body = transform.parent.GetComponent<Rigidbody2D>();
        target = point2.position;
        moveForceCurrent = moveForce;
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
        if(enemyCtrl.EnemyCollision.Dying) enemyCtrl.animation1.SetAnim(AnimationCtrl.EnemyAnimationState.IsHitted);
        else
        {
            if (this.body.velocity.x != 0)
                enemyCtrl.animation1.SetAnim(AnimationCtrl.EnemyAnimationState.Moving);
            else
                enemyCtrl.animation1.SetAnim(AnimationCtrl.EnemyAnimationState.Idle);
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
