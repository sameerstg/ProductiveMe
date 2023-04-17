using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransactionHistoryPanel : MonoBehaviour
{
    public GameObject contentParent;
    public GameObject historySlotPrefab,historyDateSeparator;
    public List<GameObject> slots = new();
    public CalenderManager calenderManager;


    private void Start()
    {
        calenderManager.OnDateChange += StartThis;
    }
    public void StartThis()
    {
                      
        MoneyManager._instance.CloseAllPanel();
        gameObject.SetActive(true);
        foreach (var item in slots)
        {
            Destroy(item);

        }
        slots.Clear();

        List<Transaction> transactions = MoneyManager._instance.moneyData.allTransactions.FindAll(x => x.date.Date.Month == calenderManager.dateTime.Month &&
        x.date.Date.Year == calenderManager.dateTime.Year);
                string dateForDay = "";
        DateSeparatorForHistoryPanel dateSeparatorHistoryPanel = null;
        foreach (var item in transactions)
        {
            if (dateForDay != item.date.Day.ToString())
            {
                dateForDay = item.date.Day.ToString();
                var separator = Instantiate(historyDateSeparator, contentParent.transform);
                 dateSeparatorHistoryPanel = separator.GetComponent<DateSeparatorForHistoryPanel>();
                dateSeparatorHistoryPanel.Set(item.date.Day + " / " + item.date.Month, 0);
                slots.Add(separator);
            }

            var slot = Instantiate(historySlotPrefab, contentParent.transform);
            slot.GetComponent<HistorySlot>().Set(item.date.GetDateTimeFormats()[6], item.account1, item.note, item.description, item.amount.ToString(), item.transactionType);
            slots.Add(slot);
            if (item.transactionType == TransactionType.income)
            {
                dateSeparatorHistoryPanel.AddAmount(item.amount);
            } else if (item.transactionType == TransactionType.expense)
            {
                dateSeparatorHistoryPanel.AddAmount(-item.amount);
            }
        }
    }
    }
