using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManagerBottomMenu : MonoBehaviour
{
    public List<Button> buttons = new();
    private void Start()
    {
        buttons[0].onClick.AddListener(() => MoneyManager._instance.transactionPanel.StartThis());
        buttons[1].onClick.AddListener(() => MoneyManager._instance.transactionHistoryPanel.StartThis());
        buttons[2].onClick.AddListener(() => MoneyManager._instance.transactionPanel.transactionPanelIncomeExpense.StartThis());
    }
}
