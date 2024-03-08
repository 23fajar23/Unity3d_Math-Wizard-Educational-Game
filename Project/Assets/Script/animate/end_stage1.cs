using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class end_stage1 : StateMachineBehaviour
{
    player_setting witch;
    pillar_setting pillar;
    Story1 story1;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        story1 = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<Story1>();
        witch = GameObject.FindGameObjectWithTag("player").GetComponent<player_setting>();
        pillar = GameObject.FindGameObjectWithTag("recall").GetComponent<pillar_setting>();

        Event_Nilai data = new Event_Nilai();
        DataNilai all = data.LoadFromJson();

        if(all.play_now == 3)
        {
            witch.victory();
        }else{
            witch.magic_end();
        }

        pillar.open();

        if(pillar.open_pillar == true)
        {
            witch.end();
            if(witch.end_teleport == true)
            {
                pillar.close();
            }
        }

        if(pillar.close_pillar == true)
        {
            int use_unlock = 1;
            switch(all.unlock_stage)
            {
                case 1:
                    use_unlock = 2;
                    break;
                case 2:
                    use_unlock = 3;
                    break;
                case 3:
                    use_unlock = 3;
                    break;
            }

            switch(all.play_now)
            {
                case 1:
                    data.SaveToJson(
                    2, 
                    story1.correct_answer, 
                    all.stage2, 
                    all.stage3, 
                    (all.lewati - all.lewati_stage1 + story1.lewati_answer),
                    story1.lewati_answer,
                    all.lewati_stage2,
                    all.lewati_stage3,
                    story1.save_answer1,
                    all.save_answer_stage2,
                    all.save_answer_stage3,
                    use_unlock,
                    all.music_volume,
                    all.sfx_volume);
                    SceneManager.LoadScene("Stage2");
                    break;
                case 2:
                    data.SaveToJson(
                    3, 
                    all.stage1, 
                    story1.correct_answer, 
                    all.stage3,
                    (all.lewati - all.lewati_stage2 + story1.lewati_answer),
                    all.lewati_stage1,
                    story1.lewati_answer,
                    all.lewati_stage3,
                    all.save_answer_stage1,
                    story1.save_answer2,
                    all.save_answer_stage3,
                    use_unlock,
                    all.music_volume,
                    all.sfx_volume);
                    SceneManager.LoadScene("Stage3");
                    break;
                case 3:
                    data.SaveToJson(
                    3, 
                    all.stage1, 
                    all.stage2, 
                    story1.correct_answer,
                    (all.lewati - all.lewati_stage3 + story1.lewati_answer),
                    all.lewati_stage1,
                    all.lewati_stage2,
                    story1.lewati_answer,
                    all.save_answer_stage1,
                    all.save_answer_stage2,
                    story1.save_answer3_backup,
                    use_unlock,
                    all.music_volume,
                    all.sfx_volume);
                    SceneManager.LoadScene("Skor");
                    break;
            }
        }
        
    }

}
