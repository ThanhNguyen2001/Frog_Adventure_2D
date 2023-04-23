using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] BulletPool bulletPool;
    [SerializeField] Transform shootPos;
    void Shoot()
    {
        GameObject bullet = bulletPool.GetBullet();
        bullet.SetActive(true);
        bullet.transform.position = shootPos.position;
        bullet.transform.rotation = shootPos.transform.rotation;
    }
}
