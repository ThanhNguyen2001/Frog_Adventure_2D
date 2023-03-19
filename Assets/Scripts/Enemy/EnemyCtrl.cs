using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    [SerializeField] EnemyMoving enemyMoving;
    [SerializeField] public bool isGrounded;

    public EnemyMoving EnemyMoving { get => enemyMoving;}

    [SerializeField] EnemyCollision enemyCollision;

    public EnemyCollision EnemyCollision { get => enemyCollision; }

    public EnemyAnimation1 animation1;

    public EnemyAnimation2 animation2;

    public EnemyAnimation3 animation3;

    //[SerializeField] AnimationCtrl.EnemyAnimationState stateAnim = AnimationCtrl.EnemyAnimationState.Idle;

    //[SerializeField] AnimationCtrl animationCtrl;

    //[SerializeField] Animator animator;

    //private void Update()
    //{
    //    animationCtrl.GetEnemyAnimation(stateAnim, animator);
    //}

    //public void SetAnim(AnimationCtrl.EnemyAnimationState stateAnim)
    //{
    //    this.stateAnim = stateAnim;
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            this.isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            this.isGrounded = false;
        }
    }
}
