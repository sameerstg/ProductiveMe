using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager _instance;
    public enum Managers
    {
        MoneyManager
    }
    private void Awake()
    {
        _instance = this;
    }
    public void SaveFile(Managers manager, Object obj)
    {
        string jsonConverted = JsonConvert.SerializeObject(obj);
        File.WriteAllText(Application.persistentDataPath + "\\" + manager + ".json", jsonConverted);
    }
    public object LoadFile(Managers manager)
    {
        if (File.Exists(Application.persistentDataPath + "\\" + manager + ".json"))
        {
            string fileContents = File.ReadAllText(Application.persistentDataPath + "\\" + manager+ ".json");
            object objData = JsonConvert.DeserializeObject<object>(fileContents);
            return objData;
        }
        return null;
    }
}
