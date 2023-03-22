using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [SerializeField] AudioSource music, sound;
    [SerializeField] Slider musicSlider, soundSlider;

    private void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("Music");
        soundSlider.value = PlayerPrefs.GetFloat("Sound");
    }

    public void ChangeMusic()
    {
        music.volume = musicSlider.value;
        PlayerPrefs.SetFloat("Music", musicSlider.value);     
    }

    public void ChangeSound()
    {
        sound.volume = soundSlider.value;
        PlayerPrefs.SetFloat("Sound", soundSlider.value);
    }


}
