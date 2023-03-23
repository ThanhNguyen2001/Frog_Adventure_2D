using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMap : MonoBehaviour
{
    [SerializeField] List<GameObject> enemies;
    [SerializeField] List<GameObject> traps;

    private void Update()
    {
        this.CheckDistance(enemies);
        this.CheckDistance(traps);
    }

    void CheckDistance(List<GameObject> objs)
    {
        Vector3 posLoad = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        foreach(GameObject obj in objs)
        {
            if (obj.transform.position.x >= posLoad.x + 4f || obj.transform.position.x <= posLoad.x - 22f)
                obj.gameObject.SetActive(false);
            else
                obj.gameObject.SetActive(true);
        }          
    }
}
 