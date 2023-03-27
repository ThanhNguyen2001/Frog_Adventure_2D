using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAudio : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    private void Awake()
    {
        this.audioSource = this.GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        StartCoroutine(waitSoundDone());
    }

    IEnumerator waitSoundDone()
    {
        yield return new WaitUntil(() => !audioSource.isPlaying);
        this.gameObject.SetActive(false);
        
    }
}
