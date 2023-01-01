using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DiaryManager : MonoBehaviour,IData
{
    public DiaryData currentDiarydate;
    public List<DiaryData> diaryData = new();
    DiaryManagerUi diaryManagerui;
    private void Awake()
    {
        diaryManagerui  = GetComponent<DiaryManagerUi>();    
    }
    [Button]
    public void LoadData()
    {
        diaryData = GameManager._instance.saveManager.LoadFile<List<DiaryData>>(Managers.DiaryManager);
           
    }
    [Button]
    public void SaveData()
    {
        GameManager._instance.saveManager.SaveFile(Managers.DiaryManager,currentDiarydate);
    }

   
}
[System.Serializable]
public class DiaryData
{
    public DateTime dateTime;
    public string title, diartContent;
    void SetCalender()
    {
        
    }
}


