using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoving : MonoBehaviour
{
    [SerializeField] Rigidbody2D body;
    [SerializeField] Transform point1, point2;
    [SerializeField] Vector3 target = Vector3.zero;
    [SerializeField] float moveForce;

    private void Start()
    {
        this.body = this.transform.parent.GetComponent<Rigidbody2D>();
        target = point2.position;
    }
    private void Update()
    {
        this.Moving();
    }
    
    void Moving()
    {
        CheckDistance(point2, point1);
        CheckDistance(point1, point2);

        Vector3 dir = target - this.transform.position;
        dir.Normalize();

        Vector3 pos = this.transform.parent.position;
        pos += dir * moveForce * Time.deltaTime;
        this.transform.parent.position = pos;
    }

    void CheckDistance(Transform pointD, Transform pointR)
    {
        if (Vector3.Distance(pointD.position, this.transform.position) <= 0.5f)
            target = pointR.position;
    }    
}
