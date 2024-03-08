using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime_setting : MonoBehaviour
{
    public List<GameObject> waypoints;
    public Animator slime;
    public SpriteRenderer slime_flip;
    public float speed = 2.5f;
    public int waypoint = 0;
    public string action_slime = "";
    public bool finish = false;
    public bool attack = false;
    public bool destroy_slime = false;
    Story1 story_question;

    // Update is called once per frame
    void Update()
    {
        if (action_slime == "idle")
        {
            slime.SetBool("walk", false);
            slime.SetBool("attack", false);
        }
        
        if (action_slime == "walk")
        {
            slime.SetBool("attack", false);
            slime.SetBool("walk", true);
        }

        if (action_slime == "attack")
        {
            slime.SetBool("walk", false);
            slime.SetBool("attack", true);
        }

        if (action_slime == "damage")
        {
            slime.SetBool("walk", false);
            slime.SetBool("attack", false);
            slime.SetBool("damage", true);
        }

        Vector3 destination = waypoints[waypoint].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPos;
        
        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= 0.05)
        {
            action_slime = "idle";
        }

    }

    public void flip_rotation_X()
    {
        slime_flip.flipX = Physics2D.gravity.x < 180;
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

    public bool get_finish()
    {
        return finish;
    }

    public bool get_destroy()
    {
        return destroy_slime;
    }

    public void reset_destroy()
    {
        destroy_slime = false;
    }

    public void walk()
    {
        action_slime = "walk";
    }
    
    public void waypoint_attack()
    {
        waypoint = 1;
    }

    public void waypoint_offset()
    {
        waypoint = 2;
    }

    public void move_attack()
    {
        Vector3 destination = waypoints[waypoint].transform.position;
        
        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= 0.05 )
        {
            action_slime = "idle";
            if(waypoint == 1 && finish == false)
            {
                action_slime = "attack";
            }

            // if(waypoint == 2 && finish == true)
            // {
            //     destroy_slime = true;
            //     finish = false;
            // }
            
        }
    }

    public void move_offside()
    {
        Vector3 destination = waypoints[waypoint].transform.position;
        
        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= 0.05 && waypoint == 2 && finish == true)
        {
            destroy_slime = true;
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
                action_slime = "damage";
            }
        }

        if(story_question.get_true_answer() == false)
        {
            finish = true;
        }      
    }

}
