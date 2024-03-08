using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class to_idle : StateMachineBehaviour
{
    player_setting witch;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    // override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
        
    // }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        witch = GameObject.FindGameObjectWithTag("player").GetComponent<player_setting>();
        witch.after_attack();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    // override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
    //     witch = GameObject.FindGameObjectWithTag("player").GetComponent<player_setting>();
    //     witch.after_attack();
    // }

}
