using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broken : MonoBehaviour
{
    [SerializeField] Rigidbody2D body;

    private void Start()
    {
        float random = Random.Range(2f, 3f);
        this.body.velocity = new Vector2(random, this.body.velocity.y);    
    }
}
