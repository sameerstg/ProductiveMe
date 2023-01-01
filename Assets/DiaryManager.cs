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
    public void SaveDiary()
    {
        diaryManagerui.writingPanel.gameObject.SetActive(false);

        diaryData.Add(new DiaryData(diaryManagerui.writingPanel.dateTimeSetter.dateTime, diaryManagerui.writingPanel.title.text, diaryManagerui.writingPanel.diaryContent.text));
        SaveData();
        diaryManagerui.EnableDiaryListUi();
    }

    private void Start()
    {
        LoadData();
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


