using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiaryBottomMenu : MonoBehaviour
{
    public Button writingPanelButton, historyPanelButton;
       void Start()
    {
        writingPanelButton.onClick.AddListener(() => DiaryManager._instance.StartDiaryWriting());
        historyPanelButton.onClick.AddListener(() => DiaryManager._instance.StartDiaryHistory());
    }

    }
