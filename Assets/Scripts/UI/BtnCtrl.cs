using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnCtrl : MonoBehaviour
{
    [SerializeField] Animation startScence, endScence;
    [SerializeField] AudioSource audioClick;
    [SerializeField] GameObject resumeWindow, exitWindow;
    [SerializeField] int levelCount;
    [SerializeField] AudioSource music;
    [SerializeField] List<AudioSource> sounds;
    private void Start()
    {
        levelCount = PlayerPrefs.GetInt("LevelCount");
        music.volume = PlayerPrefs.GetFloat("Music");
        foreach (AudioSource sound in sounds)
        {
            sound.volume = PlayerPrefs.GetFloat("Sound");
        }
            
    }

    public void ClickPlay()
    {
        endScence.Play();
        StartCoroutine(waitForPlay());
    }

    public void ClickBack()
    {
        endScence.Play();
        Invoke("LoadScence0", 1);
    }
    public void ClickExit()
    {
        exitWindow.SetActive(true);
    }

    public void ClickYesExit()
    {
        Application.Quit();
    #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
    #endif
    }

    public void ClickNoExit()
    {
        exitWindow.SetActive(false);
    }

    public void ClickRestart()
    {
        endScence.Play();
        Invoke("LoadCurrentScence", 1);
        Time.timeScale = 1f;
    }

    public void ClickResume()
    {      
        resumeWindow.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ClickNext()
    {
        
        if(levelCount < 3)
        {
            levelCount++;
            PlayerPrefs.SetInt("LevelCount", levelCount);
        }             
        else
            PlayerPrefs.SetInt("LevelCount", 3);
        endScence.Play();
        Invoke("LoadNextScence", 1);
        Time.timeScale = 1f;
    }

    public void ClickHome()
    {
        endScence.Play();
        Invoke("LoadScence0", 1);
        Time.timeScale = 1f;
    }
    public void ClickSetting()
    {
        endScence.Play();
        Invoke("LoadScence6", 1);
        Time.timeScale = 1f;
    }

    public void ClickLevel1()
    {
        levelCount = 1;
        PlayerPrefs.SetInt("LevelCount", levelCount);
        endScence.Play();
        Invoke("LoadScenceLV1", 1);
    }

    public void ClickLevel2()
    {
        levelCount = 2;
        PlayerPrefs.SetInt("LevelCount", levelCount);
        endScence.Play();
        Invoke("LoadScence2LV2", 1);
    }

    public void ClickLevel3()
    {
        levelCount = 3;
        PlayerPrefs.SetInt("LevelCount", levelCount);
        endScence.Play();
        Invoke("LoadScence2LV3", 1);
    }

    void LoadCurrentScence()
    {
        SceneManager.LoadScene(2);
        SceneManager.LoadScene(2 + levelCount, LoadSceneMode.Additive);
    }
    void LoadNextScence()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
        SceneManager.LoadScene(currentIndex + levelCount, LoadSceneMode.Additive);
    }
    void LoadScence0()
    {
        SceneManager.LoadScene(0);
    }

    void LoadScence1()
    {
        SceneManager.LoadScene(1);
    }

    void LoadScence6()
    {
        SceneManager.LoadScene(6);
    }
    void LoadScenceLV1()
    {
        SceneManager.LoadScene(2);
        SceneManager.LoadScene(3, LoadSceneMode.Additive);
    }

    void LoadScence2LV2()
    {
        SceneManager.LoadScene(2);
        SceneManager.LoadScene(4, LoadSceneMode.Additive);
    }
    void LoadScence2LV3()
    {
        SceneManager.LoadScene(2);
        SceneManager.LoadScene(5, LoadSceneMode.Additive);
    }
    public void AudioBtnClick()
    {
        audioClick.Play();
    }
    IEnumerator waitForPlay()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }
}
