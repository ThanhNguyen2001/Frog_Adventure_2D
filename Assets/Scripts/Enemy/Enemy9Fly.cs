using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy9Fly : MonoBehaviour
{
    [SerializeField] EnemyCtrl enemyCtrl;
    [SerializeField] EnemyAnimation8 enemyAnimation8;
    [SerializeField] Transform point1, point2;
    [SerializeField] Vector3 target = Vector3.zero;
    [SerializeField] float moveForce, moveUp;
    [SerializeField] bool facingRight = true;

    private void Start()
    {
        target = point2.position;
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

        enemyCtrl.Body.velocity = new Vector2(moveForce, 0f) * dir;
        UpDown();   

        this.SetAnim();
        this.Flip();
    }

    void UpDown()
    {
        this.transform.parent.position += new Vector3(0f, moveUp) * Time.deltaTime;
        if(this.transform.parent.position.y - this.transform.parent.transform.parent.position.y > 0.2f)
            moveUp = -2;
        if (this.transform.parent.position.y - this.transform.parent.transform.parent.position.y < -0.2f)
            moveUp = 2;
    }

    void CheckDistance(Transform point1, Transform point2)
    {
        if (enemyCtrl.EnemyCollision.Dying)
        {
            moveForce = 0;
            return;
        }
        if (Mathf.Abs(target.x - this.transform.parent.position.x) <= 0.5f)
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
        if (enemyCtrl.EnemyCollision.Dying) 
            enemyAnimation8.SetAnim(AnimationCtrl.EnemyAnimationState7.IsHitted);
        else
            enemyAnimation8.SetAnim(AnimationCtrl.EnemyAnimationState7.Fly);

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
