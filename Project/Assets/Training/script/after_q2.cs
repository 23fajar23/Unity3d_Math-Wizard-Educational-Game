using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class after_q2 : StateMachineBehaviour
{

    Training training;
    screen_black screen_controll;

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        training = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<Training>();
        screen_controll = GameObject.FindGameObjectWithTag("bg_black").GetComponent<screen_black>();
        screen_controll.open();
        training.next_train();
    }

}
