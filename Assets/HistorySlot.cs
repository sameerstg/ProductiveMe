using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HistorySlot : MonoBehaviour
{
    public List<TextMeshProUGUI> texts = new();
    public void Set (string date,string account,string note,string description,string amount,TransactionType transactionType)
    {
        texts[0].text = date;
        texts[1].text = account;
        texts[2].text = note;
        texts[3].text = description;
        if (transactionType == TransactionType.income)
        {
            texts[4].color = Color.green;
        }
        else if (transactionType == TransactionType.expense)
        {
            texts[4].color = Color.red;

        }
        texts[4].text = amount;
    }    
}
