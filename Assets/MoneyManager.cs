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
    List<InputGetter> inputs = new();
    public string amount, note, description;
    public enum TransactionType
    {
        Income,Expence,Transfer
    }
    private void Awake()
    {
        _instance = this;
        inputs = GetComponentsInChildren<InputGetter>().ToList();
    }
    private void Start()
    {
        saveManager = SaveManager._instance;
        foreach (var item in inputs)
        {
            if (item.gameObject.name == "amount") {
                amount = item.inputField.text;
            }else if (item.gameObject.name == "note") {
                note = item.inputField.text;
            }else if (item.gameObject.name == "description") {
                description = item.inputField.text;
            }
            
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
public class Transaction
{
    [SerializeField]MoneyManager.TransactionType transactionType;
    [SerializeField]Account senderAccount;
    [SerializeField]Account receiverAccount;
    [SerializeField]DateTime dateTime;
    [SerializeField]Category category;
    [SerializeField]float amount;
    [SerializeField]string note;
    [SerializeField] string description;

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
