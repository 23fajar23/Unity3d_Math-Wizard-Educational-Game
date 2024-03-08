using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball_ghost : MonoBehaviour
{
    public Animator fireball;
    public string action_fireball = "";
    public bool explode_finish = false;
    public int can = 0;

    // Start is called before the first frame update
    void Start()
    {
        action_fireball = "idle";
    }
    // Update is called once per frame
    void Update()
    {
        if (action_fireball == "explode")
        {
            fireball.SetBool("explode", true);
            fireball.SetBool("attack", false);
            fireball.SetBool("back_attack", false);
        }

        if (action_fireball == "attack")
        {
            fireball.SetBool("attack", true);
        }

        if (action_fireball == "back_attack")
        {
            fireball.SetBool("back_attack", true);
        }
    }

    public void true_finish()
    {
        explode_finish = true;
    }

    public void explode()
    {
        action_fireball = "explode";
    }

    public void attack()
    {
        if(can == 0)
        {
            action_fireball = "attack";
            can = 1;
        }
        
    }

    public void idle()
    {
        fireball.SetBool("attack", false);
        fireball.SetBool("back_attack", false);
    }

    public void back_attack()
    {
        if(can == 0)
        {
            action_fireball = "back_attack";
            can = 1;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "ghost7" || other.tag == "ghost8")
        {
            action_fireball = "explode";
        }

        if(other.tag == "player")
        {
            action_fireball = "explode";
        }

    }
}
