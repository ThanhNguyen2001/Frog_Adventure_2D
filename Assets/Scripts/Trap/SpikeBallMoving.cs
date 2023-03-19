using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBallMoving : MonoBehaviour
{
    [SerializeField] float speed;
    private void Update()
    {
        Quaternion rotate = this.transform.rotation;
        rotate.eulerAngles = new Vector3(0,0,rotate.eulerAngles.z + speed);
        this.transform.rotation = rotate;   
    }
}
