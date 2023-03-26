using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] float endFollowX;
    [SerializeField] float startFollowY, endFollowY;
    private void Awake()
    {
        if (PlayerPrefs.GetInt("LevelCount") == 1)
        {
            this.endFollowX = 48.55f;
            this.endFollowY = 10f;
        }
            
        else if (PlayerPrefs.GetInt("LevelCount") == 2)
        {
            this.endFollowX = 91f;
            this.endFollowY = 20f;
        }
            
        else if (PlayerPrefs.GetInt("LevelCount") == 3)
        {
            this.endFollowX = 110f;
            this.endFollowY = 2.6f;
            this.startFollowY = -8f;
        }

        else
        {
            this.endFollowX = 97.5f;
            this.endFollowY = 27.31f;      
        }
        


    }
    void Update()
    {
        this.CameraFollowPlayer();
    }

    void CameraFollowPlayer()
    {
        Vector3 cameraPos = this.transform.position;

        if(GameManager.Instance.Player.transform.position.x > 0f && GameManager.Instance.Player.transform.position.x < this.endFollowX)
            cameraPos.x = GameManager.Instance.Player.transform.position.x;

        if (GameManager.Instance.Player.transform.position.y > this.startFollowY && GameManager.Instance.Player.transform.position.y < this.endFollowY)
            cameraPos.y = GameManager.Instance.Player.transform.position.y;

        this.transform.position = cameraPos;
    }
}
