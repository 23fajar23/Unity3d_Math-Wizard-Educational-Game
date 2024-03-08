using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class after_explode : StateMachineBehaviour
{
    fireball_ghost fireball;
    Story1 story1;

    // override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
    //     story1 = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<Story1>();
    //     string tag_fireball = "fireball" + story1.question_last;
    //     fireball = GameObject.FindGameObjectWithTag(tag_fireball).GetComponent<fireball_ghost>();
    //     fireball.true_finish();
    // }

    // override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
        
    // }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        story1 = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<Story1>();
        string tag_fireball = "fireball" + story1.question_last;
        fireball = GameObject.FindGameObjectWithTag(tag_fireball).GetComponent<fireball_ghost>();
        fireball.true_finish();
        fireball.idle();
    }


}
