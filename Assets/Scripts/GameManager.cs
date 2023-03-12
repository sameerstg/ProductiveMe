using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public SaveManager saveManager;
    public MainMenu mainMenu;
    public DiaryManager diaryManager;
    public MoneyManager moneyManager; 
    private void Awake()
    {
        _instance = this;

       
    }

    internal void ShowDiaryManager()
    {
        mainMenu.gameObject.SetActive(false);
        diaryManager.gameObject.SetActive(true);
    }

    internal void ShowMoneyManager()
    {
        mainMenu.gameObject.SetActive(false);

        moneyManager.gameObject.SetActive(true);

    }
    internal void ShowMainMenu()
    {
        diaryManager.gameObject.SetActive(false);
        moneyManager.gameObject.SetActive(false);
        moneyManager.gameObject.SetActive(true);
    }
}
