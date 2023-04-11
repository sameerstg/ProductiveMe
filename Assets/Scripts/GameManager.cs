using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    public SaveManager saveManager;
    public MainMenuManager mainMenuManager;
    public DiaryManager diaryManager;
    public MoneyManager moneyManager;
    public ColorPalette colorPalette;
    private void Awake()
    {
        _instance = this;
        colorPalette= new();
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
public  class ColorPalette
{
    public static Color32 secondaryColor = new Color32(255, 255, 255, 255);
    public static Color32 primaryColor = new Color32(0, 115, 255, 255);

    public ColorPalette()
    {
        secondaryColor = new Color32(255, 255, 255, 255);
        primaryColor = new Color32(0, 115, 255, 255);
}

    public static void ChangeColor(Image image,ColorType type)
    {
        
        if (type == ColorType.primary)
        {
            image.color = primaryColor;
        }
        else if (type == ColorType.secondary)
        {
            image.color = secondaryColor;
        }
    }
}
public enum ColorType
{

    primary,secondary,tertiary
}
