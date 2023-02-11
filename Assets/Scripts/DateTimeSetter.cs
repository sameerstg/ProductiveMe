using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DateTimeSetter : MonoBehaviour
{
    public static DateTimeSetter _instance;
    public List<Button> buttons = new();
    public List<TextMeshProUGUI> texts = new();
    public DateTime dateTime;
    public GameObject calenderGo;
    public CalendarManager calenderManager;
            
    private void Awake()
    {
        _instance = this;
            
        for (int i = 0; i < 2; i++)
        {
            buttons.Add(transform.GetChild(i).GetComponent<Button>());
            texts.Add(buttons[buttons.Count - 1].GetComponentInChildren<TextMeshProUGUI>());
        }
    }
    private void Update()
    {
        texts[1].text = dateTime.TimeOfDay.ToString().Substring(0,5);
    }
    internal void SetDate()
    {
        dateTime = calenderManager.dateTime;
        texts[0].text = calenderManager.dateTime.GetDateTimeFormats()[0];
       
    }
    private void Start()
    {
        calenderManager.dateTime = DateTime.Now;
        SetDate(); 
        buttons[0].onClick.AddListener(()=>calenderGo.SetActive(true));
        buttons[1].onClick.AddListener(() => { });
    }

}
