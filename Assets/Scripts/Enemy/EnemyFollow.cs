using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] EnemyCtrl enemyCtrl;
    [SerializeField] EnemyAnimation4 enemyAnimation4;
    [SerializeField] Rigidbody2D body;
    [SerializeField] Vector3 dir, posOld;
    [SerializeField] float moveForce, moveForceCurrent;
    [SerializeField] bool facingRight = true;

    private void Start()
    {
        posOld = this.transform.position;
        moveForceCurrent = moveForce;
    }

    private void Update()
    {
        this.Moving();
        this.Flip();
        this.SetAnim();
    }

    void Moving()
    {
        if (enemyCtrl.EnemyCollision.Dying)
        {
            enemyCtrl.Body.velocity = new Vector2(0f, 0f);
            return;
        }

        if ((GameManager.Instance.Player.transform.position.y - posOld.y > -5.5f) && (GameManager.Instance.Player.transform.position.y - posOld.y < 0) &&
            (GameManager.Instance.Player.transform.position.x - posOld.x > -5.5f) && (GameManager.Instance.Player.transform.position.x - posOld.x < 5.5f))
        {
            dir = GameManager.Instance.Player.transform.position - this.transform.position;
            moveForce = moveForceCurrent;
        }
        else
        {
            dir = posOld - this.transform.position;
            if (Vector2.Distance(this.transform.position, posOld) <= 0.1f)
                moveForce = 0;
            else
                moveForce = moveForceCurrent;
        }

        dir.Normalize();
        enemyCtrl.Body.velocity = dir * moveForce;      
    }

    void SetAnim()
    {

        if (enemyCtrl.EnemyCollision.Dying) enemyAnimation4.SetAnim(AnimationCtrl.EnemyAnimationState3.IsHitted);
        else
        {
            if (enemyCtrl.Body.velocity.x != 0 || enemyCtrl.Body.velocity.y != 0)
                enemyAnimation4.SetAnim(AnimationCtrl.EnemyAnimationState3.Flying);
            else
                enemyAnimation4.SetAnim(AnimationCtrl.EnemyAnimationState3.Idle);
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
