using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation1 : MonoBehaviour
{
    [SerializeField] AnimationCtrl.EnemyAnimationState stateAnim = AnimationCtrl.EnemyAnimationState.Idle;
    [SerializeField] Animator animator;

    private void Update()
    {
        GameManager.Instance.AnimationCtrl.GetEnemyAnimation(stateAnim, animator);
    }

    public void SetAnim(AnimationCtrl.EnemyAnimationState stateAnim)
    {
        this.stateAnim = stateAnim;
    }
}
