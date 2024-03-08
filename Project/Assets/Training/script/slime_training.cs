using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime_training : StateMachineBehaviour
{
    slime_setting slime;
    Training training;
    player_setting witch;
    screen_black screen_controll;

    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        training = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<Training>();
        witch = GameObject.FindGameObjectWithTag("player").GetComponent<player_setting>();

        string tag_enemy = "slime" + (training.question - 1);
        slime = GameObject.FindGameObjectWithTag(tag_enemy).GetComponent<slime_setting>();
        
        screen_controll = GameObject.FindGameObjectWithTag("bg_black").GetComponent<screen_black>();

        int to_waypoint_enemy = (training.question - 1) + (training.question - 1);
        int to_waypoint_next_question = to_waypoint_enemy + 1;

        training.close_last_question();
        training.destroy_now();

        if((training.question - 1) == 1)
        {
            witch.walk();
            witch.custom_waypoint(to_waypoint_enemy);
            witch.move_player_to_enemy();

            bool player_attack = witch.get_attack();

            if(player_attack == true)
            {
                GameObject.FindGameObjectWithTag(tag_enemy).active = false;
                witch.walk();
                witch.custom_waypoint(to_waypoint_next_question);
                witch.reset_attack();
                training.to_next_question();
                training.open_question();
                training.open_answer();
            }
        }

        if((training.question - 1) == 2)
        {
            witch.walk();
            witch.custom_waypoint(to_waypoint_enemy);
            witch.move_player_to_enemy();

            bool player_attack = witch.get_attack();

            if(player_attack == true)
            {
                GameObject.FindGameObjectWithTag(tag_enemy).active = false;
                witch.walk();
                witch.custom_waypoint(to_waypoint_next_question);
                witch.reset_attack();
                screen_controll.open();

                training.play_stage(1);     
            }
        }
    }

}
