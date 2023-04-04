using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [SerializeField] List<Sprite> itemImages = new List<Sprite>();
    [SerializeField] Text itemCount;

    private void Start()
    {
        this.LoadItemCount();
    }

    private void Update()
    {
        this.LoadItemImage();
        this.LoadItemCount();
    }

    void LoadItemImage()
    {
        if (PlayerPrefs.GetInt("LevelCount") == 1)
            this.transform.GetChild(0).GetComponent<Image>().sprite = itemImages[0];
        else if (PlayerPrefs.GetInt("LevelCount") == 2)
            this.transform.GetChild(0).GetComponent<Image>().sprite = itemImages[1];
        else if (PlayerPrefs.GetInt("LevelCount") == 3)
            this.transform.GetChild(0).GetComponent<Image>().sprite = itemImages[2];
        else if (PlayerPrefs.GetInt("LevelCount") == 4)
            this.transform.GetChild(0).GetComponent<Image>().sprite = itemImages[3];
    }

    void LoadItemCount()
    {
        itemCount.text = MapCtrl.Instance.collectItem.FruitCount.ToString();
    }
}
