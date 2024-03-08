using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class after_attack_zap : StateMachineBehaviour
{
    zap_mutant_setting zap;
    Story1 story_1;
    
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        story_1 = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<Story1>();
        string tag_zap = "lightning" + story_1.question_last;
        zap = GameObject.FindGameObjectWithTag(tag_zap).GetComponent<zap_mutant_setting>();
        zap.after_attack();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        story_1 = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<Story1>();
        string tag_zap = "lightning" + story_1.question_last;
        zap = GameObject.FindGameObjectWithTag(tag_zap).GetComponent<zap_mutant_setting>();
        zap.finish_attack();
    }
}
