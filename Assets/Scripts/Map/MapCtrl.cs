using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCtrl : MonoBehaviour
{
    static MapCtrl instance;
    public static MapCtrl Instance { get => instance; }

    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(this.gameObject);
            Debug.LogWarning("Another MapCtrl has been deleted !");
        }
    }

    public CollectItem collectItem;
}
