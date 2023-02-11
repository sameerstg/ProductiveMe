using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Newtonsoft.Json;

public class MoneyManagerUI : MonoBehaviour
{
    public static MoneyManagerUI _instance;

    public GameObject transactionPanel;
    public GameObject menuPanel;
    public TransactionHistoryUi transactionHistoryUi;

         private void Awake()
    {
        _instance = this;
        addButton.onClick.AddListener(() => AddNewTransaction());
        account1Button.onClick.AddListener(() => showChoice.Show("Account1"));
        account2Button.onClick.AddListener(() => showChoice.Show("Account2"));
        categoryButton.onClick.AddListener(() => showChoice.Show("Category"));
        cancelButton.onClick.AddListener(() => RefereshUi());
            }
    private void Start()
    {
        HideAllPanels();
        transactionHistoryUi.Show();
        
    }
    void HideAllPanels()
    {
        transactionPanel.SetActive(false);
        transactionHistoryUi.gameObject.SetActive(false);
    }
    #region Transaction Section Functionalities
    public GameObject moneyTransactionPanel;
    public TransactionType selectedTransactionType;
    public Button account1Button, account2Button, categoryButton;
    internal Account selectedAccount;
    internal Account selectedAccount1;
    public Category selectedCategory;
    public DateTimeSetter dateTimeSetter;
    public TMP_InputField amount, note, description;
    public Button addButton, cancelButton;
    public ShowChoice showChoice;
      public  void RefereshUi()
    {
        moneyTransactionPanel.SetActive(true);
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
            Transaction transaction = new Income(selectedAccount.name, dateTimeSetter.dateTime, selectedCategory, float.Parse(amount.text), note.text, description.text);
            MoneyManager._instance.AddTransaction(transaction);

        }
        else if (selectedTransactionType == TransactionType.Expense)
        {
            Transaction transaction = new Expense(selectedAccount.name, dateTimeSetter.dateTime,selectedCategory,float.Parse(amount.text),note.text,description.text);
            MoneyManager._instance.AddTransaction(transaction);

        }else if (selectedTransactionType == TransactionType.Transfer)
        {
            Transaction transaction = new Transfer(selectedAccount.name, selectedAccount1.name,dateTimeSetter.dateTime,selectedCategory,float.Parse(amount.text),note.text,description.text);
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

    #endregion

}
