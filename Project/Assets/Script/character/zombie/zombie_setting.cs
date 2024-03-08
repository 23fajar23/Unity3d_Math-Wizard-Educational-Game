using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie_setting : MonoBehaviour
{
    public List<GameObject> waypoints;
    public Animator zombie;
    public SpriteRenderer zombie_flip;
    public float speed = 2.5f;
    public int waypoint = 0;
    public string action_zombie = "";
    public bool finish_battle = false;
    Story1 story_question;

    public void flip_rotation_X()
    {
        zombie_flip.flipX = Physics2D.gravity.x < 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(action_zombie == "idle")
        {
            zombie.SetBool("walk",false);
            zombie.SetBool("damage",false);
        }

        if(action_zombie == "walk")
        {
            zombie.SetBool("walk",true);
            zombie.SetBool("damage",false);
        }

        if(action_zombie == "damage")
        {
            zombie.SetBool("walk",false);
            zombie.SetBool("damage",true);
        }

        Vector3 destination = waypoints[waypoint].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPos;
        
        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= 0.05)
        {
            action_zombie = "idle";
        }
    }

    public bool get_finish()
    {
        return finish_battle;
    }

    public void walk()
    {
        action_zombie = "walk";
    }

    public void waypoint_offset()
    {
        waypoint = 1;
    }

    public void move_offside_zombie()
    {
        Vector3 destination = waypoints[waypoint].transform.position;
        
        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= 0.05 && waypoint == 1)
        {
            finish_battle = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        story_question = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<Story1>();
        if(story_question.get_true_answer() == true)
        {
            if(other.tag == "lightning")
            {
                action_zombie = "damage";
            }
        }

        if(story_question.get_true_answer() == false)
        {
            // Debug.Log("Trigger!");
            story_question.reduce_life();
        }       
    }
}
