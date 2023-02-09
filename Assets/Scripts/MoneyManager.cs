using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using NaughtyAttributes;
using Unity.VisualScripting;

public class MoneyManager : MonoBehaviour, IData
{
    public static MoneyManager _instance;
    public MoneyManagerUI moneyManagerUi;

    
    public static Action OnDataUpdate;

    public MoneyManagerData moneyManagerData;
    private void Awake()
    {
        _instance = this;
        moneyManagerUi = GetComponent<MoneyManagerUI>();
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
    public void AddTransaction(Transaction transaction)
    {
        moneyManagerData.AddTransaction(transaction);
        print("pass");
        SaveData();
    }
    [Button]
    public void SaveData()
    {
        GameManager._instance.saveManager.SaveFile(Managers.MoneyManager, moneyManagerData);
        if (OnDataUpdate != null)
        {

            OnDataUpdate();
        }
    }
    [Button]
    public void LoadData()
    {
        moneyManagerData = GameManager._instance.saveManager.LoadFile<MoneyManagerData>(Managers.MoneyManager);
        if (moneyManagerData == null)
        {
            moneyManagerData = new();
        }
        if (OnDataUpdate!=null)
        {

            OnDataUpdate();
        }

    }
}
[System.Serializable]
public class MoneyManagerData
{
    public List<Account> accounts = new List<Account>();
    public List<Category> category = new();

   public MoneyManagerData()
    {
        accounts.Add(new("Cash"));
        category.Add(new("Food"));
        category.Add(new("Charity"));
        category.Add(new("Transportaion"));
        category.Add(new("Aparrel"));
        category.Add(new("Lend"));
        category.Add(new("Education"));
        category.Add(new("Other"));
    }
     public void AddTransaction(Transaction transaction)
    {

        if (transaction.receiverAccount != null) {
            foreach (var item in accounts)
            {
                if (item.name == transaction.receiverAccount)
                {
                    item.AddAndCalculateTransaction(transaction);
                }
            }
        
        }
        if(transaction.senderAccount!= null) {  


            foreach (var item in accounts)
            {
                if (item.name == transaction.senderAccount)
                {
                    item.AddAndCalculateTransaction(transaction);
                }
            }
        }
                
        
    }

}
[System.Serializable]
public class Account
{
    public string name;
    public float balance;
     public  List<Transaction> transactions = new List<Transaction>();
  public Account(string name)
    {
        this.name = name;
    }
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
            else if(item.transactionType == TransactionType.Expense)
            {
                balance-= item.amount;
            }
            else
            {
                if (!item.senderAccount.IsUnityNull())
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
    [SerializeField]public string senderAccount;
    [SerializeField]public string receiverAccount;
    [SerializeField]public DateTime dateTime;
        [SerializeField]public float amount;
    [SerializeField]public string note;
    [SerializeField]public  string description;
    [SerializeField]public Category category;
    public TransactionType transactionType;

    
}
public class Expense:Transaction
{
       public Expense(string expenseAccount, DateTime dateTime, Category category, float amount, string note,string description)
    {
        transactionType = TransactionType.Expense;

        this.category = category;
        this.senderAccount = expenseAccount;
        this.dateTime = dateTime;
        this.amount = amount;
        this.note = note;
        this.description = description;

    }
}
public class Income:Transaction
{
      public Income(string receiverAccount, DateTime dateTime, Category category, float amount, string note, string description)
    {
transactionType = TransactionType.Income;
        this.category = category;

        this.receiverAccount = receiverAccount;
        this.dateTime = dateTime;
        this.amount = amount;
        this.note = note;
        this.description = description;
    }
}
public class Transfer:Transaction
{

    public Transfer(string senderAccount, string receiverAccount, DateTime dateTime, Category category, float amount, string note, string description)
    {
transactionType = TransactionType.Transfer;
        this.senderAccount = senderAccount;
        this.receiverAccount = receiverAccount;
        this.dateTime = dateTime;
        this.category = category;
        this.amount = amount;
        this.note = note;
        this.description = description;

    }

}
[System.Serializable]
public class Category
{

    public string categoryName;

    public Category(string categoryName)
    {
        this.categoryName = categoryName;
    }
}
public enum TransactionType
{
    Income, Expense, Transfer
}
public enum InputType
{
    amount, note, description
}
