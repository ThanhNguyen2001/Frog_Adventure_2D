using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] GameObject windowCompleted;
    [SerializeField] AudioSource audioCollectItem, audioCollisionTrap, audioCollectHeart, audioComplete;

    [Header("Trap Info")]
    [SerializeField] bool collisionTrap;
    //[SerializeField] bool collisionItem;

    //public bool CollisionItem { get => collisionItem;}

    private void Update()
    {
        this.CollisionTrap();
    }

    void CollisionTrap()
    {
        if (collisionTrap)
        {
            PlayerController.Instance.setStateAnim(AnimationCtrl.AnimationState.IsHitted);
            collisionTrap = false;
            PlayerController.Instance.PlayerRD.Deduct();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("MovingPlatform"))
        {
            this.transform.SetParent(collision.gameObject.transform);
        }

        if (collision.gameObject.CompareTag("Trap"))
        {
            collisionTrap = true;
            audioCollisionTrap.Play();
        }

        if (collision.gameObject.CompareTag("Abyss"))
        {
            audioCollisionTrap.Play();
            PlayerController.Instance.PlayerRD.SetHp(0);
        }
        if (collision.gameObject.CompareTag("Complete"))
        {
            PlayerController.Instance.PlayerMove.SetMoveForce(0f);
            audioComplete.gameObject.SetActive(true);
            StartCoroutine(waitForWin());
        }
            
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            this.transform.SetParent(null);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Heart"))
        {
            audioCollectHeart.Play();
            PlayerController.Instance.PlayerRD.Add();
        }

        if (collision.gameObject.CompareTag("Item"))
        {
            PlayerController.Instance.starCtrl.count++; 
            //collisionItem = true;
            audioCollectItem.Play();
        }
    }

    //public void SetCollisionItem(bool collisionItem)
    //{
    //    this.collisionItem = collisionItem;
    //}

    IEnumerator waitForWin()
    {
        yield return new WaitUntil(() => !audioComplete.isPlaying);
        windowCompleted.SetActive(true);
        Invoke("Pause", 0.25f);
    }

    void Pause()
    {
        Time.timeScale = 0f;
    }
}
