using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move_Scene : MonoBehaviour
{
    public List<GameObject> objectRaw;
    private string[] zero = {};
    public int start_stage = 1;
    
    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void open_confirm()
    {
        objectRaw[1].SetActive(true);
        objectRaw[0].SetActive(false);
    }

    public void close_confirm()
    {
        objectRaw[1].SetActive(false);
        objectRaw[0].SetActive(true);
    }

    public void open_confirm2()
    {
        objectRaw[2].SetActive(true);
        objectRaw[0].SetActive(false);
    }

    public void close_confirm2()
    {
        objectRaw[2].SetActive(false);
        objectRaw[0].SetActive(true);
    }

    public void to_training()
    {
        SceneManager.LoadScene("Training");
    }

    public void to_menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void to_skor()
    {
        SceneManager.LoadScene("Skor");
    }

    public void to_stage1()
    {
        start_stage = 1;
        Event_Nilai data = new Event_Nilai();
        DataNilai all = data.LoadFromJson();

        if(all.stage1 <= 0)
        {
            open_confirm2();
        }else if(all.stage1 > 0)
        {
            open_confirm();
        }else{
            play_stage(1);
        }
    }

    public void to_stage2()
    {
        start_stage = 2;
        Event_Nilai data = new Event_Nilai();
        DataNilai all = data.LoadFromJson();
        if(all.stage2 > 0)
        {
            open_confirm();
        }else{
            play_stage(2);
        }
    }

    public void to_stage3()
    {
        start_stage = 3;
        Event_Nilai data = new Event_Nilai();
        DataNilai all = data.LoadFromJson();
        if(all.stage3 > 0)
        {
            open_confirm();
        }else{
            play_stage(3);
        }
    }

    public void lets_play()
    {
        play_stage(start_stage);
    }

    public void play_stage(int mulai)
    {
        Event_Nilai data = new Event_Nilai();
        DataNilai all = data.LoadFromJson();

        switch(mulai)
        {
            case 1:
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
                break;
            case 2:
                data.SaveToJson(
                    2, 
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

                SceneManager.LoadScene("Stage2");
                break;
            case 3:
                data.SaveToJson(
                    3, 
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

                SceneManager.LoadScene("Stage3");
                break;
        }
        
    }


}
