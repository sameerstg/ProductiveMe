using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetTransactionSlot : MonoBehaviour
{
    public TextMeshProUGUI category, account, amount;
    public void Set(string category,string account,float amount)
    {
        this.category.text = category;
        this.account.text = account;
        this.amount.text = amount.ToString();

    }
   }
