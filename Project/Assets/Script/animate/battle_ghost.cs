using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battle_ghost : StateMachineBehaviour
{
    ghost_setting ghost;
    fireball_ghost fireball;
    front_shield_setting shield;
    Story1 story1;
    player_setting witch;

    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        story1 = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<Story1>();
        witch = GameObject.FindGameObjectWithTag("player").GetComponent<player_setting>();

        string tag_enemy = "ghost" + story1.question_last;
        string tag_fireball = "fireball" + story1.question_last;
        string tag_shield = "shield_ghost" + story1.question_last;
        ghost = GameObject.FindGameObjectWithTag(tag_enemy).GetComponent<ghost_setting>();
        fireball = GameObject.FindGameObjectWithTag(tag_fireball).GetComponent<fireball_ghost>();
        shield = GameObject.FindGameObjectWithTag(tag_shield).GetComponent<front_shield_setting>();
        
        bool question_true = story1.get_true_answer();

        story1.close_last_question();
        story1.change_battle();
        
        if(question_true == true)
        {
            witch.magic();

            if(witch.get_attack() == true )
            {
                fireball.attack();
                witch.idle();

                if( 
                    fireball.explode_finish == true &&
                    ghost.finish_battle == true
                )
                {
                    fireball.idle();
                    GameObject.FindGameObjectWithTag(tag_shield).active = false;
                    GameObject.FindGameObjectWithTag(tag_fireball).active = false;
                    witch.walk();
                    witch.reset_attack();

                    if(story1.question_last == 7)
                    {
                        witch.custom_waypoint(13);         
                        story1.to_next_question();
                        story1.reset_true_answer();
                        story1.open_next_question();
                    }

                    if(story1.question_last == 8)
                    {
                        witch.custom_waypoint(14);         
                        story1.to_next_question();
                        story1.reset_true_answer();
                        story1.open_next_question();
                    }
  
                }
            }
            
        }else{
            witch.magic();
            shield.open();

            if(witch.get_attack() == true)
            {
                fireball.back_attack();
                witch.idle();

                if(fireball.explode_finish == true)
                {
                    shield.close();
                    ghost.walk();
                    ghost.flip_rotation_X();
                    ghost.waypoint_offset();
                    ghost.move_offside_zombie();
                    fireball.idle();

                    if(ghost.finish_battle == true)
                    {
                        GameObject.FindGameObjectWithTag(tag_enemy).active = false;
                        GameObject.FindGameObjectWithTag(tag_shield).active = false;
                        GameObject.FindGameObjectWithTag(tag_fireball).active = false;
                        witch.walk();
                        witch.reset_attack();

                        if(story1.question_last == 7)
                        {
                            witch.custom_waypoint(13);         
                            story1.to_next_question();
                            story1.reset_true_answer();
                            story1.open_next_question();
                        }

                        if(story1.question_last == 8)
                        {
                            witch.custom_waypoint(14);         
                            story1.to_next_question();
                            story1.reset_true_answer();
                            story1.open_next_question();
                        }
                    }
                }

                

            }

        }

    }

}
