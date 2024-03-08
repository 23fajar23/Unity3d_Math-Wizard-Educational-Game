using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pillar_setting : MonoBehaviour
{
    public Animator pillar;
    public string action_pillar = "";
    public bool open_pillar = false;
    public bool close_pillar = false;

    // Start is called before the first frame update
    void Start()
    {
        action_pillar = "idle";
    }

    // Update is called once per frame
    void Update()
    {
        if (action_pillar == "open")
        {
            pillar.SetBool("open", true);
        }

        if (action_pillar == "close")
        {
            pillar.SetBool("close", true);
        }
    }

    public void open()
    {
        action_pillar = "open";
    }

    public void close()
    {
        action_pillar = "close";
    }
}
