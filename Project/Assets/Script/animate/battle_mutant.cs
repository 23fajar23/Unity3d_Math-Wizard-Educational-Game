using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battle_mutant : StateMachineBehaviour
{
    Story1 story1;
    player_setting witch;
    zap_mutant_setting zap;
    zap_mutant_setting lightning_player;
    mutant_setting mutant;
    front_shield_setting shield; 
    
    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {   
        story1 = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<Story1>();
        witch = GameObject.FindGameObjectWithTag("player").GetComponent<player_setting>();
        
        string tag_zap = "lightning" + story1.question_last;
        string tag_lightning = "zap_player" + story1.question_last;
        string tag_mutant = "mutant" + story1.question_last;
        string tag_shield = "shield" + story1.question_last;
        zap = GameObject.FindGameObjectWithTag(tag_zap).GetComponent<zap_mutant_setting>();
        lightning_player = GameObject.FindGameObjectWithTag(tag_lightning).GetComponent<zap_mutant_setting>();
        mutant = GameObject.FindGameObjectWithTag(tag_mutant).GetComponent<mutant_setting>();
        shield = GameObject.FindGameObjectWithTag(tag_shield).GetComponent<front_shield_setting>();
        
        bool question_true = story1.get_true_answer();

        story1.close_last_question();
        story1.change_battle();
        
        if(question_true == true)
        {
            witch.magic();
            if(witch.get_attack() == true)
            {
                zap.to_attack();

                if(zap.attack == true)
                {
                    witch.idle();
                    zap.idle();

                    if(zap.finish == true && mutant.finish_battle == true)
                    {
                        GameObject.FindGameObjectWithTag(tag_zap).active = false;
                        if(story1.question_last == 9)
                        {
                            witch.walk();
                            witch.custom_waypoint(15);         
                            story1.to_next_question();
                            story1.reset_true_answer();
                            story1.open_next_question();
                            witch.reset_attack();
                        }

                        if(story1.question_last == 10)
                        {
                            story1.all_end();
                        }
                    }
                }
            }
            
        }else{
            shield.open();
            witch.magic();

            if(witch.get_attack() == true)
            {
                zap.to_back_attack();
                witch.idle();

                if(zap.finish == true)
                {
                    zap.idle();
                    lightning_player.to_attack();

                    if(lightning_player.finish == true)
                    {
                        lightning_player.idle();
                        shield.close();
                        mutant.walk();
                        mutant.flip_rotation_X();
                        mutant.waypoint_offset();
                        mutant.move_offside_mutant();

                        if(mutant.finish_battle == true)
                        {
                            
                            GameObject.FindGameObjectWithTag(tag_zap).active = false;
                            GameObject.FindGameObjectWithTag(tag_mutant).active = false;
                            GameObject.FindGameObjectWithTag(tag_shield).active = false;
                            GameObject.FindGameObjectWithTag(tag_lightning).active = false;
                            
                            if(story1.question_last == 9)
                            {
                                witch.walk();
                                witch.custom_waypoint(15);         
                                story1.to_next_question();
                                story1.reset_true_answer();
                                story1.open_next_question();
                                witch.reset_attack();
                            }

                            if(story1.question_last == 10)
                            {
                                story1.all_end();
                            }
                        }
                    }
                    

                }
            }
        }

    }
}
