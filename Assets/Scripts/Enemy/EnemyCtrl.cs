using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    [SerializeField] public bool isGrounded;

    [SerializeField] Rigidbody2D body;
    [SerializeField] Animator animator;
    [SerializeField] EnemyCollision enemyCollision;

    public Rigidbody2D Body { get => body; }
    public Animator Animator { get => animator; }
    public EnemyCollision EnemyCollision { get => enemyCollision; }

    private void Start()
    {
        enemyCollision = this.GetComponent<EnemyCollision>();
        body = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponentInChildren<Animator>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            this.isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            this.isGrounded = false;
        }
    }
}
