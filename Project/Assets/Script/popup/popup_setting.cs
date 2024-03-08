using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class popup_setting : MonoBehaviour
{
    public GameObject menu;
    public bool menu_aktif;

    public AudioSource click_sound;

    public void OnMouseDown()
    {
        menu.SetActive(menu_aktif);
        click_sound.Play();
    }
}
