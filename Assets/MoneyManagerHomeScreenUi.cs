using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManagerHomeScreenUi : MonoBehaviour
{
    private void Start()
    {
        transform.GetChild(0).GetComponent<Button>().onClick.AddListener(()=>OpenTransactionPanel());
        transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() => OpenTransactionHistoryPanel());

    }

    private void OpenTransactionHistoryPanel()
    {
        MoneyManagerUI._instance.moneyTransactionPanel.SetActive(false);
        MoneyManagerUI._instance.transactionHistoryUi.Show();

        
    }

    void OpenTransactionPanel()
    {

        MoneyManagerUI._instance.RefereshUi();
        MoneyManagerUI._instance.transactionHistoryUi.gameObject.SetActive(false);

    }
}
