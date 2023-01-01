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
    public GameObject calenderGo;
    public CalendarManager calendarManager;
    public GameObject timeGo;
            
    private void Awake()
    {
        calendarManager = calenderGo.GetComponent<CalendarManager>();
        for (int i = 0; i < 2; i++)
        {
            buttons.Add(transform.GetChild(i).GetComponent<Button>());
            texts.Add(buttons[buttons.Count - 1].GetComponentInChildren<TextMeshProUGUI>());
        }
    }
    internal void SetDate(DateTime date)
    {
        dateTime = date;
        texts[0].text = $"{dateTime.Day}/{dateTime.Month}/{dateTime.Year}";
        texts[1].text = $"{dateTime.Hour}:{dateTime.Minute}";

    }
    private void Start()
    {
        SetDate(DateTime.Now); 
        buttons[0].onClick.AddListener(()=>calenderGo.SetActive(true));
        buttons[1].onClick.AddListener(()=>timeGo.SetActive(true));
    }

}
