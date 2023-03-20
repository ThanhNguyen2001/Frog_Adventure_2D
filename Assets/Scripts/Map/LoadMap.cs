using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMap : MonoBehaviour
{
    [SerializeField] List<GameObject> enemy;
    [SerializeField] List<GameObject> trap;
    [SerializeField] List<GameObject> item;
    void Update()
    {
        this.CheckList(enemy);
        this.CheckList(trap);     
        this.CheckList(item);
    }

    void CheckList(List<GameObject> list)
    {
        Vector3 posLoad = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        foreach (GameObject obj in list)
        {
            if (obj.transform.position.x >= posLoad.x + 4f || obj.transform.position.x <= posLoad.x - 22f)
                obj.gameObject.SetActive(false);
            else
                obj.gameObject.SetActive(true);          
        }
    }
}
