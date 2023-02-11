using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetTransactionSlot : MonoBehaviour
{
    public TextMeshProUGUI category, account, amount,dateTime;
    public void Set(string category,string account,float amount,string dateTime)
    {
        this.category.text = category;
        this.account.text = account;
        this.amount.text = amount.ToString();
        this.dateTime.text = dateTime;

    }
   }
