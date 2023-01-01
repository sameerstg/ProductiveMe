using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using NaughtyAttributes;

public class MoneyManager : MonoBehaviour, IData
{
    public static MoneyManager _instance;
   

    MoneyManagerData moneyManagerData;
    private void Awake()
    {
        _instance = this;
    }
    [Button]
    public void SaveData()
    {
        GameManager._instance.saveManager.SaveFile(Managers.MoneyManager, moneyManagerData);
    }
    [Button]
    public void LoadData()
    {
        moneyManagerData = GameManager._instance.saveManager.LoadFile<MoneyManagerData>(Managers.MoneyManager);

    }
}
[System.Serializable]
public class MoneyManagerData
{
    [field:SerializeField]List<Account> accounts = new List<Account>();
}
[System.Serializable]
public class Account
{
    [SerializeField] string name;
    [SerializeField] float balance;
    [SerializeField] internal List<Transaction> transactions = new List<Transaction>();
    
}
[System.Serializable]
public class Transaction
{
    [SerializeField]public Account senderAccount;
    [SerializeField]public Account receiverAccount;
    [SerializeField]public DateTime dateTime;
    [SerializeField]public Category category;
    [SerializeField]public float amount;
    [SerializeField]public string note;
    [SerializeField]public  string description;

    
}
public class Expense:Transaction
{
    internal const TransactionType transactionType = TransactionType.Expence;
    public Expense(Account expenseAccount, DateTime dateTime, Category category, float amount, string note)
    {
        this.senderAccount = expenseAccount;
        this.dateTime = dateTime;
        this.category = category;
        this.amount = amount;
        this.note = note;
    }
}
public class Income:Transaction
{
    internal const TransactionType transactionType = TransactionType.Income;
    public Income( Account receiverAccount, DateTime dateTime, Category category, float amount, string note)
    {
        this.receiverAccount = receiverAccount;
        this.dateTime = dateTime;
        this.category = category;
        this.amount = amount;
        this.note = note;
    }
}
public class Transfer:Transaction
{
    internal const TransactionType transactionType = TransactionType.Transfer;
    public Transfer(Account senderAccount, Account receiverAccount, DateTime dateTime, Category category, float amount, string note)
    {
        this.senderAccount = senderAccount;
        this.receiverAccount = receiverAccount;
        this.dateTime = dateTime;
        this.category = category;
        this.amount = amount;
        this.note = note;
    }

}
public class Category
{
    internal string categoryName;
}
public enum TransactionType
{
    Income, Expence, Transfer
}
public enum InputType
{
    amount, note, description
}
