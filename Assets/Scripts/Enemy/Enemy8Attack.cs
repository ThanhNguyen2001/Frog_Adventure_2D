using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy8Attack : MonoBehaviour
{
    [SerializeField] EnemyAnimation7 enemyAnimation7;
    private void Update()
    {
        enemyAnimation7.SetAnim(AnimationCtrl.EnemyAnimationState6.Attack);
    }
}
