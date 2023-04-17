using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DateSeparatorForHistoryPanel : MonoBehaviour
{
    public List<TextMeshProUGUI> texts = new();
    public void Set(string date, float amount)
    {
        texts[0].text = date;
        texts[1].text = amount.ToString();
    } public void Set(string date, string content)
    {
        texts[0].text = date;
        texts[1].text = content.ToString();
    } public void AddAmount( float amount)
    {
                texts[1].text = (float.Parse(texts[1].text)+amount).ToString();
    }
}
