using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy8Moving : MonoBehaviour
{
    [SerializeField] EnemyCtrl enemyCtrl;
    [SerializeField] EnemyAnimation7 enemyAnimation7;
    [SerializeField] Transform point1, point2;
    [SerializeField] Vector3 target = Vector3.zero;
    [SerializeField] float moveForce, moveForceCurrent;
    [SerializeField] bool facingRight = true;
    [SerializeField] float timeCount, timeLimit;

    public bool FacingRight => facingRight;

    private void Start()
    {
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
   
        timeCount += Time.deltaTime;
        if (timeCount > timeLimit / 2 && timeCount < timeLimit)
        {
            moveForce = 0;
        }

        if (timeCount > timeLimit)
        {
            moveForce = moveForceCurrent;
            timeCount = 0;
        }

        enemyCtrl.Body.velocity = new Vector2(moveForce, 0f) * dir;

        this.SetAnim();
        this.Flip();
    }

    void CheckDistance(Transform point1, Transform point2)
    {
        if (enemyCtrl.EnemyCollision.Dying)
        {
            moveForce = 0;
            return;
        }
        if (Vector2.Distance(target, this.transform.parent.position) <= 0.5f)
        {
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
        if (enemyCtrl.EnemyCollision.Dying) enemyAnimation7.SetAnim(AnimationCtrl.EnemyAnimationState6.IsHitted);
        else
        {
            if (enemyCtrl.Body.velocity.x != 0)
                enemyAnimation7.SetAnim(AnimationCtrl.EnemyAnimationState6.Run);
            else
                enemyAnimation7.SetAnim(AnimationCtrl.EnemyAnimationState6.Attack);
                
        }

    }

    void Flip()
    {
        if (enemyCtrl.Body.velocity.x > 0 && !facingRight)
            this.FipX();
        else if (enemyCtrl.Body.velocity.x < 0 && facingRight)
            this.FipX();
    }

    void FipX()
    {
        facingRight = !facingRight;
        this.transform.parent.Rotate(0, 180, 0);
    }
}
