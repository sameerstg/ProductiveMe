using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager _instance;
   
    private void Awake()
    {
        _instance = this;
    }
    public void SaveFile(Managers manager, object obj)
    {
        string jsonConverted = JsonConvert.SerializeObject(obj);
        Debug.Log(jsonConverted);
        File.WriteAllText(Application.persistentDataPath + "\\" + manager+".json", jsonConverted);
    }
     public void SaveFile(Managers manager, string obj)
    {
        string jsonConverted = JsonUtility.ToJson(obj);
        Debug.Log(jsonConverted);
        File.WriteAllText(Application.persistentDataPath + "\\" + manager+".json", obj);
    }

    public T LoadFile<T>(Managers manager)
    {
        string fileContents = "";
        if (File.Exists(Application.persistentDataPath + "\\" + manager + ".json"))
        {
            fileContents = File.ReadAllText(Application.persistentDataPath + "\\" + manager+ ".json");

           
        }
        return JsonUtility.FromJson<T>(fileContents); 
    }
}
 public enum Managers
{
    MoneyManager,DiaryManager
}
