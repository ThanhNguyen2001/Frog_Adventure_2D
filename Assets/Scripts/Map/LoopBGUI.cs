using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBGUI : MonoBehaviour
{
    [SerializeField] Texture texture;
    [SerializeField] int pixelPerUnit;
    float imageWidth;
    void Start()
    {
        texture = this.GetComponent<SpriteRenderer>().sprite.texture;
        imageWidth = texture.width / pixelPerUnit;
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(Camera.main.transform.position.x - this.transform.position.x) >= imageWidth)
        {
            Vector3 imagePos = this.transform.position;

            imagePos.x = Camera.main.transform.position.x;
            imagePos.y = Camera.main.transform.position.y;

            this.transform.position = imagePos;
        }
    }
}
