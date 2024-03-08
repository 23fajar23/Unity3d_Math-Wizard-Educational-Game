using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flip_slime : StateMachineBehaviour
{
    slime_setting slime_enemy;
    Story1 story_1;

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        story_1 = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<Story1>();
        
        string tag_slime = "slime" + story_1.question_last;
        slime_enemy = GameObject.FindGameObjectWithTag(tag_slime).GetComponent<slime_setting>();
        slime_enemy.after_attack();
    }

}
