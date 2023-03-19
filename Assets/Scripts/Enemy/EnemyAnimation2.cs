using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation2 : MonoBehaviour
{
    [SerializeField] AnimationCtrl.EnemyAnimationState1 stateAnim = AnimationCtrl.EnemyAnimationState1.Idle;
    [SerializeField] Animator animator;
    [SerializeField] AnimationCtrl animationCtrl;

    private void Update()
    {
        animationCtrl.GetEnemyAnimation1(stateAnim, animator);
    }

    public void SetAnim(AnimationCtrl.EnemyAnimationState1 stateAnim)
    {
        this.stateAnim = stateAnim;
    }
}
