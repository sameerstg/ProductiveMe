using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DateTimeSetter : MonoBehaviour
{

    public List<Button> buttons = new();
    public List<TextMeshProUGUI> texts = new();
    public DateTime dateTime;
    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            buttons.Add(transform.GetChild(i).GetComponent<Button>());
            texts.Add(buttons[buttons.Count - 1].GetComponentInChildren<TextMeshProUGUI>());
        }
    }
    private void Start()
    {
        dateTime = DateTime.Now;
        texts[0].text = $"{dateTime.Day}/{dateTime.Month}/{dateTime.Year}";
        texts[1].text = $"{dateTime.Hour}:{dateTime.Minute}";
    }
}
