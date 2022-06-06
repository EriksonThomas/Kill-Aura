using UnityEngine;

public class attack_anim_logic : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("attacking", true);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("attacking", false);
        animator.ResetTrigger("up_attack_trigger");
        animator.ResetTrigger("front_attack_trigger");
        animator.ResetTrigger("down_attack_trigger");
    }

}
