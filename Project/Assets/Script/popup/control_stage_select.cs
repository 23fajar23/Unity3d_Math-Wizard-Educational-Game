using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class control_stage_select : MonoBehaviour
{
    public Button[] btn_stage;
    public bool menu_aktif;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(menu_aktif == true)
        {
            btn_stage[0].enabled = true;
            btn_stage[1].enabled = true;
            btn_stage[2].enabled = true;
        }

        if(menu_aktif == false)
        {
            btn_stage[0].enabled = false;
            btn_stage[1].enabled = false;
            btn_stage[2].enabled = false;
        }
    }

    public void false_menu()
    {
        menu_aktif = false;
    }
}
