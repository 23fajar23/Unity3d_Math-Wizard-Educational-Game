using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Training : MonoBehaviour
{
    public Animator camera;
    public int question = 0;

    public int control_training = 0;
    public Button next_button;
    public Button prev_button;
    public GameObject next_object;
    public GameObject[] destroy_question;

    public Button[] img_question;
    public Button[] send_question;
    public Button[] btn_answer;
    
    //Train 1
    public Canvas train1;
    public SpriteRenderer[] asset1;
    public SpriteRenderer box1;
    public Text desc1;

    //Train 2
    public Canvas field_and_button;
    public SpriteRenderer field_question;
    public SpriteRenderer box2;

    //Train 3
    public SpriteRenderer box3;

    //Train 5
    public SpriteRenderer box4;
    public Button skip;
    public Canvas field_skip;
    public Text desc4;

    screen_black screen_controll;
    
    // public SpriteRenderer tes;

    // public Canvas coba;
    // Start is called before the first frame update
    void Start()
    {
        next_question();
    }

    // Update is called once per frame
    void Update()
    {
        if(control_training == 0)
        {
            prev_button.interactable = false;
            box1.enabled = true;
            desc1.enabled = true;
            train1.sortingOrder = 12;
            for(int i = 0; i < asset1.Length ;i++)
            {
                asset1[i].sortingOrder = 12;
            }
        }else{
            prev_button.interactable = true;
            box1.enabled = false;
            desc1.enabled = false;
            train1.sortingOrder = 5;
            for(int i = 0; i < asset1.Length ;i++)
            {
                asset1[i].sortingOrder = 5;
            }
        }

        if(control_training == 1)
        {
            box2.enabled = true;
            open_question();
            open_answer();
            field_and_button.sortingOrder = 12;
            field_question.sortingOrder = 12;

            disable_img_question();
            disable_send_btn();
        }else{
            field_and_button.sortingOrder = 5;
            field_question.sortingOrder = 5;
            box2.enabled = false;
        }

        if(control_training == 2)
        {
            box3.enabled = true;
            field_and_button.sortingOrder = 12;
            field_question.sortingOrder = 12;
            disable_img_question();
            disable_btn_answer();
            send_question[0].interactable = true;
        }else{
            box3.enabled = false;
        }

        // control training3 = standby

        if(control_training == 4)
        {
            box4.enabled = true;
            field_skip.sortingOrder = 12;
            skip.interactable = true;
            desc4.enabled = true;
        }else{
            box4.enabled = false;
            field_skip.sortingOrder = 5;
            skip.interactable = false;
            desc4.enabled = false;
        }

        
    }

    public void destroy_now()
    {
        Destroy(destroy_question[question-2]);
    }
    
    public void validate()
    {
        next_train();
        screen_controll = GameObject.FindGameObjectWithTag("bg_black").GetComponent<screen_black>();
        Debug.Log("validasi");
        next_question();
        hide_answer();
        close_question();
        screen_controll.close();
    }

    public void destroy_next_btn()
    {
        Destroy(next_object);
    }

    public void next_train()
    {
        control_training++;
    }

    public void next_question()
    {
        question++;
        camera.SetBool("q" + question, true);
    }

    public void close_last_question()
    {
        camera.SetBool("q" + (question - 1), false);
        camera.SetBool("to_question", false);
    }

    public void to_next_question()
    {
        camera.SetBool("to_question", true);
    }

    public void open_answer()
    {
        camera.SetBool("show_answer", true);
        camera.SetBool("hide_answer", false);
    }

    public void hide_answer()
    {
        camera.SetBool("show_answer", false);
        camera.SetBool("hide_answer", true);
    }

    public void open_question()
    {
        camera.SetBool("open_question", true);
        camera.SetBool("close_question", false);
    }

    public void close_question()
    {
        camera.SetBool("close_question", true);
        camera.SetBool("open_question", false);
    }

    public void disable_img_question()
    {
        for(int i = 0; i < img_question.Length; i++)
        {
            img_question[i].interactable = false;
        }
    }

    public void disable_send_btn()
    {
        for(int i = 0; i < send_question.Length; i++)
        {
            send_question[i].interactable = false;
        }
    }

    public void disable_btn_answer()
    {
        for(int i = 0; i < btn_answer.Length; i++)
        {
            btn_answer[i].interactable = false;
        }
    }

    public void play_stage(int mulai)
    {
        Event_Nilai data = new Event_Nilai();
        DataNilai all = data.LoadFromJson();
        data.SaveToJson(
            1, 
            all.stage1, 
            all.stage2, 
            all.stage3, 
            all.lewati,
            all.lewati_stage1,
            all.lewati_stage2,
            all.lewati_stage3,
            all.save_answer_stage1,
            all.save_answer_stage2,
            all.save_answer_stage3,
            all.unlock_stage,
            all.music_volume,
            all.sfx_volume);
    
        SceneManager.LoadScene("Stage1");
        
    }
}
