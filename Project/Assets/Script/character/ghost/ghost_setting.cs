using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost_setting : MonoBehaviour
{
    public List<GameObject> waypoints;
    public Animator ghost;
    public SpriteRenderer ghost_flip;
    public float speed = 2.5f;
    public int waypoint = 0;
    public string action_ghost = "";
    public bool finish_battle = false;
    Story1 story_question;

    public void flip_rotation_X()
    {
        ghost_flip.flipX = Physics2D.gravity.x < 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(action_ghost == "idle")
        {
            ghost.SetBool("walk",false);
            ghost.SetBool("damage",false);
        }

        if(action_ghost == "walk")
        {
            ghost.SetBool("walk",true);
            ghost.SetBool("damage",false);
        }

        if(action_ghost == "damage")
        {
            ghost.SetBool("walk",false);
            ghost.SetBool("damage",true);
        }

        Vector3 destination = waypoints[waypoint].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPos;
        
        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= 0.05)
        {
            action_ghost = "idle";
        }
    }

    public void walk()
    {
        action_ghost = "walk";
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
            if(other.tag == "fireball7" || other.tag == "fireball8")
            {
                action_ghost = "damage";
                finish_battle = true;
            }
        }

        if(story_question.get_true_answer() == false)
        {
            // Debug.Log("Trigger!");
        }       
    }
}
