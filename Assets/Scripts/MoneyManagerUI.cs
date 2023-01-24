using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
using System;

public class MoneyManagerUI : MonoBehaviour
{
    public static MoneyManagerUI _instance; 
    public GameObject moneyTransactionPanel;
    public TransactionType selectedTransactionType;
    public Button account1Button, account2Button,categoryButton;
    internal Account selectedAccount;
    internal Account selectedAccount1;
    public Category selectedCategory;
    public DateTimeSetter dateTimeSetter;
    public TMP_InputField amount, note, description;
    public Button addButton, cancelButton;
    public ShowChoice showChoice;

         private void Awake()
    {
        _instance = this;
        dateTimeSetter = GetComponentInChildren<DateTimeSetter>();
        addButton.onClick.AddListener(() => AddNewTransaction());
        account1Button.onClick.AddListener(() => showChoice.Show("Account1"));
        account2Button.onClick.AddListener(() => showChoice.Show("Account2"));
        categoryButton.onClick.AddListener(() => showChoice.Show("Category"));
        cancelButton.onClick.AddListener(() => RefereshUi());
    }
    public void SetSelectedCategory(Category category)
    {

        selectedCategory = category;
    }
    void RefereshUi()
    {
        selectedAccount = null; selectedCategory = null; amount.text = null;note.text = null; description.text = null;
        if (selectedTransactionType == TransactionType.Income)
        {

            account1Button.GetComponentInChildren<TextMeshProUGUI>().text = "Receiving Account : ";
        }
        else if (selectedTransactionType == TransactionType.Expense)
        {
            account1Button.GetComponentInChildren<TextMeshProUGUI>().text = "Sender Account : ";

        }
        else
        {
            account1Button.GetComponentInChildren<TextMeshProUGUI>().text = "Sender Account : ";
            account2Button.GetComponentInChildren<TextMeshProUGUI>().text = "Receiving Account : ";

        }
        categoryButton.GetComponentInChildren<TextMeshProUGUI>().text = "Category : ";

    }
    internal void SetAccount1(Account item)
    {
        if (selectedTransactionType == TransactionType.Income)
        {

            account1Button.GetComponentInChildren<TextMeshProUGUI>().text = "Receiving Account : "+item.name;
        }
        else if (selectedTransactionType == TransactionType.Expense)
        {
            
            account1Button.GetComponentInChildren<TextMeshProUGUI>().text = "Sender Account : "+item.name;

        }
        else
        {
            account1Button.GetComponentInChildren<TextMeshProUGUI>().text = "Sender Account : " + item.name;

        }
        selectedAccount = item; 
    }

    internal void SetAccount2(Account item)
    {
        selectedAccount1 = item;
        account2Button.GetComponentInChildren<TextMeshProUGUI>().text = "Receiving Account : " + item.name;
    }

    internal void SetCategory(Category item)
    {
        selectedCategory = item;
        categoryButton.GetComponentInChildren<TextMeshProUGUI>().text = "Category : " + item.categoryName;
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
        else if (selectedTransactionType == TransactionType.Expense)
        {
            Transaction transaction = new Expense(selectedAccount,dateTimeSetter.dateTime,selectedCategory,float.Parse(amount.text),note.text,description.text);
            MoneyManager._instance.AddTransaction(transaction);

        }else if (selectedTransactionType == TransactionType.Transfer)
        {
            Transaction transaction = new Transfer(selectedAccount,selectedAccount1,dateTimeSetter.dateTime,selectedCategory,float.Parse(amount.text),note.text,description.text);
            MoneyManager._instance.AddTransaction(transaction);

        }
        RefereshUi();
    }

    internal void SetTransactionType(TransactionType transactionType)
    {
        selectedTransactionType = transactionType;
        if (selectedTransactionType == TransactionType.Transfer)
        {
            account2Button.gameObject.SetActive(true);
        }
        else
        {
            account2Button.gameObject.SetActive(false);

        }
        RefereshUi(); 

    }

    
}
