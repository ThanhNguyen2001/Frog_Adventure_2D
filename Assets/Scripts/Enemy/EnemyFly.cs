using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyFly : MonoBehaviour
{
    [SerializeField] EnemyCtrl enemyCtrl;
    [SerializeField] EnemyAnimation3 enemyAnimation3;
    [SerializeField] Rigidbody2D body;
    [SerializeField] Transform point1, point2;
    [SerializeField] Vector3 target = Vector3.zero;
    [SerializeField] float moveForce, moveForceCurrent;
    [SerializeField] float timeCount, timeLimit;

    private void Start()
    {
        target = point1.position;
      
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

        enemyCtrl.Body.velocity = dir * moveForce;

        this.SetAnim();;
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
        if(enemyCtrl.EnemyCollision.Dying) enemyAnimation3.SetAnim(AnimationCtrl.EnemyAnimationState2.IsHitted);
        else
        {
            if (enemyCtrl.Body.velocity.y >= 0)
            {
                if (this.target == point2.position)
                    enemyAnimation3.SetAnim(AnimationCtrl.EnemyAnimationState2.Ground);
                else
                    enemyAnimation3.SetAnim(AnimationCtrl.EnemyAnimationState2.Idle);
            }
            else
                enemyAnimation3.SetAnim(AnimationCtrl.EnemyAnimationState2.Fall);
        }
        
    }  
}
