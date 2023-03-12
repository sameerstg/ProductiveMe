using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button moneyButton, diaryButton;

    private void Start()
    {
        moneyButton.onClick.AddListener(()=>GameManager._instance.ShowMoneyManager() ); 
        diaryButton.onClick.AddListener(()=>GameManager._instance.ShowDiaryManager() ); 
            
            }
}
