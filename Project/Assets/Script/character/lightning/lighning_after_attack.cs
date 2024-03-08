using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lighning_after_attack : StateMachineBehaviour
{
    lightning_setting lightning;

    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        lightning = GameObject.FindGameObjectWithTag("lightning").GetComponent<lightning_setting>();
        lightning.after_attack();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        lightning = GameObject.FindGameObjectWithTag("lightning").GetComponent<lightning_setting>();
        lightning.finish_attack();
    }

}
