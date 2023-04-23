using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] List<GameObject> bullets;

    public GameObject GetBullet()
    {
        foreach(GameObject b in bullets)
        {
            if (b.gameObject.activeSelf)
                continue;
            return b;
        }

        GameObject g = Instantiate(bullet, this.transform.position, Quaternion.identity, this.transform);
        bullets.Add(g);
        g.SetActive(false);

        return g;
    }
}
