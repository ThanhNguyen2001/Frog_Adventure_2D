using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider2D;
    [SerializeField] Animator animator;
    [SerializeField] bool isCollected;

    private void Start()
    {
        this.animator = this.GetComponent<Animator>();
        this.boxCollider2D = this.GetComponent<BoxCollider2D>();

        StartCoroutine(waitCollected());
    }

    private void Update()
    {
        this.animator.SetBool("IsCollected", isCollected);
        
           
    }

    IEnumerator waitCollected()
    {
        yield return new WaitUntil(()=> this.isCollected);
        this.animator.SetBool("IsCollected", isCollected);
        StartCoroutine(waitForCollect());
    }

    public void setCollectItem(bool isCollected)
    {
        this.isCollected = isCollected;
    }

    IEnumerator waitForCollect()
    {
        yield return new WaitForSeconds(0.3f);
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            boxCollider2D.enabled = false;
            isCollected = true;
        }
            
    }
}
