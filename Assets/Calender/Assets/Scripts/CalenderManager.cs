using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CalenderManager : MonoBehaviour
{
    public DateTime dateTime;
    public string date;
    
    // Body
     public GameObject container;
     public List<GameObject> slots = new();
     public GameObject slot;
    // Header
    public GameObject monthButton, yearButton;
     TextMeshProUGUI monthText, yearText;
     Button monthLeft, monthRight, yearLeft, yearRight;
    private void Awake()
    {
               // Getting References
        monthText = monthButton.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        yearText = yearButton.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        var buttons = monthButton.GetComponentsInChildren<Button>();
        monthLeft = buttons[0];
        monthRight = buttons[1];
        buttons = yearButton.GetComponentsInChildren<Button>();
        yearLeft = buttons[0];
        yearRight = buttons[1];
        //setting buttons
        monthLeft.onClick.AddListener(() => ChangeMonth(-1));
        monthRight.onClick.AddListener(() => ChangeMonth(1));
        yearLeft.onClick.AddListener(() => ChangeYear(-1));
        yearRight.onClick.AddListener(() => ChangeYear(1));



        dateTime = DateTime.Now;
        SetCalender(dateTime);
        
    }
        void SetCalender(DateTime dateTime)
    {
        DestroySlots();
              monthText.text = dateTime.Month.ToString();
        Debug.Log(dateTime.Year);
        Debug.Log(dateTime.Day);
        Debug.Log(dateTime.DayOfWeek);
        Debug.Log(dateTime.DayOfYear);
        var d = dateTime.GetDateTimeFormats();
        var e = dateTime.GetDateTimeFormats()[d.Length-1];

        monthText.text = e.Substring(0, e.IndexOf(" "));


        yearText.text = dateTime.Year.ToString();
        for (int i = 0; i < DateTime.DaysInMonth(dateTime.Year,dateTime.Month); i++)
        {
            var dateSlot = Instantiate(slot, container.transform);
            dateSlot.GetComponentInChildren<TextMeshProUGUI>().text = (i+1).ToString();
            var x = i;
            dateSlot.GetComponent<Button>().onClick.AddListener(() => SelectDate(x + 1));
            slots.Add(dateSlot);
        }
        date = dateTime.GetDateTimeFormats()[0];
    }
    void DestroySlots()
    {
        if (slots.Count==0)
        {
            return;
        }
        foreach (var item in slots)
        {
            Destroy(item);
        }
        slots.Clear();
    }
    void ChangeYear(int value)
    {
        dateTime = dateTime.AddYears(value);
        SetCalender(dateTime);

    }
    void ChangeMonth(int value)
    {
        dateTime = dateTime.AddMonths(value);
        SetCalender(dateTime);
    }
    void SelectDate(int day)
    {
        
        dateTime = dateTime.AddDays(-dateTime.Day+1);
        dateTime = dateTime.AddDays(day-1);
        date = dateTime.GetDateTimeFormats()[0];
        DateTimeSetter._instance.SetDate();
        transform.parent.gameObject.SetActive(false);

    }
}
