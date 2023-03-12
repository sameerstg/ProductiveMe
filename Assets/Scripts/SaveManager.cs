using Newtonsoft.Json;
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
        File.WriteAllText(Application.persistentDataPath + "\\" + manager + ".json", jsonConverted);
    }
    public T LoadFile<T>(Managers manager)
    {
        string fileContents = "";
        if (File.Exists(Application.persistentDataPath + "\\" + manager + ".json"))
        {
            fileContents = File.ReadAllText(Application.persistentDataPath + "\\" + manager + ".json");


        }
        return JsonConvert.DeserializeObject<T>(fileContents);
    }
}
public enum Managers
{
    MoneyManager, DiaryManager
}
