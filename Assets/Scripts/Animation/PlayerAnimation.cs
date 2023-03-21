using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] AnimationCtrl animationCtrl;
    public AnimationCtrl AnimationCtrl { get => animationCtrl; }

    [SerializeField] Animator animator;
    public Animator Animator { get => animator; }

    [SerializeField] AnimationCtrl.AnimationState stateAnim = AnimationCtrl.AnimationState.Idle;
    public AnimationCtrl.AnimationState StateAnim { get => stateAnim; }

    private void Start()
    {
        this.animator = GameObject.Find("Model").GetComponent<Animator>();
        this.animationCtrl = GameObject.Find("AnimatorCtrl").GetComponent<AnimationCtrl>();
    }

    private void Update()
    {
        animationCtrl.GetAnimation(stateAnim, animator);
    }

    public void setStateAnim(AnimationCtrl.AnimationState stateAnim)
    {
        this.stateAnim = stateAnim;
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
