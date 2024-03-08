using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class connect_player : StateMachineBehaviour
{
    Story1 story1;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        story1 = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<Story1>();
        story1.destroy_question();
        story1.answer_change();
    }
}
