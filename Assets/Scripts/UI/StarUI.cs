using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarUI : MonoBehaviour
{
    [SerializeField] int starCollected;
    void Start()
    {
        this.starCollected = PlayerPrefs.GetInt("StarCount");
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
