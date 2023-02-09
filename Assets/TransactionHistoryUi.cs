using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TransactionHistoryUi : MonoBehaviour
{
    public GameObject transactionSlot;
    public GameObject container;
    public List<GameObject> transactionsList = new List<GameObject>(); 
    
    public Button leftMonthButton,  rightMonthButton;
    public TextMeshProUGUI monthText;
    DateTime date;
    private void Start()
    {
        leftMonthButton.onClick.AddListener(() => { date= date.AddMonths(-1); });
        rightMonthButton.onClick.AddListener(() => { date= date.AddMonths(+1); });
    }
    public void Show()
    {
        gameObject.SetActive(true);
        Referesh();


    }
    public void Referesh()
    {
        date = DateTime.Now;
        SetDate();
        if (transactionsList.Count>0)
        {
            foreach (var item in transactionsList)
            {
                Destroy(item);
            }
        }
        foreach (var acc in MoneyManager._instance.moneyManagerData.accounts)
        {
            foreach (var item in acc.transactions)
            {
                if (date.Month != item.dateTime.Month)
                {
                    continue;
                }
                var trans = Instantiate(transactionSlot, container.transform);
                if (item.transactionType == TransactionType.Expense)
                {
                    trans.GetComponent<SetTransactionSlot>().Set(item.category.categoryName, item.senderAccount, -item.amount);

                }
                else if (item.transactionType == TransactionType.Income)
                {
                    trans.GetComponent<SetTransactionSlot>().Set(item.category.categoryName, item.receiverAccount, item.amount);

                }
                transactionsList.Add(trans);
            }
        }
        

    }
    void SetDate()
    {

    }
}
