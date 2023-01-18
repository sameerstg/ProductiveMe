using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;

public class DiaryManagerUi : MonoBehaviour
{
    public static DiaryManagerUi _instance;
    public DiaryHomeScreen diaryHomeScreen;
    public DiaryWritingUi writingPanel;
    public DiaryViewMode diaryViewMode;
    public DiaryListUi diaryListUi;
    public DiaryManager diaryManager;
    internal bool isEditingMode;
    internal int editingDiaryId;
    private void Awake()
    {
        _instance   = this;
        diaryManager = GetComponent<DiaryManager>();
    }
    private void OnEnable()
    {
        EnableHomeScreen();

    }
    public void EnableDiaryWritingMode()
    {
        
        diaryHomeScreen.gameObject.SetActive(false);
        writingPanel.title.text = "";
        writingPanel.diaryContent.text = "";

        writingPanel.gameObject.SetActive(true);
    }
    public void EnableDiaryWritingMode(DiaryData diaryData)
    {
        
        diaryHomeScreen.gameObject.SetActive(false);
        writingPanel.title.text = diaryData.title;
        writingPanel.diaryContent.text = diaryData.diaryContent;

        writingPanel.gameObject.SetActive(true);
    }

    public void EnableDiaryListUi()
    {
        DisableAllScreen();
        diaryListUi.gameObject.SetActive(true);
        diaryListUi.SetDiarySlotPanel(diaryManager.mainDiaryData.diaryData);        
    }
    public void EnableDiaryViewMode(int index)
    {
        diaryListUi.gameObject.SetActive(false);
        diaryViewMode.gameObject.SetActive(true);
        diaryViewMode.SetViewMode(diaryManager.mainDiaryData.diaryData[index]);
    }
    public void EnableHomeScreen()
    {
        DisableAllScreen();
        diaryHomeScreen.gameObject.SetActive(true);
    }
    public void DisableAllScreen()
    {
        diaryHomeScreen.gameObject.SetActive(false) ;
        writingPanel.gameObject.SetActive(false);
      diaryViewMode.gameObject.SetActive(false);
      diaryListUi.gameObject.SetActive(false);
    }
    public void EditDiary()
    {
        DiaryData diaryToBeEdited = diaryViewMode.currentlyViewingDiary;
        editingDiaryId = diaryToBeEdited.id;
        isEditingMode = true;
        DisableAllScreen();
        EnableDiaryWritingMode(diaryToBeEdited);
    }
    public void DeleteDiary()
    {

         DiaryData diaryToBeEdited = diaryViewMode.currentlyViewingDiary;
        DisableAllScreen();

        diaryManager.DeleteDiary(diaryToBeEdited);
        EnableDiaryListUi();
    }
}

