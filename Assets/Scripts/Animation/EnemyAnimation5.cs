using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation5 : MonoBehaviour
{
    [SerializeField] AnimationCtrl.EnemyAnimationState4 stateAnim = AnimationCtrl.EnemyAnimationState4.Idle;
    [SerializeField] Animator animator;

    private void Update()
    {
        GameManager.Instance.AnimationCtrl.GetEnemyAnimation4(stateAnim, animator);
    }

    public void SetAnim(AnimationCtrl.EnemyAnimationState4 stateAnim)
    {
        this.stateAnim = stateAnim;
    }
}
