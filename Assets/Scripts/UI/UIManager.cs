using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Singleton
    static UIManager instance;
    public static UIManager Instance { get => instance; }

    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(this.gameObject);
            Debug.LogWarning("Other " + this.gameObject.name + " has been deleted !");
        }
    }
    #endregion

    [SerializeField] GameObject levelCompleteUI, gameOverUI, pauseUI, heartUI, starUI;
    public GameObject LevelCompleteUI { get => levelCompleteUI; }
    public GameObject GameOverUI { get => gameOverUI; }
    public GameObject HeartUI { get => heartUI; }
    public GameObject StarUI { get => starUI; }
    public GameObject PauseUI { get => pauseUI; }


}
