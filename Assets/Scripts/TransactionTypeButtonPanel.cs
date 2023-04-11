using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TransactionTypeButtonPanel : MonoBehaviour
{
    public List<Image> images = new();
    public TransactionType transactionTypeSelected;
    private void Start()
    {
        images[0].GetComponent<Button>().onClick.AddListener(() => OpenTransactionPanel(TransactionType.income));
        images[1].GetComponent<Button>().onClick.AddListener(() => OpenTransactionPanel(TransactionType.expense));
        images[2].GetComponent<Button>().onClick.AddListener(() => OpenTransactionPanel(TransactionType.transfer));
        transactionTypeSelected = TransactionType.income;
        Referesh();

    }
    public void Referesh()
    {


        images[0].color = ColorPalette.secondaryColor;
        images[1].color = ColorPalette.secondaryColor;

        images[2].color = ColorPalette.secondaryColor;
        MoneyManager._instance.transactionPanel.transactionPanelIncomeExpense.gameObject.SetActive(false);
        MoneyManager._instance.transactionPanel.TransactionPanelTransfer.gameObject.SetActive(false);
        if (transactionTypeSelected == TransactionType.income)
        {
            images[0].color = ColorPalette.primaryColor;
            MoneyManager._instance.transactionPanel.transactionPanelIncomeExpense.StartThis();

        }
        else if (transactionTypeSelected == TransactionType.expense)
        {
            images[1].color = ColorPalette.primaryColor;
            MoneyManager._instance.transactionPanel.transactionPanelIncomeExpense.StartThis();


        }
        else
        {
            images[2].color = ColorPalette.primaryColor;
            MoneyManager._instance.transactionPanel.TransactionPanelTransfer.StartThis();

        }

    }
    public void OpenTransactionPanel(TransactionType transactionType)
    {
        if (transactionTypeSelected == transactionType)
        {
            return;
        }
        transactionTypeSelected = transactionType;
        Referesh();
    }
}
