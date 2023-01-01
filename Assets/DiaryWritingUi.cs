using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiaryWritingUi : MonoBehaviour
{
    internal DateTimeSetter dateTimeSetter;
    public TMP_InputField title, diaryContent;
    private void Awake()
    {
        dateTimeSetter= GetComponentInChildren<DateTimeSetter>();
    }

}
