using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield_from_top : MonoBehaviour
{
    public Animator shield;
    public string action_shield = "";
    public bool close_shield = false;

    // Update is called once per frame
    void Update()
    {
        if (action_shield == "open")
        {
            shield.SetBool("open", true);
        }

        if (action_shield == "close")
        {
            shield.SetBool("close", true);
        }
    }

    public void after_close()
    {
        close_shield = true;
    }

    public void open()
    {
        action_shield = "open";
    }

    public void close()
    {
        action_shield = "close";
    }
}
