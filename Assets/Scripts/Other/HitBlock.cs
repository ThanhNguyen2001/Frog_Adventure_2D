using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HitBlock : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Collider2D colli;
    [SerializeField] LayerMask mask;
    [SerializeField] float distance;
    [SerializeField] float timeCount, timeLimit;
    [SerializeField] bool isHitted, isCollsion, isBroken;
    private void Update()
    {
        isHitted = Physics2D.Raycast(this.transform.position, Vector2.up, distance, mask)
        || Physics2D.Raycast(this.transform.position + new Vector3(0.34f, 0f), Vector2.up, distance, mask)
        || Physics2D.Raycast(this.transform.position + new Vector3(-0.34f, 0f), Vector2.up, distance, mask);

        if (isHitted && isCollsion)
        {
            PlayerController.Instance.PlayerMove.Body.velocity = new Vector2(PlayerController.Instance.PlayerMove.Body.velocity.x, 10f);
            animator.SetBool("Hit", true);
            colli.enabled = false;
            isCollsion = false;
            isBroken = true;
            StartCoroutine(waitForBroke());
        }

        if(isBroken)
        {
            timeCount += Time.deltaTime;
            if (timeCount < timeLimit) return;
            Invoke("Disappear", 0.1f);
            Invoke("Appear", 0.2f);
            Invoke("Disappear", 0.3f);
            Invoke("Deactive", 0.4f);
        }
    }

    void Disappear()
    {
        this.transform.GetChild(1).gameObject.SetActive(false);
        this.transform.GetChild(2).gameObject.SetActive(false);
    }

    void Appear()
    {
        this.transform.GetChild(1).gameObject.SetActive(true);
        this.transform.GetChild(2).gameObject.SetActive(true);
    }

    void Deactive()
    {
        this.gameObject.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(this.transform.position, new Vector2(this.transform.position.x, this.transform.position.y + distance));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            isCollsion = true;
    }

    IEnumerator waitForBroke()
    {
        yield return new WaitForSeconds(0.1f);
        this.transform.GetChild(0).gameObject.SetActive(false);
        this.transform.GetChild(1).gameObject.SetActive(true);
        this.transform.GetChild(2).gameObject.SetActive(true);
    }
}
