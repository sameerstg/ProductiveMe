using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MoneyManagerUI : MonoBehaviour
{
    public TransactionType selectedTransactionType;
    public Account selectedAccount;
    public Category selectedCategory;
    public DateTimeSetter dateTimeSetter;
    public TMP_InputField amount, note, description;
    private void Awake()
    {
        dateTimeSetter = GetComponentInChildren<DateTimeSetter>();
    }
    public void AddNewTransaction()
    {
        if (selectedTransactionType == TransactionType.Income)
        {
            Transaction transaction = new Income(selectedAccount, dateTimeSetter.dateTime, selectedCategory, float.Parse(amount.text), note.text, description.text);
            MoneyManager._instance.AddTransaction(transaction);

        }
        else if (selectedTransactionType == TransactionType.Expence)
        {
            Transaction transaction = new Income(selectedAccount,dateTimeSetter.dateTime,selectedCategory,float.Parse(amount.text),note.text,description.text);
            MoneyManager._instance.AddTransaction(transaction);

        }else if (selectedTransactionType == TransactionType.Income)
        {
            Transaction transaction = new Income(selectedAccount,dateTimeSetter.dateTime,selectedCategory,float.Parse(amount.text),note.text,description.text);
            MoneyManager._instance.AddTransaction(transaction);

        }
    }
}
