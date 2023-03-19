using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRD : MonoBehaviour
{
    [SerializeField] AudioSource audioGameOver;
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody2D body;
    [SerializeField] GameObject heartUI, windowGameOver;
    [SerializeField] int hp, maxHp;
    [SerializeField] bool isDeducted, isAdded;
    [SerializeField] List<GameObject> pools;
    private void Update()
    {
        if(isAdded)
        {
            isAdded = false;
            if (pools.Count <= 0) return;
            pools[pools.Count - 1].gameObject.SetActive(true);
            pools.Remove(pools[pools.Count - 1]);
        }

        if(isDeducted && this.hp >= 0)
        {
            isDeducted = false;
            heartUI.transform.GetChild(hp).gameObject.SetActive(false);
            pools.Add(heartUI.transform.GetChild(hp).gameObject);
        }
        this.Die();
    }

    private void Start()
    {
        this.maxHp = this.hp;
    }
    public void Deduct()
    {
        this.isDeducted = true;
        this.hp --;
        if(this.hp < 0) this.hp = 0;
    }

    public void Add()
    {
        this.isAdded = true;
        this.hp ++;
        if (this.hp > this.maxHp) this.hp = this.maxHp;
    }

    public void Die()
    {
        if (hp <= 0)
        {
            this.body.simulated = false;
            audioGameOver.gameObject.SetActive(true);
            PlayerController.Instance.setStateAnim(AnimationCtrl.AnimationState.Desappear);
            StartCoroutine(waitForDie());
        }      
    }
    
    public void SetHp(int hp)
    {
        this.hp = hp;
    }

    IEnumerator waitForDie()
    {
        yield return new WaitUntil(() => !audioGameOver.isPlaying);
        this.transform.parent.gameObject.SetActive(false);
        windowGameOver.SetActive(true);
        Invoke("Pause", 0.25f);
    }
    
    void Pause()
    {
        Time.timeScale = 0f;
    }
}
