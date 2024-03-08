using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_setting : MonoBehaviour
{
    public List<GameObject> waypoints;
    public Animator player;
    public float speed = 10;
    public int waypoint = 0;
    public bool attack_enemy = false;
    public bool end_teleport = false;
    public string action_player = "";
    Story1 story_question;

    // Start is called before the first frame update
    void Start()
    {
        walk();
        waypoint++;
    }

    public void action()
    {
        if (action_player == "idle")
        {
            player.SetBool("walk", false);
            player.SetBool("attack", false);
            player.SetBool("damage", false);
            player.SetBool("prepare_magic", false);
            player.SetBool("stabbing", false);
            player.SetBool("half_magic", false);
            player.SetBool("magic", false);
        }
        
        if (action_player == "walk")
        {
            player.SetBool("attack", false);
            player.SetBool("prepare_magic", false);
            player.SetBool("walk", true);
            player.SetBool("stabbing", false);
            player.SetBool("half_magic", false);
        }

        if (action_player == "damage")
        {
            player.SetBool("damage", true);
        }

        if (action_player == "attack")
        {
            player.SetBool("walk", false);
            player.SetBool("attack", true);
        }

        if (action_player == "half_magic")
        {
            player.SetBool("walk", false);
            player.SetBool("prepare_magic", false);
            player.SetBool("attack", false);
            player.SetBool("half_magic", true);
        }

        if (action_player == "prepare_magic")
        {
            player.SetBool("walk", false);
            player.SetBool("attack", false);
            player.SetBool("prepare_magic", true);
            player.SetBool("stabbing", false);
            player.SetBool("half_magic", false);
        }

        if (action_player == "stabbing")
        {
            player.SetBool("walk", false);
            player.SetBool("attack", false);
            player.SetBool("prepare_magic", false);
            player.SetBool("stabbing", true);
            player.SetBool("half_magic", false);
        }

        if (action_player == "magic")
        {
            player.SetBool("walk", false);
            player.SetBool("attack", false);
            player.SetBool("damage", false);
            player.SetBool("prepare_magic", false);
            player.SetBool("stabbing", false);
            player.SetBool("half_magic", false);
            player.SetBool("magic", true);
        }

        if (action_player == "magic_end")
        {
            player.SetBool("magic_end", true);
        }

        if (action_player == "end")
        {
            player.SetBool("end", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        action();

        Vector3 destination = waypoints[waypoint].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPos;
        
        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= 0.05)
        {
            action_player = "idle";

            if(waypoint == 1)
            {
                story_question = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<Story1>();
                story_question.start_question();
            }

            if(waypoint == 12)
            {
                action_player="idle";
            }
        }
    }

    public void move_player_to_enemy()
    {
        Vector3 destination = waypoints[waypoint].transform.position;
        
        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= 0.05)
        {
            if(waypoint == 2 || waypoint == 4 || waypoint == 6)
            {
                action_player = "attack";
            }
            
            if(waypoint == 8 || waypoint == 10)
            {
                action_player = "attack";
            }
        }
    }

    public void custom_waypoint(int dot)
    {
        waypoint = dot;
    }

    public void idle()
    {
        action_player = "idle";
    }

    public void magic()
    {
        action_player = "magic";
    }

    public void half_magic()
    {
        action_player = "half_magic";
    }

    public void prepare_magic()
    {
        action_player = "prepare_magic";
    }

    public void walk()
    {
        action_player = "walk";
    }

    public void magic_end()
    {
        player.SetBool("magic_end", true);
    }

    public void end()
    {
        player.SetBool("end", true);
    }

    public void victory()
    {
        player.SetBool("victory", true);
    }

    public void after_attack()
    {
        attack_enemy = true;
    }

    public bool get_attack()
    {
        return attack_enemy;
    }

    public void reset_attack()
    {
        attack_enemy = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        story_question = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<Story1>();
        if(story_question.get_true_answer() == true)
        {
            
        }

        if(story_question.get_true_answer() == false)
        {
            if(
                other.tag == "slime1" || 
                other.tag == "slime2" || 
                other.tag == "slime3" || 
                other.tag == "wolf4" || 
                other.tag == "wolf5" 
                )
            {
                action_player = "damage";
                story_question.reduce_life();
            }
            
            // else{
            //     Debug.Log("Trigger!");
            // }
        }

        if(other.tag == "fireball7" || other.tag == "fireball8")
        {
            action_player = "damage";
            story_question.reduce_life();
        }     

        if(other.tag == "zap_player9" || other.tag == "zap_player10")
        {
            action_player = "damage";
            story_question.reduce_life();
        }      
    }

}
