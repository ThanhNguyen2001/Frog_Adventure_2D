using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHeadMoving : MonoBehaviour
{
    [SerializeField] Rigidbody2D body;
    [SerializeField] Animator animator;
    [SerializeField] Transform point1, point2;
    [SerializeField] Vector3 target = Vector3.zero;
    [SerializeField] float moveForce;
    [SerializeField] float timeCount, timeLimit;

    private void Start()
    {
        this.animator = this.GetComponent<Animator>();
        this.body = this.GetComponent<Rigidbody2D>();
        target = point2.position;
    }
    private void Update()
    {
        this.Moving();
        this.SetAnim();
    }
    
    void Moving()
    {
        CheckDistance(point2, point1);
        CheckDistance(point1, point2);

        Vector3 dir = target - this.transform.position;
        dir.Normalize();

        this.body.velocity = dir * moveForce;
    }

    void CheckDistance(Transform pointD, Transform pointR)
    {
        if (Vector3.Distance(pointD.position, this.transform.position) <= 0.5f)
            target = pointR.position;
    }
    
    void SetAnim()
    {
        this.IdleAnim();
        timeCount += Time.deltaTime;
        if (timeCount < timeLimit) return;
        timeCount = 0;
        this.MovingAnim();
    }

    void MovingAnim()
    {
        animator.SetBool("Moving", true);
        animator.SetBool("Idle", false);
    }

    void IdleAnim()
    {
        animator.SetBool("Moving", false);
        animator.SetBool("Idle", true);
    }
}
