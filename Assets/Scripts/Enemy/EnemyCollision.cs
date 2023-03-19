using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] ParticleSystem _particleSystem;
    [SerializeField] EnemyCtrl enemyCtrl;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource audioDie, audioAttack, audioPartical;
    [SerializeField] Rigidbody2D body;
    [SerializeField] Collider2D collider2;
    [SerializeField] Vector2 dir = Vector2.zero;
    [SerializeField] bool dying;

    public bool Dying { get => dying; }

    private void OnCollisionEnter2D(Collision2D collision)
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
                    if (PlayerController.Instance.PlayerMove.Body.velocity.y > 0) return;
                    PlayerController.Instance.PlayerMove.Body.AddForce(new Vector2(0, 400f));
                    audioDie.Play();
                    this.collider2.enabled = false;
                    StartCoroutine(WaitSoundDone());
                }
                else
                {
                    audioAttack.Play();
                    PlayerController.Instance.setStateAnim(AnimationCtrl.AnimationState.IsHitted);
                    PlayerController.Instance.PlayerRD.Deduct();
                }
            }
            else
            {
                audioAttack.Play();
                PlayerController.Instance.setStateAnim(AnimationCtrl.AnimationState.IsHitted);
                PlayerController.Instance.PlayerRD.Deduct();
            }
        }
    }
    IEnumerator WaitSoundDone()
    {
        yield return new WaitUntil(() => !audioDie.isPlaying);
        spriteRenderer.sortingLayerID = 0;
        _particleSystem.gameObject.SetActive(true);
        audioPartical.Play();
        //Invoke("SetAlive", 0.6f);
    }

    void SetAlive()
    {
        spriteRenderer.sprite = null;
    }
}
