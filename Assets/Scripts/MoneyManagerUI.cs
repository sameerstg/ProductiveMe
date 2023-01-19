using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class MoneyManagerUI : MonoBehaviour
{
    public TransactionType selectedTransactionType;
    private Account selectedAccount;
    private Account selectedAccount2;
    private Category selectedCategory;
    public DateTimeSetter dateTimeSetter;
    public TMP_InputField amount, note, description;
    public Button addButton, cancelButton;

        public void SetSelectedAcount(Account acount1)
    {
        selectedAccount = acount1;
    }   public void SetSelectedAcount2(Account acount2)
    {
        selectedAccount2 = acount2;
    }
    private void Awake()
    {
        dateTimeSetter = GetComponentInChildren<DateTimeSetter>();
        addButton.onClick.AddListener(() => AddNewTransaction());
        cancelButton.onClick.AddListener(() => RefereshUi());
    }
    public void SetSelectedCategory(Category category)
    {

        selectedCategory = category;
    }
    void RefereshUi()
    {
        selectedAccount = null; selectedCategory = null; amount.text = null;note.text = null; description.text = null;
    }
    public void AddNewTransaction()
    {
        if (string.IsNullOrEmpty(amount.text) || selectedCategory == null||selectedCategory == null)
        {
            return;
        }
        if (selectedTransactionType == TransactionType.Income)
        {
            Transaction transaction = new Income(selectedAccount, dateTimeSetter.dateTime, selectedCategory, float.Parse(amount.text), note.text, description.text);
            MoneyManager._instance.AddTransaction(transaction);

        }
        else if (selectedTransactionType == TransactionType.Expence)
        {
            Transaction transaction = new Expense(selectedAccount,dateTimeSetter.dateTime,selectedCategory,float.Parse(amount.text),note.text,description.text);
            MoneyManager._instance.AddTransaction(transaction);

        }else if (selectedTransactionType == TransactionType.Transfer)
        {
            Transaction transaction = new Transfer(selectedAccount,selectedAccount2,dateTimeSetter.dateTime,selectedCategory,float.Parse(amount.text),note.text,description.text);
            MoneyManager._instance.AddTransaction(transaction);

        }
        RefereshUi();
    }
}
