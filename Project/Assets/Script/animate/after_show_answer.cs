using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class after_show_answer : StateMachineBehaviour
{
    Story1 story1;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        story1 = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<Story1>();
        story1.enable_skip();
        story1.enable_hint();
        story1.enable_menu();
        story1.enable_essay();


        story1.switch_color("a",false);
        story1.switch_color("b",false);
        story1.switch_color("c",false);
        story1.switch_color("d",false);
    }

}
