using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;
    public Animator Animator { get => animator; }

    [SerializeField] AnimationCtrl.AnimationState stateAnim = AnimationCtrl.AnimationState.Idle;
    public AnimationCtrl.AnimationState StateAnim { get => stateAnim; }

    [SerializeField] float timeCount;
    [SerializeField] float timeLimit;

    private void Start()
    {
        this.animator = GameObject.Find("Model").GetComponent<Animator>();
    }

    private void Update()
    {
        GameManager.Instance.AnimationCtrl.GetAnimation(stateAnim, animator);
        this.StateAnimation();
    }

    public void setStateAnim(AnimationCtrl.AnimationState stateAnim)
    {
        this.stateAnim = stateAnim;
    }

    void StateAnimation()
    {
        if (this.StateAnim == AnimationCtrl.AnimationState.IsHitted)
        {
            timeCount += Time.deltaTime;
            if (timeCount < timeLimit) return;
            timeCount = 0;
        }

        if (PlayerController.Instance.PlayerMove.Body.velocity.x != 0) this.MovingAnim();
        else this.IdleAnim();

        if (PlayerController.Instance.PlayerMove.Body.velocity.y > 0)
        {
            if (PlayerController.Instance.PlayerMove.CanDoubleJump)
               this.JumpAnim();
            else
                this.DoubleJumpAnim();
        }
        else if (PlayerController.Instance.PlayerMove.Body.velocity.y < 0 && !PlayerController.Instance.PlayerMove.IsGrounded) this.FallAnim();

        if (PlayerController.Instance.PlayerMove.IsWallSliding && !PlayerController.Instance.PlayerMove.IsGrounded)
            this.WallSlideAnim();
    }


    public void MovingAnim()
    {
       this.setStateAnim(AnimationCtrl.AnimationState.Moving);
    }

    public void IdleAnim()
    {
        this.setStateAnim(AnimationCtrl.AnimationState.Idle);
    }

    public void JumpAnim()
    {
        this.setStateAnim(AnimationCtrl.AnimationState.Jump);
    }

    public void DoubleJumpAnim()
    {
        this.setStateAnim(AnimationCtrl.AnimationState.DoubleJump);
    }

    public void FallAnim()
    {
        this.setStateAnim(AnimationCtrl.AnimationState.Fall);
    }

    public void WallSlideAnim()
    {
        this.setStateAnim(AnimationCtrl.AnimationState.WallSlide);
    }
}
