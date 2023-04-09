using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    private void Update()
    {
        if (InputManager.Instance.Pause)
        {
            if (PlayerController.Instance.PlayerCollision.IsCompleted || PlayerController.Instance.PlayerRD.IsGameOver) return;
            if (UIManager.Instance.PauseUI.activeSelf)
            {
                UIManager.Instance.PauseUI.gameObject.SetActive(false);
                Time.timeScale = 1f;
            }                  
            else
            {
                UIManager.Instance.PauseUI.gameObject.SetActive(true);
                Invoke("Pause", 0.25f);
            }    
        }
    }

    void Pause()
    {
        Time.timeScale = 0f;
    }
}
