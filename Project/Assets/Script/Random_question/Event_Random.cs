using System.Collections;
using System.Collections.Generic;
using System;
using Random=System.Random;
using System.Linq;
using System.Security.Cryptography;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public class Event_Random : MonoBehaviour
{

    public void SaveToJson(int[] stage1, int[] stage2, int[] stage3)
    {
        Data_Output data = new Data_Output();
        data.random_stage1 = stage1;
        data.random_stage2 = stage2;
        data.random_stage3 = stage3;

        string json = JsonUtility.ToJson(data, true);
        string to_path = Application.persistentDataPath.ToString();
        File.WriteAllText(to_path + "/DataRandomFile.json", json);
    }

    public Data_Output LoadFromJson()
    {
        Data_Output data = new Data_Output();

        try 
        {
            string json = File.ReadAllText(Application.persistentDataPath.ToString() + "/DataRandomFile.json");
            JsonUtility.FromJsonOverwrite(json,data);
        }
        catch 
        {
            random_now();
        }
        finally
        {
            string json2 = File.ReadAllText(Application.persistentDataPath.ToString() + "/DataRandomFile.json");
            data = JsonUtility.FromJson<Data_Output>(json2);
        }

        return data;
    }

    public void random_now()
    {
        int[] arr = {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15};
        int[] arr2 = {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15};
        int[] arr3 = {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15};
        Random random = new Random();
        arr = arr.OrderBy(x => random.Next()).ToArray();
        arr2 = arr.OrderBy(x => random.Next()).ToArray();
        arr3 = arr.OrderBy(x => random.Next()).ToArray();

        SaveToJson(arr,arr2,arr3);

        // Debug.Log("pertama");
        // foreach (var i in arr)
        // {
        //     Debug.Log(i);
        // }  
        
    }
    
}
