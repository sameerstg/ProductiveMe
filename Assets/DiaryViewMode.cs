using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DiaryViewMode : MonoBehaviour
{
    public TextMeshProUGUI title, content;
    public DiaryData currentlyViewingDiary;

    public void SetViewMode(DiaryData diaryData)
    {
        currentlyViewingDiary = diaryData;
        title.text = diaryData.title;
        content.text = diaryData.diaryContent;
    }
}
