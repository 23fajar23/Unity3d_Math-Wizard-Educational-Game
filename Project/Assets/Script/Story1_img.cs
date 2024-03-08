using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Story1_img : MonoBehaviour
{

    public GameObject soal1_img;
    public bool soal1_img_aktif;
    public AudioSource click_sound;

    public void OnMouseDown()
    {
        soal1_img.SetActive(soal1_img_aktif);
        click_sound.Play();
    }
}
