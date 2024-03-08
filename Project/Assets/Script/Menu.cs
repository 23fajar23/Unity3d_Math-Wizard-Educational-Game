using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menu;
    public bool menu_aktif;
    public int unlock_stage = 1;
    public Slider volumeSlider;
    public Button btn_stage2;
    public Button btn_stage3;
    public AudioSource click_sound;

    public GameObject alert;
    public GameObject reset_json;
    public List<GameObject> btn;
    private DataNilai dataRaw;
    private string[] zero = {};

    void Start()
    {
        Application.targetFrameRate = 90;
        Event_Nilai data = new Event_Nilai();
        DataNilai all = data.LoadFromJson();
        unlock_stage = all.unlock_stage;
        dataRaw = all;

        //New
        Event_Random random = new Event_Random();
        random.LoadFromJson();
    }

    public void OnMouseDown()
    {
        menu.SetActive(menu_aktif);
        click_sound.Play();
    }

    void Update()
    {
        switch (unlock_stage)
        {
            case 1:
                btn_stage2.interactable = false;
                btn_stage3.interactable = false;
                break;
            case 2:
                btn_stage2.interactable = true;
                btn_stage3.interactable = false;
                break;
            case 3:
                btn_stage2.interactable = true;
                btn_stage3.interactable = true;
                break;
        }
    }

    public bool validate_complete()
    {
        if(
            dataRaw.stage1 > 0 && 
            dataRaw.stage2 > 0 && 
            dataRaw.stage3 > 0  )
        {
            return true;
        }else{
            return false;
        }
    }

    public void open_alert()
    {   
        bool in_value = validate_complete();
        if(in_value == true)
        {
            SceneManager.LoadScene("Pembahasan");
        }else{
            alert.SetActive(true);
            for(int i = 0; i < btn.Count; i++)
            {
                btn[i].SetActive(false);
            }
        }
        
    }

    public void close_alert()
    {
        alert.SetActive(false);
        click_sound.Play();
        for(int i = 0; i < btn.Count; i++)
        {
            btn[i].SetActive(true);
        }
    }

    public void open_reset()
    {
        reset_json.SetActive(true);
        click_sound.Play();
        for(int i = 0; i < btn.Count; i++)
        {
            btn[i].SetActive(false);
        }
    }

    public void close_reset()
    {
        click_sound.Play();
        for(int i = 0; i < btn.Count; i++)
        {
            btn[i].SetActive(true);
        }
    }

    public void reset_setting()
    {
        string[] zero = {};
        Event_Nilai data = new Event_Nilai();
        DataNilai all = data.LoadFromJson();
        DataKompeten all_kompeten = data.LoadKompetenJson();
        data.SaveToJson(
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            zero,
            zero,
            zero,
            1,
            all.music_volume,
            all.sfx_volume);

        data.SaveKompetenJson("",0);
        unlock_stage = 1;

        Event_Random random = new Event_Random();
        random.random_now();
    }

    public void exit_app()
    {
        Application.Quit();
        Debug.Log("keluar");
    }

}
