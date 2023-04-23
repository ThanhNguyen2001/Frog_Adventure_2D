using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation7 : MonoBehaviour
{
    [SerializeField] AnimationCtrl.EnemyAnimationState6 stateAnim = AnimationCtrl.EnemyAnimationState6.Idle;
    [SerializeField] Animator animator;

    private void Update()
    {
        GameManager.Instance.AnimationCtrl.GetEnemyAnimation6(stateAnim, animator);
    }

    public void SetAnim(AnimationCtrl.EnemyAnimationState6 stateAnim)
    {
        this.stateAnim = stateAnim;
    }
}
