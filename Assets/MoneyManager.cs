using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MoneyManager : MonoBehaviour, IData
{
    public static MoneyManager _instance;
    SaveManager saveManager;

    [SerializeField] MoneyManagerData moneyManagerData;
    [SerializeField]TransactionType activeTransactionType;
    [SerializeField] Transaction activeTransaction = new Transaction();
    List<InputGetter> inputs = new();
    public enum TransactionType
    {
        Income,Expence,Transfer
    }
    public enum InputType
    {
        amount,note,description
    }
    private void Awake()
    {
        _instance = this;
        inputs = GetComponentsInChildren<InputGetter>().ToList();
    }
    private void Start()
    {
        saveManager = SaveManager._instance;
        for (int i = 0; i < Enum.GetValues(typeof(InputType)).Length; i++)
        {
            inputs[i].inputType = (InputType)(i);
        }
    }
    public void LoadData()
    {
        try
        {
            moneyManagerData = (MoneyManagerData)saveManager.LoadFile(SaveManager.Managers.MoneyManager);
        }
        catch (Exception)
        {
            
        }
    }

    public void SaveData()
    {
        
    }
    public void SetTransactionType(string transType)
    {
        activeTransactionType = Enum.Parse<TransactionType>(transType);
    }
    public void SetInputDataToActiveTransaction(InputType inputType,string data)
    {
        if (inputType==InputType.amount)
        {
            activeTransaction.amount = int.Parse(data);
        }else if (inputType==InputType.description)
        {
            activeTransaction.description = data;
        }else if (inputType==InputType.note)
        {
            activeTransaction.note = data;
        }
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
    [SerializeField]public MoneyManager.TransactionType transactionType;
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

}
public class Income:Transaction
{

}
public class Transfer:Transaction
{

}
public class Category
{
    string categoryName;
}
