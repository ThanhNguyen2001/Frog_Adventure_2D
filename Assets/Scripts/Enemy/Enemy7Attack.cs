using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy7Attack : MonoBehaviour
{
    [SerializeField] EnemyCtrl enemyCtrl;
    [SerializeField] EnemyAnimation6 enemyAnimation6;   
    [SerializeField] float distance;
    private void Update()
    {
        SetAnim();
    }

    void SetAnim()
    {
        if (enemyCtrl.EnemyCollision.Dying) enemyAnimation6.SetAnim(AnimationCtrl.EnemyAnimationState5.IsHitted);
        else
        {
            if (Vector2.Distance(GameManager.Instance.Player.transform.position, this.transform.parent.position) < distance)
                enemyAnimation6.SetAnim(AnimationCtrl.EnemyAnimationState5.Attack);
            else
                enemyAnimation6.SetAnim(AnimationCtrl.EnemyAnimationState5.Idle);
        }
    }
}
