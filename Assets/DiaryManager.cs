using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DiaryManager : MonoBehaviour,IData
{
    public DiaryData currentDiarydate;
    public MainDiaryData mainDiaryData;
    DiaryManagerUi diaryManagerui;
    private void Awake()
    {
        diaryManagerui  = GetComponent<DiaryManagerUi>();    
    }
    public void SaveDiary()
    {
        diaryManagerui.writingPanel.gameObject.SetActive(false);
        Debug.Log(diaryManagerui.writingPanel);
        Debug.Log(diaryManagerui.writingPanel.dateTimeSetter.dateTime);


        if (diaryManagerui.isEditingMode)
        {
            diaryManagerui.isEditingMode = false;
            foreach (var item in mainDiaryData.diaryData)
            {
                if (item.id == diaryManagerui.editingDiaryId)
                {
                    item.title = diaryManagerui.writingPanel.title.text;
                    item.diaryContent = diaryManagerui.writingPanel.diaryContent.text;
                    item.dateTime = diaryManagerui.writingPanel.dateTimeSetter.dateTime;
                }
            }
        }
        else
        {
            mainDiaryData.diaryData.Add(new DiaryData(mainDiaryData.diaryData.Count, diaryManagerui.writingPanel.dateTimeSetter.dateTime,
                        diaryManagerui.writingPanel.title.text, diaryManagerui.writingPanel.diaryContent.text));
        }
        
        SaveData();
        diaryManagerui.EnableDiaryListUi();
    }
        public void DeleteDiary(DiaryData diaryData)
    {
        mainDiaryData.diaryData.Remove(diaryData);
        SaveData();
    }
    private void Start()
    {
        LoadData();
    }
    [Button]
    public void SaveData()
    {
        GameManager._instance.saveManager.SaveFile(Managers.DiaryManager,   mainDiaryData);
    }
    [Button]
    public void LoadData()
    {
        mainDiaryData= GameManager._instance.saveManager.LoadFile<MainDiaryData>(Managers.DiaryManager);
        if (mainDiaryData == null )
        {
            mainDiaryData= new();
            mainDiaryData.diaryData = new();

        }
        else if (mainDiaryData.diaryData.Count == 0)
        {
            mainDiaryData.diaryData = new();
        }
           
    }
    

   
}
[System.Serializable]
public class MainDiaryData
{
    public List<DiaryData> diaryData = new();

}
[System.Serializable]
public class DiaryData
{
    public int id;
    public DateTime dateTime;
    public string title, diaryContent;
   
    public DiaryData(int id,DateTime dateTime, string title, string diaryContent)

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


