using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDiadlogBase : DialogBase
{
    [SerializeField]
    private Animator animator = null; 

    //ダイアログ初期化処理
    public override IEnumerator DialogInitialize(DialogData data = null)
    {
        animator.Play("Show");
        yield return null;
        bool animEnd = false;
        while (!animEnd)
        {
            var currentAnimatorState = animator.GetCurrentAnimatorStateInfo(0);
            if (currentAnimatorState.normalizedTime > 1.0f)
            {
                animEnd = true;
            }
            yield return null;
        }
    }
    //ダイアログ終了処理
    public override IEnumerator DialogFinalize(DialogData data = null)
    {
        animator.Play("Hide");
        yield return null;
        bool animEnd = false;
        while (!animEnd)
        {
            var currentAnimatorState = animator.GetCurrentAnimatorStateInfo(0);
            if (currentAnimatorState.normalizedTime > 1.0f)
            {
                animEnd = true;
            }
            yield return null;
        }
    }
}
