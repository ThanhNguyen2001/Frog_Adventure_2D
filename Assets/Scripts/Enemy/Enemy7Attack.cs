using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy7Attack : MonoBehaviour
{
    [SerializeField] EnemyCtrl enemyCtrl;
    [SerializeField] float distance;
    private void Update()
    {
        SetAnim();
    }

    void SetAnim()
    {
        if (enemyCtrl.EnemyCollision.Dying) enemyCtrl.EnemyAnimation6.SetAnim(AnimationCtrl.EnemyAnimationState5.IsHitted);
        else
        {
            if (Vector2.Distance(GameManager.Instance.Player.transform.position, this.transform.parent.position) < distance)
                enemyCtrl.EnemyAnimation6.SetAnim(AnimationCtrl.EnemyAnimationState5.Attack);
            else
                enemyCtrl.EnemyAnimation6.SetAnim(AnimationCtrl.EnemyAnimationState5.Idle);
        }
    }
}
