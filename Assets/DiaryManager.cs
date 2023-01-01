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
    private void Start()
    {
        LoadData();
    }
    public void SaveDiary()
    {
        
        diaryData.Add(new DiaryData(diaryManagerui.dateTimeSetter.dateTime, diaryManagerui.title.text, diaryManagerui.diaryContent.text));
        SaveData();
        diaryManagerui.writingPanel.SetActive(false);
        diaryManagerui.diaryListParrent.SetActive(true);
        diaryManagerui.SetDiarySlotPanel(diaryData);
    }
    [Button]
    public void SaveData()
    {
        GameManager._instance.saveManager.SaveFile(Managers.DiaryManager, diaryData);
    }
    [Button]
    public void LoadData()
    {
        diaryData = GameManager._instance.saveManager.LoadFile<List<DiaryData>>(Managers.DiaryManager);
           
    }
    

   
}
[System.Serializable]
public class DiaryData
{
    public DateTime dateTime;
    public string title, diaryContent;
   
    public DiaryData(DateTime dateTime, string title, string diaryContent)

    {
        this.dateTime = dateTime;
        this.title = title;
        this.diaryContent =
        diaryContent;
    }

    void SetCalender()
    {
        
    }
}


