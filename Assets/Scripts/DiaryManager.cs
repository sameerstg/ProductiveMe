using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DiaryManager : MonoBehaviour
{
    public DiaryData diaryData;
    [Foldout("References")]
    public GameObject writingPanel, historyPanel;
    public TMP_InputField title, content;
    public Button cancel, save;
    private void Start()
    {
        diaryData = SaveManager._instance.LoadFile<DiaryData>(Managers.DiaryManager);
    }
    public void StartDiaryWriting()
    {
        gameObject.SetActive(true);
        writingPanel.gameObject.SetActive(true);
        historyPanel.gameObject.SetActive(false);
    }
    public void StartDiaryHistory()
    {
        gameObject.SetActive(true);
        writingPanel.gameObject.SetActive(false);
        historyPanel.gameObject.SetActive(true);
    }
}
[System.Serializable]
public class DiaryData
{
    public List<Diary> diaries = new();
}
[System.Serializable]

public class Diary
{

    public string title, content;

    public Diary(string title, string content)
    {
        this.title = title;
        this.content = content;
    }
}
