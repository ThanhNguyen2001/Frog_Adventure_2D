using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    [Header("Trap Info")]
    [SerializeField] bool collisionTrap;
    [SerializeField] bool isCompleted;

    public bool IsCompleted { get => isCompleted;}

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
            AudioCtrl.Instance.GetAudioPool(AudioCtrl.Instance.AudioCollisionTrap, AudioCtrl.Instance.AudioCollisionTraps);
        }

        if (collision.gameObject.CompareTag("Abyss"))
        {
            AudioCtrl.Instance.GetAudioPool(AudioCtrl.Instance.AudioCollisionTrap, AudioCtrl.Instance.AudioCollisionTraps);
            PlayerController.Instance.PlayerRD.SetHp(0);
        }
        if (collision.gameObject.CompareTag("Complete"))
        {
            this.isCompleted = true;
            PlayerController.Instance.PlayerMove.SetMoveForce(0f);
            PlayerController.Instance.PlayerMove.SetJumpForce(0f);
            AudioCtrl.Instance.AudioLevelComplete.gameObject.SetActive(true);
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
            AudioCtrl.Instance.GetAudioPool(AudioCtrl.Instance.AudioCollectHeart, AudioCtrl.Instance.AudioCollectHearts);
            PlayerController.Instance.PlayerRD.Add();
        }

        if (collision.gameObject.CompareTag("Item"))
        {
            PlayerController.Instance.starCtrl.count++;
            MapCtrl.Instance.collectItem.SetFruitCount();
            AudioCtrl.Instance.GetAudioPool(AudioCtrl.Instance.AudioCollectItem, AudioCtrl.Instance.AudioCollectItems);
        }
    }

    IEnumerator waitForWin()
    {
        yield return new WaitUntil(() => !AudioCtrl.Instance.AudioLevelComplete.isPlaying);
        UIManager.Instance.LevelCompleteUI.SetActive(true);
        Invoke("Pause", 0.25f);
    }

    void Pause()
    {
        Time.timeScale = 0f;
    }
}
