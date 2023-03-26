using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer spriteRenderer;
    [SerializeField] protected ParticleSystem _particleSystem;
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected Animator animator;

    [SerializeField] protected Rigidbody2D body;
    [SerializeField] protected Collider2D collider2;
    [SerializeField] protected Vector2 dir = Vector2.zero;
    [SerializeField] protected bool dying;

    public bool Dying { get => dying; }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dir = collision.transform.position - this.transform.position;
            dir = dir.normalized;

            if (Mathf.Abs(dir.x) < Mathf.Abs(dir.y))
            {
                if(collision.transform.position.y > this.transform.position.y)
                {
                    dying = true;
                    PlayerController.Instance.PlayerMove.Body.AddForce(new Vector2(0, 400f));
                    AudioCtrl.Instance.GetAudioPool(AudioCtrl.Instance.AudioEnemyHit, AudioCtrl.Instance.AudioEnemyHits);
                    this.collider2.enabled = false;
                    StartCoroutine(WaitSoundDone());
                }
                else
                {
                    AudioCtrl.Instance.GetAudioPool(AudioCtrl.Instance.AudioCollisionTrap, AudioCtrl.Instance.AudioCollisionTraps);
                    PlayerController.Instance.PlayerAnimation.setStateAnim(AnimationCtrl.AnimationState.IsHitted);
                    PlayerController.Instance.PlayerRD.Deduct();
                }
            }
            else
            {
                AudioCtrl.Instance.GetAudioPool(AudioCtrl.Instance.AudioCollisionTrap, AudioCtrl.Instance.AudioCollisionTraps);
                PlayerController.Instance.PlayerAnimation.setStateAnim(AnimationCtrl.AnimationState.IsHitted);
                PlayerController.Instance.PlayerRD.Deduct();
            }
        }
    }
    protected IEnumerator WaitSoundDone()
    {
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.sortingLayerID = 0;
        _particleSystem.gameObject.SetActive(true);
        AudioCtrl.Instance.GetAudioPool(AudioCtrl.Instance.AudioEnemyDie, AudioCtrl.Instance.AudioEnemyDies);
        //Invoke("SetAlive", 0.6f);
    }

    void SetAlive()
    {
        spriteRenderer.sprite = null;
    }
}
