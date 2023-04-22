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
    [SerializeField] Transform point1, point2;
    [SerializeField] Vector3 target = Vector3.zero;
    [SerializeField] float moveForce, moveForceCurrent;
    [SerializeField] bool facingRight = true;
    [SerializeField] float timeCount, timeLimit, timeLimitOld;

    private void Start()
    {
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

        enemyCtrl.Body.velocity = new Vector2(moveForce, 0f) * dir;

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

        if ((GameManager.Instance.Player.transform.position.y - this.transform.parent.transform.parent.position.y > -1f) && (GameManager.Instance.Player.transform.position.y - this.transform.parent.transform.parent.position.y < 3.5f) &&
            Mathf.Abs(GameManager.Instance.Player.transform.position.x - this.transform.parent.transform.parent.position.x) < 5f)
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
            if ((GameManager.Instance.Player.transform.position.y - this.transform.parent.transform.parent.position.y > -1f) && (GameManager.Instance.Player.transform.position.y - this.transform.parent.transform.parent.position.y < 3.5f) &&
            Mathf.Abs(GameManager.Instance.Player.transform.position.x - this.transform.parent.transform.parent.position.x) < 5f)
                enemyAnimation2.SetAnim(AnimationCtrl.EnemyAnimationState1.Run);
            else
            {
                if (enemyCtrl.Body.velocity.x != 0)
                    enemyAnimation2.SetAnim(AnimationCtrl.EnemyAnimationState1.Moving);
                else
                    enemyAnimation2.SetAnim(AnimationCtrl.EnemyAnimationState1.Idle);
            }
        }
        
    }

    void Flip()
    {
        if (enemyCtrl.Body.velocity.x > 0 && !facingRight)
            this.FipX();
        else if(enemyCtrl.Body.velocity.x < 0 && facingRight)
            this.FipX();
    }

    void FipX()
    {
        facingRight = !facingRight;
        this.transform.parent.Rotate(0, 180, 0);
    }   
}
