using NaughtyAttributes;
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
       public void QuickSort(int[] arr,int start,int end)
    {

        if (start >= end) return;
        
      
            int pivot = Partition(arr, start, end);
        QuickSort(arr, start, pivot - 1);
        QuickSort(arr,  pivot + 1,end);
    }


    public int Partition(int[] arr, int start, int end)
    {
        int pivot = arr[end];
        int i = start - 1;
        int temp;
            for (int j = start; j <= end-1; j++)
            {
                if (arr[j]<pivot)
                {
                    i++;
                     temp = arr[j];
                    arr[j] = arr[i];
                    arr[i] = temp;

                }
            }
        i++;
         temp = arr[end];
        arr[end] = arr[i];
        arr[i] = temp;
        return i;

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
