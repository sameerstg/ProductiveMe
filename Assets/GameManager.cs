using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public SaveManager saveManager;
    public DiaryManager diaryManager;
    private void Awake()
    {
        _instance = this;
        saveManager= GetComponentInChildren<SaveManager>();   
        diaryManager= GetComponentInChildren<DiaryManager>();
    }
}
