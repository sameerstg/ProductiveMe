using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    public Button diaryButton,moneyButton;
    private void Start()
    {
        diaryButton.onClick.AddListener(() => StartDiaryPanel());
        moneyButton.onClick.AddListener(() => StartMoneyPanel());
    }
    void StartDiaryPanel()
    {
        gameObject.SetActive(false);
        GameManager._instance.StartDiaryManager();
    }
    void StartMoneyPanel()
    {
        gameObject.SetActive(false);
        GameManager._instance.StartMoneyManager();


    }
}
