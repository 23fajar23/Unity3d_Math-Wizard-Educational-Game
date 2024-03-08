using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mutant_setting : MonoBehaviour
{
    public List<GameObject> waypoints;
    public Animator mutant;
    public SpriteRenderer mutant_flip;
    public float speed = 2.5f;
    public int waypoint = 0;
    public string action_mutant = "";
    public bool finish_battle = false;
    Story1 story_question;

    public void flip_rotation_X()
    {
        mutant_flip.flipX = Physics2D.gravity.x < 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(action_mutant == "idle")
        {
            mutant.SetBool("walk",false);
            mutant.SetBool("damage",false);
        }

        if(action_mutant == "walk")
        {
            mutant.SetBool("walk",true);
            mutant.SetBool("damage",false);
        }

        if(action_mutant == "damage")
        {
            mutant.SetBool("walk",false);
            mutant.SetBool("damage",true);
        }
        
        Vector3 destination = waypoints[waypoint].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPos;
        
        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= 0.05)
        {
            action_mutant = "idle";
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        story_question = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<Story1>();
        if(story_question.get_true_answer() == true)
        {
            if(other.tag == "lightning9" || other.tag == "lightning10")
            {
                action_mutant = "damage";
                finish_battle = true;
            }
        }
    }

    public void walk()
    {
        action_mutant = "walk";
    }

    public void waypoint_offset()
    {
        waypoint = 1;
    }

    public void move_offside_mutant()
    {
        Vector3 destination = waypoints[waypoint].transform.position;
        
        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= 0.05 && waypoint == 1)
        {
            finish_battle = true;
        }
    }
}
