using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransactionHistoryPanel : MonoBehaviour
{
    public GameObject contentParent;
    public GameObject historySlotPrefab;
    public List<GameObject> slots = new();

    public void StartThis()
    {
        MoneyManager._instance.CloseAllPanel();
        gameObject.SetActive(true);
        foreach (var item in slots)
        {
            Destroy(item);

        }
        slots.Clear();
        foreach (var item in MoneyManager._instance.moneyData.accounts)
        {
            foreach (var item2 in item.transaction)
            {
                var slot =Instantiate(historySlotPrefab, contentParent.transform);
                slot.GetComponent<HistorySlot>().Set(item2.date.GetDateTimeFormats()[6], item2.account1, item2.note,item2.description, item2.amount.ToString(),item2.transactionType);
                slots.Add(slot);
            }
        }
    }
    }
