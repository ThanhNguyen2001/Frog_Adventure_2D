using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation1 : MonoBehaviour
{
    [SerializeField] AnimationCtrl.EnemyAnimationState stateAnim = AnimationCtrl.EnemyAnimationState.Idle;
    [SerializeField] Animator animator;
    [SerializeField] AnimationCtrl animationCtrl;

    private void Update()
    {
        animationCtrl.GetEnemyAnimation(stateAnim, animator);
    }

    public void SetAnim(AnimationCtrl.EnemyAnimationState stateAnim)
    {
        this.stateAnim = stateAnim;
    }
}
