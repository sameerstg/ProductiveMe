using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DiaryManager : MonoBehaviour
{
    public static DiaryManager _instance;
    public DiaryData diaryData;
    [Foldout("References")]
    public GameObject writingPanel;
    public DiaryHistoryPanel diaryHistoryPanel;
    public TMP_InputField title, content;
    public Button cancel, save;
    public DateTime dateTime;
    public Diary editingDiary;
    private void Awake()
    {
        _instance = this;
    }
    private void Start()
    {

        try
        {
            diaryData = SaveManager._instance.LoadFile<DiaryData>(Managers.DiaryManager);
            if (diaryData == null)
            {
                diaryData = new();

            }
        }
        catch (Exception)
        {

            diaryData = new();
           
        }
        save.onClick.AddListener(() => CreateDiary());
    }
    public void StartDiaryWriting()
    {
        gameObject.SetActive(true);
        writingPanel.gameObject.SetActive(true);
        diaryHistoryPanel.gameObject.SetActive(false);
        if (editingDiary == null)
        {
            title.text = editingDiary.title;
            content.text = editingDiary.content;

        }
    }
    public void StartDiaryHistory()
    {
        gameObject.SetActive(true);
        writingPanel.gameObject.SetActive(false);
        diaryHistoryPanel.StartThis();
    }
    void CreateDiary()
    {
        if (string.IsNullOrWhiteSpace(title.text)  || string.IsNullOrWhiteSpace(title.text))
        {
            return;
        }
        diaryData.AddNewDiary(new Diary(title.text,content.text,DateTime.Now));

        Save();
        CancelDiary();
    }
    public void Save()
    {

        SaveManager._instance.SaveFile(Managers.DiaryManager, diaryData);
    }

    void CancelDiary()
    {
        title.text = "";
        content.text = "";
    }
}
[System.Serializable]
public class DiaryData
{
    public List<Diary> diaries = new();
    public void AddNewDiary(Diary diary){

        diary.id = GetNewId();
        diaries.Add(diary);
   }
    public int GetNewId()
    {
        return diaries.Count + 1;
    }
    
   }
[System.Serializable]

public class Diary
{
    public int id;
    public string title, content;
    public DateTime dateTime;

    public Diary(string title, string content,DateTime dateTime)
    {
        this.title = title;
        this.content = content;
        this.dateTime = dateTime;
    }
}
