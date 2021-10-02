using UnityEngine;

public class ResetIsInteracting : StateMachineBehaviour
{

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isInteracting", false);
        animator.applyRootMotion = false;
    }


}
