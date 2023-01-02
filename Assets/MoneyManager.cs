using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using NaughtyAttributes;

public class MoneyManager : MonoBehaviour, IData
{
    public static MoneyManager _instance;
   

   public  MoneyManagerData moneyManagerData;
    private void Awake()
    {
        _instance = this;
    }
    private void Start()
    {
        LoadData();
    }
    [Button]
    void DebugBalance()
    {
        foreach (var item in moneyManagerData.accounts)
        {
            item.CalculateBalance();
        }
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
    public List<Account> accounts = new List<Account>();
    public List<Category> category = new();

    
     public void AddTransaction(Transaction transaction)
    {
        
        if(transaction.senderAccount!= null) { transaction.senderAccount.AddAndCalculateTransaction(transaction); }
        if (transaction.receiverAccount != null) { transaction.receiverAccount.AddAndCalculateTransaction(transaction); }
        
    }

}
[System.Serializable]
public class Account
{
    public string name;
    public float balance;
     public  List<Transaction> transactions = new List<Transaction>();
   
    public void AddAndCalculateTransaction(Transaction transaction)
    {
           transactions.Add(transaction);

        CalculateBalance();
    }
    public  void CalculateBalance()
    {
        balance = 0f;
        foreach (var item in transactions)
        {
            if (item.transactionType == TransactionType.Income)
            {
                balance += item.amount;
            }
            else if(item.transactionType == TransactionType.Expence)
            {
                balance-= item.amount;
            }
            else
            {
                if (item.senderAccount == this)
                {
                    balance -= item.amount;
                }
                else
                {
                    balance += item.amount;
                }
            }
        }
    }
   }
[System.Serializable]
public class Transaction
{
    [SerializeField]public Account senderAccount;
    [SerializeField]public Account receiverAccount;
    [SerializeField]public DateTime dateTime;
        [SerializeField]public float amount;
    [SerializeField]public string note;
    [SerializeField]public  string description;
    [SerializeField]public Category category;
    public TransactionType transactionType;

    
}
public class Expense:Transaction
{
       public Expense(Account expenseAccount, DateTime dateTime, Category category, float amount, string note)
    {
        transactionType = TransactionType.Expence;

        this.senderAccount = expenseAccount;
        this.dateTime = dateTime;
        this.amount = amount;
        this.note = note;
    }
}
public class Income:Transaction
{
      public Income( Account receiverAccount, DateTime dateTime, Category category, float amount, string note)
    {
transactionType = TransactionType.Income;

        this.receiverAccount = receiverAccount;
        this.dateTime = dateTime;
        this.amount = amount;
        this.note = note;
    }
}
public class Transfer:Transaction
{

    public Transfer(Account senderAccount, Account receiverAccount, DateTime dateTime, Category category, float amount, string note)
    {
transactionType = TransactionType.Transfer;
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
