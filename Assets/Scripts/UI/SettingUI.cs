using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [SerializeField] AudioSource audios;
    [SerializeField] List<AudioSource> soundEffect;
    [SerializeField] Slider musicSlider, soundSlider;

    private void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("Music");
        soundSlider.value = PlayerPrefs.GetFloat("Sound");
    }

    public void ChangeMusic()
    {
        audios.volume = musicSlider.value;
        PlayerPrefs.SetFloat("Music", audios.volume);     
    }

    public void ChangeSound()
    {
        foreach (AudioSource sound in soundEffect)
        {
            sound.volume = soundSlider.value;
            PlayerPrefs.SetFloat("Sound", sound.volume);
        }
    }


}
