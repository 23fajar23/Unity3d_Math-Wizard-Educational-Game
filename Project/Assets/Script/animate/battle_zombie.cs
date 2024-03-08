using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battle_zombie : StateMachineBehaviour
{
    zombie_setting zombie;
    Story1 story1;
    player_setting witch;
    lightning_setting lightning;
    shield_from_top shield;

    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        story1 = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<Story1>();
        witch = GameObject.FindGameObjectWithTag("player").GetComponent<player_setting>();
        lightning = GameObject.FindGameObjectWithTag("lightning").GetComponent<lightning_setting>();
        shield = GameObject.FindGameObjectWithTag("shield_zombie").GetComponent<shield_from_top>();

        string tag_enemy = "zombie" + story1.question_last;
        zombie = GameObject.FindGameObjectWithTag(tag_enemy).GetComponent<zombie_setting>();
        
        bool question_true = story1.get_true_answer();

        int to_waypoint_next_question = witch.waypoint + 1;

        story1.close_last_question();
        story1.change_battle();

        if(question_true == true)
        {
            witch.half_magic();
            lightning.zap_attack();
            if(lightning.attack == true)
            {
                witch.idle();
                lightning.idle();

                bool finish_battle = lightning.finish;
                if(finish_battle == true)
                {
                    GameObject.FindGameObjectWithTag("lightning").active = false;
                    witch.walk();
                    witch.custom_waypoint(to_waypoint_next_question);
                    story1.to_next_question();
                    // story1.reset_true_answer();
                    story1.open_next_question();
                }
            }
        }else{
            shield.open();
            witch.half_magic();
            lightning.zap_attack();

            if(lightning.attack == true)
            {
                witch.idle();
                lightning.idle();

                bool finish_battle = lightning.finish;
                if(finish_battle == true)
                {
                    shield.close();
                    if(shield.close_shield == true)
                    {
                        zombie.flip_rotation_X();
                        zombie.walk();
                        zombie.waypoint_offset();
                        zombie.move_offside_zombie();

                        bool destroy_zombie = zombie.get_finish();
                        if(destroy_zombie == true)
                        {
                            GameObject.FindGameObjectWithTag(tag_enemy).active = false;
                            witch.walk();
                            witch.custom_waypoint(12);
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
