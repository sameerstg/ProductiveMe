using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public MoneyData moneyData;
    private void Start()
    {
        moneyData = SaveManager._instance.LoadFile<MoneyData>(Managers.MoneyManager);
    }

    internal void StartMoneyManager()
    {
        gameObject.SetActive(true);    
    }
}
[System.Serializable]
public class MoneyData
{
    public List<Account> accounts = new();
}
[System.Serializable]

public class Account
{
    public string name;
    public float balance;
    public List<Transaction> transaction = new();
    public void DoBalance()
    {
        balance = 0;
        foreach (var item in transaction)
        {
            if (item.transactionType == TransactionType.expense)
            {
                balance -= item.amount;
            }
            else if (item.transactionType == TransactionType.income)
            {
                balance += item.amount;
            }
            else if(item.transactionType == TransactionType.transfer)
            {
                if (item.account1 == name)
                {

                }
            }
        }
    }
}
[System.Serializable]

public class Transaction
{
    public float amount;
    public string account1;

    public TransactionType transactionType;

}
[System.Serializable]

public class Expense : Transaction
{

    public Expense(float amount,string account)
    {
        transactionType = TransactionType.expense;
        this.amount = amount;
        this.account1 = account;
    }
}
[System.Serializable]

public class Income : Transaction
{
    public Income(float amount, string account)
    {
        transactionType = TransactionType.income;
        this.amount = amount;
        this.account1 = account;
    }
}
[System.Serializable]
public class Transfer : Transaction
{
    public string account2;

    public Transfer(float amount, string incAccount, string expAccount)
    {
        transactionType = TransactionType.transfer;
        this.amount = amount;
        this.account1 = incAccount;
        this.account2 = expAccount;
    }
}
public enum TransactionType
{
    expense,income,transfer
}
