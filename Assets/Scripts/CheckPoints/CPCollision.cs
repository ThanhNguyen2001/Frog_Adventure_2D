using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPCollision : MonoBehaviour
{
    [Header("CheckPoint Info")]
    [SerializeField] Animator CPAnimator;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            this.CPAnimator.SetBool("Moving", true);
            this.CPAnimator.SetBool("Idle", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            this.CPAnimator.SetBool("Moving", false);
            this.CPAnimator.SetBool("Idle", true);
        }
    }
}
