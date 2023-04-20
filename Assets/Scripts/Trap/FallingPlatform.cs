using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float timeCount, timeLimit;
    [SerializeField] float speed;
    [SerializeField] bool isHit;

    public bool IsHit => isHit;
    private void Update()
    {
        if(isHit)
        {
            timeCount += Time.deltaTime;
            if (timeCount < timeLimit) return;
            this.transform.position += new Vector3(0f, -speed) * Time.deltaTime;
            this.animator.SetBool("On", false);
        }
        else
        {
            this.animator.SetBool("On", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            isHit = true;
    }
}
