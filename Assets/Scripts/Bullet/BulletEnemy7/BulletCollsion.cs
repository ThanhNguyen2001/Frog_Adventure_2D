using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollsion : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerController.Instance.PlayerRD.Deduct();
            this.gameObject.SetActive(false);
        }

        if(collision.gameObject.CompareTag("Ground"))
            this.gameObject.SetActive(false);
    }
}
