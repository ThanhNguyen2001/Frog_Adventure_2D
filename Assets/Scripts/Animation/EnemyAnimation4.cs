using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation4 : MonoBehaviour
{
    [SerializeField] AnimationCtrl.EnemyAnimationState3 stateAnim = AnimationCtrl.EnemyAnimationState3.Idle;
    [SerializeField] Animator animator;

    private void Update()
    {
        GameManager.Instance.AnimationCtrl.GetEnemyAnimation3(stateAnim, animator);
    }

    public void SetAnim(AnimationCtrl.EnemyAnimationState3 stateAnim)
    {
        this.stateAnim = stateAnim;
    }
}
