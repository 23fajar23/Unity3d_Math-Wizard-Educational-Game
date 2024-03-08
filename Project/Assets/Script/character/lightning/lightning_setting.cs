using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightning_setting : MonoBehaviour
{
    public Animator lightning;
    public string action_lightning = "";
    public bool attack = false;
    public bool finish = false;

    // Update is called once per frame
    void Update()
    {
        if (action_lightning == "idle")
        {
            lightning.SetBool("attack", false);
        }

        if (action_lightning == "attack")
        {
            lightning.SetBool("attack", true);
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

    public void zap_attack()
    {
        action_lightning = "attack";
    }

    public void idle()
    {
        action_lightning = "idle";
    }
}
