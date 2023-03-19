using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCtrl : MonoBehaviour
{
    public void GetAnimation(AnimationState anim, Animator animator)
    {
        for (int i = 0; i <= (int)AnimationState.Fall; i++)
        {
            string animName = ((AnimationState)i).ToString();
            if(animName == anim.ToString())
            {
                animator.SetBool(animName, true);  
                continue;
            }
            animator.SetBool(animName, false);
        }
    }

    public enum AnimationState
    {
        DoubleJump,
        Desappear,
        IsHitted,
        WallSlide,
        Idle,
        Moving,
        Jump,
        Fall
    }


    public void GetEnemyAnimation(EnemyAnimationState anim, Animator animator)
    {
        for (int i = 0; i <= (int)EnemyAnimationState.IsHitted; i++)
        {
            string animName = ((EnemyAnimationState)i).ToString();
            if (animName == anim.ToString())
            {
                animator.SetBool(animName, true);
                continue;
            }
            animator.SetBool(animName, false);
        }
    }

    public enum EnemyAnimationState
    {
        Idle,
        Moving,
        IsHitted
    }

    public void GetEnemyAnimation1(EnemyAnimationState1 anim, Animator animator)
    {
        for (int i = 0; i <= (int)EnemyAnimationState1.IsHitted; i++)
        {
            string animName = ((EnemyAnimationState1)i).ToString();
            if (animName == anim.ToString())
            {
                animator.SetBool(animName, true);
                continue;
            }
            animator.SetBool(animName, false);
        }
    }

    public enum EnemyAnimationState1
    {
        Angry,
        Run,
        Idle,
        Moving,
        IsHitted
    }

    public void GetEnemyAnimation2(EnemyAnimationState2 anim, Animator animator)
    {
        for (int i = 0; i <= (int)EnemyAnimationState2.IsHitted; i++)
        {
            string animName = ((EnemyAnimationState2)i).ToString();
            if (animName == anim.ToString())
            {
                animator.SetBool(animName, true);
                continue;
            }
            animator.SetBool(animName, false);
        }
    }

    public enum EnemyAnimationState2
    {
        Fall,
        Ground,
        Idle,
        IsHitted
    }
}
