using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation6 : MonoBehaviour
{
    [SerializeField] AnimationCtrl.EnemyAnimationState5 stateAnim = AnimationCtrl.EnemyAnimationState5.Idle;
    [SerializeField] Animator animator;

    private void Update()
    {
        GameManager.Instance.AnimationCtrl.GetEnemyAnimation5(stateAnim, animator);
    }

    public void SetAnim(AnimationCtrl.EnemyAnimationState5 stateAnim)
    {
        this.stateAnim = stateAnim;
    }
}
