using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] bool isTurnOn, isExit = false;
    [SerializeField] float distance;
    [SerializeField] LayerMask mask;
    [SerializeField] Animator animator;
    [SerializeField] Collider2D fireHit;
    [SerializeField] float timeCount, timeLimit, timeCount2, timeLimit2;


    private void Update()
    {
        TurnOn();
    }

    void TurnOn()
    {
        isTurnOn = Physics2D.Raycast(this.transform.position, Vector2.up, distance, mask) 
            || Physics2D.Raycast(this.transform.position + new Vector3(0.26f, 0f), Vector2.up, distance, mask)
            || Physics2D.Raycast(this.transform.position + new Vector3(-0.26f, 0f), Vector2.up, distance, mask);
        if(isTurnOn && !isExit)
        {
            timeCount2 = 0;
            animator.SetBool("Hit", true);
            animator.SetBool("Off", false);
            animator.SetBool("On", false);
            timeCount += Time.deltaTime;
            if (timeCount < timeLimit) return;
            AfterHit();
        }
        
        if(!isTurnOn && isExit)
        {
            timeCount2 += Time.deltaTime;
            if (timeCount2 < timeLimit2) return;
            TurnOff();
            timeCount = 0f;
        }
    }

    void AfterHit()
    {
        animator.SetBool("Hit", false);
        animator.SetBool("Off", false);
        animator.SetBool("On", true);
        fireHit.gameObject.SetActive(true);
    }

    void TurnOff()
    {
        animator.SetBool("Hit", false);
        animator.SetBool("Off", true);
        animator.SetBool("On", false);
        fireHit.gameObject.SetActive(false);
        isExit = false;
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(this.transform.position, new Vector2(this.transform.position.x, this.transform.position.y + distance));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            isExit = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            isExit = true;
    }
}
