using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public class Event_Nilai : MonoBehaviour
{

    public void SaveToJson(int play, int nilai1, int nilai2, int nilai3, int lewati,int lewati1,int lewati2,int lewati3,string[] save1, string[] save2, string[] save3, int unlock, float music,float sfx)
    {
        DataNilai data = new DataNilai();
        data.play_now = play;
        data.stage1 = nilai1;
        data.stage2 = nilai2;
        data.stage3 = nilai3;
        data.lewati = lewati;
        data.lewati_stage1 = lewati1;
        data.lewati_stage2 = lewati2;
        data.lewati_stage3 = lewati3;
        data.save_answer_stage1 = save1;
        data.save_answer_stage2 = save2;
        data.save_answer_stage3 = save3;
        data.unlock_stage = unlock;
        data.music_volume = music;
        data.sfx_volume = sfx;


        string json = JsonUtility.ToJson(data, true);
        string to_path = Application.persistentDataPath.ToString();
        File.WriteAllText(to_path + "/NilaiDataFile.json", json);
    }


    public DataNilai LoadFromJson()
    {
        DataNilai data = new DataNilai();

        try 
        {
            string json = File.ReadAllText(Application.persistentDataPath.ToString() + "/NilaiDataFile.json");
            JsonUtility.FromJsonOverwrite(json,data);
        }
        catch 
        {
            string[] zero = {};
            SaveToJson(0,0,0,0,0,0,0,0,zero,zero,zero,1,1,1);
        }
        finally
        {
            string json2 = File.ReadAllText(Application.persistentDataPath.ToString() + "/NilaiDataFile.json");
            data = JsonUtility.FromJson<DataNilai>(json2);
        }

        return data;
    }

    public void SaveKompetenJson(string result_kompeten, int id_user)
    {
        DataKompeten data_user = new DataKompeten();
        data_user.kompeten = result_kompeten;
        data_user.id_data = id_user;

        string json_kompeten = JsonUtility.ToJson(data_user, true);
        string to_path_kompeten = Application.persistentDataPath.ToString();
        File.WriteAllText(to_path_kompeten + "/KompetenDataFile.json", json_kompeten);
    }

    public DataKompeten LoadKompetenJson()
    {
        DataKompeten data_kompeten = new DataKompeten();

        try 
        {
            string json_kompeten = File.ReadAllText(Application.persistentDataPath.ToString() + "/KompetenDataFile.json");
            JsonUtility.FromJsonOverwrite(json_kompeten,data_kompeten);
        }
        catch 
        {
            SaveKompetenJson("", 0);
        }
        finally
        {
            string json_data = File.ReadAllText(Application.persistentDataPath.ToString() + "/KompetenDataFile.json");
            data_kompeten = JsonUtility.FromJson<DataKompeten>(json_data);
        }

        return data_kompeten;

    }

}
