using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HistorySlotDiary : MonoBehaviour
{
    public List<TextMeshProUGUI> texts = new();
    

    public void Set(string title,string content)
    {
        texts[0].text = title;
        texts[1].text = content;

    }
 }
