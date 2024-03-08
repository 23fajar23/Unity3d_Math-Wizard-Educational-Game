using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class function_off : MonoBehaviour
{
    public Button[] btn_object;
    public GameObject[] object_select;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void off_object()
    {
        Debug.Log("off");
        for(int i = 0; i < object_select.Length ; i++)
        {
            object_select[i].SetActive(false);
        }

        for(int i = 0; i < btn_object.Length ; i++)
        {
            btn_object[i].enabled = false;
        }
    }

    public void on_object()
    {
        Debug.Log("on");
        for(int i = 0; i < object_select.Length ; i++)
        {
            object_select[i].SetActive(true);
        }

        for(int i = 0; i < btn_object.Length ; i++)
        {
            btn_object[i].enabled = true;
        }
    }
}
