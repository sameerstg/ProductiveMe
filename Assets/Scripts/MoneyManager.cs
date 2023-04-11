using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager _instance;
    public TransactionPanel transactionPanel;
    public TransactionHistoryPanel transactionHistoryPanel;

    public MoneyData moneyData;

    private void Awake()
    {
        _instance = this;
    }
    private void Start()
    {
        moneyData = SaveManager._instance.LoadFile<MoneyData>(Managers.MoneyManager);
        if (moneyData == null)
        {
            moneyData = new();
            SaveData();
        }

    }
    public void SaveData()
    {
        SaveManager._instance.SaveFile(Managers.MoneyManager, moneyData);
    }
    internal void StartMoneyManager()
    {
        gameObject.SetActive(true);
        transactionPanel.StartThis();

    }
    public void CloseAllPanel()
    {
        transactionHistoryPanel.gameObject.SetActive(false);
        transactionPanel.gameObject.SetActive(false);
    }
}
[System.Serializable]
public class MoneyData
{
    public List<Account> accounts = new();
       public List<Category> categories = new();
    public MoneyData()
    {
        accounts.Add(new Account("Cash", 0));
        accounts.Add(new Account("Credit Card", 0));

        categories.Add(new Category("Salary",TransactionType.income));
        categories.Add(new Category("Petty Cash", TransactionType.income));
        categories.Add(new Category("Allowance", TransactionType.income));
        categories.Add(new Category("Freelance", TransactionType.income));
        categories.Add(new Category("Pocket Money", TransactionType.income));

        categories.Add(new Category("Food", TransactionType.expense));
        categories.Add(new Category("Apparel", TransactionType.expense));
        categories.Add(new Category("Household", TransactionType.expense));
        categories.Add(new Category("Transport",TransactionType.expense));

        categories.Add(new Category("Withdraw",TransactionType.transfer));
    }
    public Account GetAccount(string accountName)
    {
        foreach (var item in accounts)
        {
            if (item.name == accountName)
            {
                return item;
            }
        }
        return null;
    }
    public void AddTransaction(Transaction transaction)
    {
        GetAccount(transaction.account1).AddTransaction(transaction);
        

        if (transaction.transactionType == TransactionType.transfer)
        {
            GetAccount(transaction.account2).AddTransaction(transaction);

        }
        MoneyManager._instance.SaveData();
    }
    public List<string> GetAllAccountsName()
    {
        List<String> accountsName = new();
        foreach (var item in accounts)
        {
            accountsName.Add(item.name);
        }
        return accountsName;
    }
    
}
[System.Serializable]

public class Account
{
    public string name;
    public float balance;
    public List<Transaction> transaction = new();
    public Account(string name,float balance)
    {
        this.name = name;
        //transaction.Add(new Transaction() { amount = balance ,transactionType  = TransactionType.income,note= "Default"});
    }
    public void AddTransaction(Transaction transaction)
    {
        this.transaction.Add(transaction);
        DoBalance();
    }
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
   public DateTime date;
    public float amount;
    public string account1;
    public string account2;

    public string note, description;
    public TransactionType transactionType;
   
}
[System.Serializable]

public class Expense : Transaction
{

    public Expense(DateTime date,float amount,string account,string note,string description)
    {
        this.date = date;
        transactionType = TransactionType.expense;
        this.amount = amount;
        this.account1 = account;
        this.note = note;
        this.description = description;
    }
}
[System.Serializable]

public class Income : Transaction
{
    public Income(DateTime date,float amount, string account, string note, string description)
    {
        this.date = date;
        transactionType = TransactionType.income;
        this.amount = amount;
        this.account1 = account;
        this.note = note;
        this.description = description;
    }
}
[System.Serializable]
public class Transfer : Transaction
{

    public Transfer(DateTime date,float amount, string incAccount, string expAccount, string note, string description)
    {
        this.date = date;
        transactionType = TransactionType.transfer;
        this.amount = amount;
        this.account1 = expAccount;
        this.account2 = incAccount;
        this.note = note;
        this.description = description;
    }
}
public enum TransactionType
{
    expense,income,transfer
}
[System.Serializable]
public class Category
{
    public string categoryName;
    public TransactionType transactionType;

    public Category(string categoryName,TransactionType transactionType)
    {
        this.categoryName = categoryName;
        this.transactionType = transactionType;
    }
}
