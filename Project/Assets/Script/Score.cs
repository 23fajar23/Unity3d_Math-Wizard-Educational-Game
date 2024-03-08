using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Score : MonoBehaviour
{
    public Text uid;
    public Text status_network;
    public Text[] field_nilai;
    public Text field_kompeten;
    public string[] last_result = {};
    public int process = 0;
    public bool network_user = false;
    public bool finish_write = false;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 90;
        Event_Nilai source = new Event_Nilai();
        DataNilai nilai_data = source.LoadFromJson();
        DataKompeten kompeten_data = source.LoadKompetenJson();
        
        if(kompeten_data.kompeten == "" && kompeten_data.id_data == 0)
        {
            if(network_user == true)
            {
                to_upload();
            }else{
                status_offline();
            }

        }else{
            rewrite(
                nilai_data.stage1,
                nilai_data.stage2,
                nilai_data.stage3,
                kompeten_data.kompeten
            );
        }
   
    }

    public void to_upload()
    {
        Event_Nilai source = new Event_Nilai();
        DataNilai nilai_data = source.LoadFromJson();
        DataKompeten kompeten_data = source.LoadKompetenJson();
        int data_tidak_tepat = 30 - (nilai_data.stage1 + nilai_data.stage2 + nilai_data.stage3 + nilai_data.lewati);
        StartCoroutine(Upload(
            (nilai_data.stage1 + nilai_data.stage2 + nilai_data.stage3),
            data_tidak_tepat,
            (nilai_data.stage1 + nilai_data.stage2 + nilai_data.stage3 + data_tidak_tepat),
            nilai_data.lewati
        ));
    }

    public void status_online()
    {
        status_network.text = "online";
    }

    public void status_offline()
    {
        status_network.text = "offline";
    }
    
    public void id_user()
    {
        Event_Nilai source = new Event_Nilai();
        DataNilai nilai_data = source.LoadFromJson();
        DataKompeten kompeten_data = source.LoadKompetenJson();
        uid.text = "UID : " + kompeten_data.id_data;
    }

    // Update is called once per frame
    void Update()
    {
        if(Application.internetReachability == NetworkReachability.NotReachable)
        {
            network_user = false;
            status_offline();
        }else{
            network_user = true;
            status_online();
        }

        if(
            network_user == true && 
            finish_write == false &&
            process == 0)
        {
            process = 1;
            to_upload();
        }

    }

    public void rewrite(int nilai1, int nilai2, int nilai3, string value)
    {
        field_nilai[0].text = (nilai1 * 10).ToString();
        field_nilai[1].text = (nilai2 * 10).ToString();
        field_nilai[2].text = (nilai3 * 10).ToString();
        
        if(value == "ya")
        {
            field_kompeten.text = "Kompeten";
        }else{
            field_kompeten.text = "Tidak Kompeten";
        }

        id_user();

        finish_write = true;
    }

    public void to_update()
    {
        if(network_user == true)
        {
            process = 1;
            Event_Nilai source = new Event_Nilai();
            DataNilai nilai_data = source.LoadFromJson();
            DataKompeten kompeten_data = source.LoadKompetenJson();
            int data_tidak_tepat = 30 - (nilai_data.stage1 + nilai_data.stage2 + nilai_data.stage3 + nilai_data.lewati);
            StartCoroutine(Upload_update(
                (nilai_data.stage1 + nilai_data.stage2 + nilai_data.stage3),
                data_tidak_tepat,
                (nilai_data.stage1 + nilai_data.stage2 + nilai_data.stage3 + data_tidak_tepat),
                nilai_data.lewati,
                kompeten_data.id_data
            ));
        }else{
            status_offline();
        }
        
    }

    IEnumerator Upload(int benar, int tidak_tepat, int terisi, int lewati)
    {
        WWWForm form = new WWWForm();
        form.AddField("benar", benar);
        form.AddField("tidak_tepat", tidak_tepat);
        form.AddField("terisi", terisi);
        form.AddField("lewati", lewati);
        form.AddField("key", "edukasi");

        using (UnityWebRequest www = UnityWebRequest.Post("https://edukasigame.000webhostapp.com/input_data.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                string api_data = www.downloadHandler.text;
                last_result = api_data.Split(",");
                finish_write = true;
                process = 0;
                after_call();
            }
        }
    }

    IEnumerator Upload_update(int benar, int tidak_tepat, int terisi, int lewati, int id_user)
    {
        WWWForm form = new WWWForm();
        form.AddField("id", id_user);
        form.AddField("benar", benar);
        form.AddField("tidak_tepat", tidak_tepat);
        form.AddField("terisi", terisi);
        form.AddField("lewati", lewati);
        form.AddField("key", "edukasi");

        using (UnityWebRequest www = UnityWebRequest.Post("https://edukasigame.000webhostapp.com/update_data.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                string api_data = www.downloadHandler.text;
                last_result = api_data.Split(",");
                finish_write = true;
                process = 0;
                after_call();
            }
        }
    }

    public void after_call()
    {
        Event_Nilai source = new Event_Nilai();
        DataNilai nilai_data = source.LoadFromJson();
        DataKompeten kompeten_data = source.LoadKompetenJson();
                
        int to_convert = int.Parse(last_result[1]);
        source.SaveKompetenJson(
            last_result[0], to_convert
        );

        rewrite(
            nilai_data.stage1,
            nilai_data.stage2,
            nilai_data.stage3,
            last_result[0]
        );

    }

    
}
