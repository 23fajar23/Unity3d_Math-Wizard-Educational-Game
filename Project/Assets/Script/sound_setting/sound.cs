using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sound : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;
    public AudioSource[] music_list;
    public AudioSource[] sfx_list;
    private float musicVolume = 1f;
    private float sfxVolume = 1f;

    void Start()
    {
        Event_Nilai data = new Event_Nilai();
        DataNilai all = data.LoadFromJson();
        musicVolume = all.music_volume;
        sfxVolume = all.sfx_volume;
        musicSlider.value = all.music_volume;
        sfxSlider.value = all.sfx_volume;
    }

    void Update()
    {
        for(int i = 0; i < music_list.Length ; i++)
        {
            music_list[i].volume = musicVolume;
        }

        for(int i = 0; i < sfx_list.Length ; i++)
        {
            sfx_list[i].volume = sfxVolume;
        }
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
        saveData();
    }

    public void SetSfx(float vol)
    {
        sfxVolume = vol;
        saveData();
    }

    public void saveData()
    {
        Event_Nilai data = new Event_Nilai();
        DataNilai all = data.LoadFromJson();
        data.SaveToJson(
            all.play_now, 
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
            musicVolume,
            sfxVolume);
    }
}
