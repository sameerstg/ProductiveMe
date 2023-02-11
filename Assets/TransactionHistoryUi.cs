using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TransactionHistoryUi : MonoBehaviour
{
    public GameObject transactionSlot;
    public GameObject container;
    public List<GameObject> transactionsList = new (); 
    
    public Button leftMonthButton,  rightMonthButton;
    public TextMeshProUGUI monthText;
    DateTime date;
    private void Start()
    {
        leftMonthButton.onClick.AddListener(() => { date= date.AddMonths(-1); Referesh(); });
        rightMonthButton.onClick.AddListener(() => { date= date.AddMonths(+1); Referesh(); });
    }
    public void Show()
    {
        date = DateTime.Now;
        gameObject.SetActive(true);
        Referesh();


    }
    public void Referesh()
    {

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
                if (date.Month != (item.dateTime).Month)
                {
                    continue;
                }
                var trans = Instantiate(transactionSlot, container.transform);
                if (item.transactionType == TransactionType.Expense)
                {
                    trans.GetComponent<SetTransactionSlot>().Set(item.category.categoryName, item.senderAccount, -item.amount,date.GetDateTimeFormats()[0]);

                }
                else if (item.transactionType == TransactionType.Income)
                {
                    trans.GetComponent<SetTransactionSlot>().Set(item.category.categoryName, item.receiverAccount, item.amount, date.GetDateTimeFormats()[0]);

                }
                transactionsList.Add(trans);
            }
        }
        

    }
    void SetDate()
    {
        var d = date.GetDateTimeFormats();
        var e = date.GetDateTimeFormats()[d.Length - 1];

        monthText.text = e.Substring(0, e.IndexOf(" "));
    }
}
