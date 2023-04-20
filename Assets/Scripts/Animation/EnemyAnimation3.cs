using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation3 : MonoBehaviour
{
    [SerializeField] AnimationCtrl.EnemyAnimationState2 stateAnim = AnimationCtrl.EnemyAnimationState2.Idle;
    [SerializeField] Animator animator;

    private void Update()
    {
        GameManager.Instance.AnimationCtrl.GetEnemyAnimation2(stateAnim, animator);
    }

    public void SetAnim(AnimationCtrl.EnemyAnimationState2 stateAnim)
    {
        this.stateAnim = stateAnim;
    }
}
