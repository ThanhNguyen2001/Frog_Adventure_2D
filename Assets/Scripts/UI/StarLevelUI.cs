using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarLevelUI : MonoBehaviour
{
    private void Update()
    {
        PlayerPrefs.SetInt(this.gameObject.name, PlayerController.Instance.starCtrl.starCount);
    }
}
