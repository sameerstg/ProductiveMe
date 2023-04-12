using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransactionPanel : MonoBehaviour
{
    public TransactionTypeButtonPanel transactionTypeButtonPanel;
    public TransactionPanelIncomeExpense transactionPanelIncomeExpense;
    public TransactionPanelTransfer TransactionPanelTransfer;
   
   
   
    public void StartThis()
    {
        MoneyManager._instance.CloseAllPanel();

        gameObject.SetActive(true);
        CloseAllPanels();
        transactionPanelIncomeExpense.StartThis();
    }
    
    public void CloseAllPanels()
    {
        transactionPanelIncomeExpense.gameObject.SetActive(false);
        TransactionPanelTransfer.gameObject.SetActive(false);
    }

}
