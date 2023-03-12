using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    public SaveManager saveManager;
    public MainMenuManager mainMenuManager;
    public DiaryManager diaryManager;
    public MoneyManager moneyManager;
    private void Awake()
    {
        _instance = this;
    }
    public void StartMainMenu()
    {
        diaryManager.gameObject.SetActive(false);
        moneyManager.gameObject.SetActive(false);
        mainMenuManager.gameObject.SetActive(true);

    }
    public void StartDiaryManager()
    {
        diaryManager.StartDiaryWriting();

    }
    public void StartMoneyManager()
    {
        moneyManager.StartMoneyManager();

    }
}
