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
    [SerializeField] Transform audioHolder;

    [SerializeField] 
    AudioSource audioJump, audioCollectItem, audioCollectHeart, 
        audioCollisionTrap, audioGameOver, audioLevelComplete, 
        audioEnemyHit, audioEnemyDie, 
        audioLevel1, audioLevel2, audioLevel3, audioLevel4;
    
    [SerializeField]
    List<AudioSource> audioJumps, audioCollectItems, audioCollectHearts,
        audioEnemyHits, audioEnemyDies, audioCollisionTraps;

    public AudioSource AudioJump { get => audioJump; }
    public AudioSource AudioCollectItem { get => audioCollectItem; }
    public AudioSource AudioCollectHeart { get => audioCollectHeart; }
    public AudioSource AudioCollisionTrap { get => audioCollisionTrap; }
    public AudioSource AudioGameOver { get => audioGameOver; }
    public AudioSource AudioLevelComplete { get => audioLevelComplete; }
    public AudioSource AudioEnemyHit { get => audioEnemyHit; }
    public AudioSource AudioEnemyDie { get => audioEnemyDie; }

    public List<AudioSource> AudioJumps { get => audioJumps; }
    public List<AudioSource> AudioCollectItems { get => audioCollectItems; }
    public List<AudioSource> AudioCollectHearts { get => audioCollectHearts; }
    public List<AudioSource> AudioCollisionTraps { get => audioCollisionTraps; }
    public List<AudioSource> AudioEnemyHits { get => audioEnemyHits; }
    public List<AudioSource> AudioEnemyDies { get => audioEnemyDies; }

    private void Start()
    {
        if (PlayerPrefs.GetInt("LevelCount") == 1)
            audioLevel1.gameObject.SetActive(true);
        else if(PlayerPrefs.GetInt("LevelCount") == 2)
            audioLevel2.gameObject.SetActive(true);
        else if(PlayerPrefs.GetInt("LevelCount") == 3)
            audioLevel3.gameObject.SetActive(true);
        else
            audioLevel4.gameObject.SetActive(true);
    }

    public void PlaySound(AudioSource audio)
    {
        audio.Play();
    }

    public AudioSource GetAudio(AudioSource audio, List<AudioSource> audios)
    {
        foreach (AudioSource audioSource in audios)
        {
            if (audioSource.gameObject.activeSelf)
                continue;
            return audioSource;
        }
        AudioSource a = Instantiate<AudioSource>(audio, this.transform.position, Quaternion.identity, audioHolder);
        a.gameObject.SetActive(false);
        audios.Add(a);
        return a;
    }

    public void GetAudioPool(AudioSource audio, List<AudioSource> audios)
    {
        AudioSource ad = GetAudio(audio, audios);
        ad.transform.position = this.transform.position;
        ad.gameObject.SetActive(true);
    }
}
