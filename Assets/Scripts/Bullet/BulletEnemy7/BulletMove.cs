using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D body;
    [SerializeField] float speed;

    private void Update()
    {
        body.velocity = -this.transform.parent.right *  new Vector2(speed, 0);
    }
}
