using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation8 : MonoBehaviour
{
    [SerializeField] AnimationCtrl.EnemyAnimationState7 stateAnim = AnimationCtrl.EnemyAnimationState7.Fly;
    [SerializeField] Animator animator;

    private void Update()
    {
        GameManager.Instance.AnimationCtrl.GetEnemyAnimation7(stateAnim, animator);
    }

    public void SetAnim(AnimationCtrl.EnemyAnimationState7 stateAnim)
    {
        this.stateAnim = stateAnim;
    }
}
