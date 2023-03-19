using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarLevelUI : MonoBehaviour
{
    private void Update()
    {
        PlayerPrefs.SetInt(this.gameObject.name, PlayerController.Instance.starCtrl.starCount);
    }
}
