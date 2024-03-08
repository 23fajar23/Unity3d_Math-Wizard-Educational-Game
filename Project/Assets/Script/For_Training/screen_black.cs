using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screen_black : MonoBehaviour
{
    public Animator screen;
    public bool control = false;
    // Start is called before the first frame update
    void Start()
    {
        open();
    }

    // Update is called once per frame
    void Update()
    {
        if(control == false){
            screen.SetBool("open", false);
            screen.SetBool("close", true);
        }

        if(control == true){
            screen.SetBool("open", true);
            screen.SetBool("close", false);
        }
    }

    public void open()
    {
        control = true;
    }

    public void close()
    {
        control = false;
    }

}
