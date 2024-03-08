using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class after_attack : StateMachineBehaviour
{
    wolf_setting wolf;
    Story1 story_1;


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        story_1 = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<Story1>();
        
        string tag_slime = "wolf" + story_1.question_last;
        wolf = GameObject.FindGameObjectWithTag(tag_slime).GetComponent<wolf_setting>();
        wolf.after_attack();
    }

}
