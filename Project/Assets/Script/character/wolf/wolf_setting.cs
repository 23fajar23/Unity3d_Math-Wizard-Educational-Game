using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolf_setting : MonoBehaviour
{
    public List<GameObject> waypoints;
    public Animator wolf;
    public SpriteRenderer wolf_flip;
    public float speed = 2.5f;
    public int waypoint = 0;
    public string action_wolf = "";
    public bool attack = false;
    public bool finish = false;
    public bool destroy_wolf = false;
    Story1 story_question;

    public void flip_rotation_X()
    {
        wolf_flip.flipX = Physics2D.gravity.x < 180;
    }

    // Update is called once per frame
    void Update()
    {
        if (action_wolf == "idle")
        {
            wolf.SetBool("walk", false);
            // wolf.SetBool("damage", false);
            wolf.SetBool("evade", false);
            wolf.SetBool("attack", false);
        }
        
        if (action_wolf == "walk")
        {
            wolf.SetBool("walk", true);
            // wolf.SetBool("damage", false);
            wolf.SetBool("evade", false);
            wolf.SetBool("attack", false);
        }

        if (action_wolf == "attack")
        {
            wolf.SetBool("walk", false);
            // wolf.SetBool("damage", false);
            wolf.SetBool("evade", false);
            wolf.SetBool("attack", true);
        }

        if (action_wolf == "damage")
        {
            wolf.SetBool("walk", false);
            wolf.SetBool("damage", true);
            wolf.SetBool("evade", false);
            wolf.SetBool("attack", false);
        }


        Vector3 destination = waypoints[waypoint].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPos;
        
        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= 0.05)
        {
            action_wolf = "idle";
        }
    }

    public void walk()
    {
        action_wolf = "walk";
    }

    public void idle()
    {
        action_wolf = "idle";
    }

    public void waypoint_attack()
    {
        waypoint = 1;
    }

    public void waypoint_offset()
    {
        waypoint = 2;
    }

    public void after_attack()
    {
        attack = true;
    }

    public bool get_attack()
    {
        return attack;
    }

    public void reset_attack()
    {
        attack = false;
    }

    public bool get_destroy()
    {
        return destroy_wolf;
    }

    public bool get_finish()
    {
        return finish;
    }

    public void move_attack()
    {
        Vector3 destination = waypoints[waypoint].transform.position;
        
        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= 0.05 )
        {
            action_wolf = "idle";
            if(waypoint == 1 && finish == false)
            {
                action_wolf = "attack";
            }

            if(waypoint == 2 && finish == true)
            {
                destroy_wolf = true;
                finish = false;
            }
            
        }
    }

    public void move_offside()
    {
        Vector3 destination = waypoints[waypoint].transform.position;
        
        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= 0.05 && waypoint == 2 && finish == true)
        {
            destroy_wolf = true;
            finish = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        
        story_question = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<Story1>();
        if(story_question.get_true_answer() == true)
        {
            if(other.tag == "player")
            {
                action_wolf = "damage";
            }
        }

        if(story_question.get_true_answer() == false)
        {
            finish = true;
        }      
    }


}
