using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarCtrl : MonoBehaviour
{
    [SerializeField] public int fruitPerStar, starCount, maxStar = 3, count;
    [SerializeField] GameObject starUI;

    private void Start()
    {
        PlayerPrefs.SetInt("StarCount", 0);
        starUI = GameObject.Find("Stars");
    }

    private void Update()
    {
        this.GetStar();
    }

    void GetStar()
    {
        fruitPerStar = MapCtrl.Instance.collectItem.MaxFruit / maxStar;
        //if (PlayerController.Instance.PlayerCollision.CollisionItem)
        //{
        //    //count++;
        //    PlayerController.Instance.PlayerCollision.SetCollisionItem(false);
        //}
        if (count >= fruitPerStar)
        {
            starUI.transform.GetChild(starCount).gameObject.SetActive(true);
            starCount++;
            PlayerPrefs.SetInt("StarCount", starCount);
            count = 0;
        }
    }
}
