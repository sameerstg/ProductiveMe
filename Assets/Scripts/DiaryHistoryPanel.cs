using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryHistoryPanel : MonoBehaviour
{
    public GameObject contentParent;
    public GameObject historySlotPrefab, historyDateSeparator;
    public List<GameObject> slots = new();
    public CalenderManager calenderManager;


    private void Start()
    {
        calenderManager.OnDateChange += StartThis;
    }
    public void StartThis()
    {

        gameObject.SetActive(true);
        foreach (var item in slots)
        {
            Destroy(item);

        }
        slots.Clear();

        List<Diary> diaries = DiaryManager._instance.diaryData.diaries.FindAll(x => x.dateTime.Date.Month == calenderManager.dateTime.Month &&
        x.dateTime.Date.Year == calenderManager.dateTime.Year);
        string dateForDay = "";
        DateSeparatorForHistoryPanel dateSeparatorHistoryPanel = null;
        foreach (var item in diaries)
        {
            if (dateForDay != item.dateTime.Day.ToString())
            {
                dateForDay = item.dateTime.Day.ToString();
                var separator = Instantiate(historyDateSeparator, contentParent.transform);
                dateSeparatorHistoryPanel = separator.GetComponent<DateSeparatorForHistoryPanel>();
                dateSeparatorHistoryPanel.Set(item.dateTime.Day + " / " + item.dateTime.Month, "");
                slots.Add(separator);
            }

            var slot = Instantiate(historySlotPrefab, contentParent.transform);
            slot.GetComponent<HistorySlotDiary>().Set(item.title, item.content);
            slots.Add(slot);
            
            
        }
    }
}
