using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] GameObject windowCompleted;

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
            PlayerController.Instance.PlayerAnimation.setStateAnim(AnimationCtrl.AnimationState.IsHitted);
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
            AudioCtrl.Instance.PlaySound(AudioCtrl.Instance.AudioCollisionTrap);
        }

        if (collision.gameObject.CompareTag("Abyss"))
        {
            AudioCtrl.Instance.PlaySound(AudioCtrl.Instance.AudioCollisionTrap);
            PlayerController.Instance.PlayerRD.SetHp(0);
        }
        if (collision.gameObject.CompareTag("Complete"))
        {
            PlayerController.Instance.PlayerMove.SetMoveForce(0f);
            AudioCtrl.Instance.PlaySound(AudioCtrl.Instance.AudioLevelComplete);
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
            AudioCtrl.Instance.PlaySound(AudioCtrl.Instance.AudioCollectHeart);
            PlayerController.Instance.PlayerRD.Add();
        }

        if (collision.gameObject.CompareTag("Item"))
        {
            PlayerController.Instance.starCtrl.count++;
            //collisionItem = true;
            AudioCtrl.Instance.PlaySound(AudioCtrl.Instance.AudioCollectItem);
        }
    }

    //public void SetCollisionItem(bool collisionItem)
    //{
    //    this.collisionItem = collisionItem;
    //}

    IEnumerator waitForWin()
    {
        yield return new WaitUntil(() => !AudioCtrl.Instance.AudioLevelComplete.isPlaying);
        windowCompleted.SetActive(true);
        Invoke("Pause", 0.25f);
    }

    void Pause()
    {
        Time.timeScale = 0f;
    }
}
