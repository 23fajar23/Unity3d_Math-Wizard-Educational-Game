using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bug_zombie : StateMachineBehaviour
{
    Story1 story_1;

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        story_1 = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<Story1>();
        story_1.reset_true_answer();
        
    }

}
