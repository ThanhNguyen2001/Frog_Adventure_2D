using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BGTranslate : MonoBehaviour
{
    void Update()
    {
        Vector3 pos = this.transform.position;
        pos.x -= 0.01f;
        pos.y -= 0.01f;
        this.transform.position = pos;  
    }
}
