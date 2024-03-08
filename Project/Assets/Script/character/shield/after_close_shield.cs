using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class after_close_shield : StateMachineBehaviour
{
    shield_from_top shield;

    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       shield = GameObject.FindGameObjectWithTag("shield_zombie").GetComponent<shield_from_top>();
       shield.after_close();
    }

}
