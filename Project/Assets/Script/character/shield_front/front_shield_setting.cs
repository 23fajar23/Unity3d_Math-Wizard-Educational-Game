using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class front_shield_setting : MonoBehaviour
{
    public Animator shield;
    public string action_shield = "";

    // Update is called once per frame
    void Update()
    {
        if (action_shield == "open")
        {
            shield.SetBool("open", true);
        }

        if (action_shield == "close")
        {
            shield.SetBool("open", false);
            shield.SetBool("close", true);
        }
    }

    public void open()
    {
        action_shield = "open";
    }

    public void close()
    {
        action_shield = "close";
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
