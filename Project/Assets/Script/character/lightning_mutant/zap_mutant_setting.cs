using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zap_mutant_setting : MonoBehaviour
{
    public Animator zap;
    public string action_zap = "";
    public bool attack = false;
    public bool finish = false;

    // Update is called once per frame
    void Update()
    {
        if (action_zap == "idle")
        {
            zap.SetBool("attack", false);
            zap.SetBool("back_attack", false);
        }

        if (action_zap == "attack")
        {
            zap.SetBool("attack", true);
        }

        if (action_zap == "back_attack")
        {
            zap.SetBool("back_attack", true);
        }
    }

    public void after_attack()
    {
        attack = true;
    }

    public void finish_attack()
    {
        finish = true;
    }
    
    public void to_attack()
    {
        action_zap = "attack";
    }

    public void to_back_attack()
    {
        action_zap = "back_attack";
    }

    public void idle()
    {
        action_zap = "idle";
    }

}
