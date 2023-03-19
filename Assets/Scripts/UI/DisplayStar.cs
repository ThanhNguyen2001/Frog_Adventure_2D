using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayStar : MonoBehaviour
{
    [SerializeField] int starCollected;
    [SerializeField] GameObject starLevel; 
    void Start()
    {
        this.starCollected = PlayerPrefs.GetInt(starLevel.gameObject.name);
    }

    private void Update()
    {
        this.GetStar();
    }

    void GetStar()
    {
        this.transform.GetChild(starCollected).gameObject.SetActive(true);
    }
}
