using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    [SerializeField] GameObject windowPause;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(windowPause.activeSelf)
            {
                windowPause.SetActive(false);
                Time.timeScale = 1f;
            }                  
            else
            {
                windowPause.SetActive(true);
                Invoke("Pause", 0.25f);
            }    
        }
    }

    void Pause()
    {
        Time.timeScale = 0f;
    }
}
