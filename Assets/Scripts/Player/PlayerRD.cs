using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRD : MonoBehaviour
{
    [SerializeField] Rigidbody2D body;
    [SerializeField] int hp, maxHp;
    [SerializeField] bool isDeducted, isAdded;
    [SerializeField] bool isGameOver;
    [SerializeField] List<GameObject> pools;

    public bool IsGameOver { get => isGameOver;}

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
            UIManager.Instance.HeartUI.transform.GetChild(hp).gameObject.SetActive(false);
            pools.Add(UIManager.Instance.HeartUI.transform.GetChild(hp).gameObject);
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
            this.isGameOver = true;
            this.body.simulated = false;
            AudioCtrl.Instance.AudioGameOver.gameObject.SetActive(true);
            PlayerController.Instance.PlayerAnimation.setStateAnim(AnimationCtrl.AnimationState.Desappear);
            StartCoroutine(waitForDie());
        }      
    }
    
    public void SetHp(int hp)
    {
        this.hp = hp;
    }

    IEnumerator waitForDie()
    {
        yield return new WaitUntil(() => !AudioCtrl.Instance.AudioGameOver.isPlaying);
        this.transform.parent.gameObject.SetActive(false);
        UIManager.Instance.GameOverUI.SetActive(true);
        Invoke("Pause", 0.25f);
    }
    
    void Pause()
    {
        Time.timeScale = 0f;
    }
}
