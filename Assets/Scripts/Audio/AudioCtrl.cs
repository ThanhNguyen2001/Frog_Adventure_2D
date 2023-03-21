using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCtrl : MonoBehaviour
{
    #region Singleton
    private static AudioCtrl instance;
    public static AudioCtrl Instance { get => instance; }

    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Debug.LogWarning("Another '" + this.gameObject.name + "' has been deleted");
            Destroy(this.gameObject);
        }
    }
    #endregion
    [SerializeField] AudioSource audioJump, audioCollectItem, audioCollectHeart, 
        audioCollisionTrap, audioGameOver, audioLevelComplete, audioEnemyHit, audioEnemyDie, 
        audioLevel1, audioLevel2, audioLevel3;
    public AudioSource AudioJump { get => audioJump; }
    public AudioSource AudioCollectItem { get => audioCollectItem; }
    public AudioSource AudioCollectHeart { get => audioCollectHeart; }
    public AudioSource AudioCollisionTrap { get => audioCollisionTrap; }
    public AudioSource AudioGameOver { get => audioGameOver; }
    public AudioSource AudioLevelComplete { get => audioLevelComplete; }
    public AudioSource AudioEnemyHit { get => audioEnemyHit; }
    public AudioSource AudioEnemyDie { get => audioEnemyDie; }

    private void Start()
    {
        if (PlayerPrefs.GetInt("LevelCount") == 1)
            audioLevel1.gameObject.SetActive(true);
        else if(PlayerPrefs.GetInt("LevelCount") == 2)
            audioLevel2.gameObject.SetActive(true);
        else
            audioLevel3.gameObject.SetActive(true);
    }

    public void PlaySound(AudioSource audio)
    {
        audio.Play();
    }
}
