using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Globalization;

public class TransactionPanelIncomeExpense : MonoBehaviour
{
    public TextMeshProUGUI dateInp;
    public TextMeshProUGUI account1Inp,  categoryInp;
    public TMP_InputField amountInp, noteInp, descriptionInp;
    public Account account1;
    public Category category;
    public float amount;
    public string note, description;


    public Button saveButton,cancelButton;
    public ChoosingPanel choosingPanel;
    public CalenderManager calenderManager;

    public void Referesh()
    {
        dateInp.text = DateTime.Now.Date.GetDateTimeFormats()[6];

        account1Inp.text = "Tap to select account";
        categoryInp.text = "Tap to select category";
        amountInp.text = "";
        noteInp.text = "";
        descriptionInp.text = "";

        account1 = null;
        category = null;
        amount = 0;
        note = "";
        description = "";

    }

    public void Start()
    {
        dateInp.transform.parent.GetComponent<Button>().onClick.AddListener(() => calenderManager.gameObject.SetActive(true));
        account1Inp.transform.parent.GetComponent<Button>().onClick.AddListener(() => StartChoosingPanelForAccount(account1Inp));
        categoryInp.transform.parent.GetComponent<Button>().onClick.AddListener(() => StartChoosingPanelForCategory(categoryInp));
        saveButton.onClick.AddListener(()=>SaveTransaction());

        cancelButton.onClick.AddListener(()=>CancelTransaction());
        StartThis();
         }
    public void StartThis()
    {

        gameObject.SetActive(true);
        choosingPanel.gameObject.SetActive(false);
        ChangeAllChoosingPanelColorToSecondary();

        Referesh();

    }

    private void SaveTransaction()
    {
        if (string.IsNullOrEmpty(dateInp.text)) return;

        if ( account1Inp.text.ToString().Contains("Tap ")) return;
        if (categoryInp.text.ToString().Contains("Tap "))return;
        if (amountInp.text.ToString().Contains("Tap ")) return;
        if (MoneyManager._instance.transactionPanel.transactionTypeButtonPanel.transactionTypeSelected == TransactionType.income)
        {
            Income income = new Income(DateTime.ParseExact(dateInp.text, "dd-MMM-yy", CultureInfo.InvariantCulture), float.Parse(amountInp.text), account1Inp.text, noteInp.text, descriptionInp.text);

            MoneyManager._instance.moneyData.AddTransaction( income);
        }else if (MoneyManager._instance.transactionPanel.transactionTypeButtonPanel.transactionTypeSelected == TransactionType.expense)
        {
            Expense expense = new Expense(DateTime.ParseExact(dateInp.text, "dd-MMM-yy", CultureInfo.InvariantCulture), float.Parse(amountInp.text), account1Inp.text, noteInp.text, descriptionInp.text);
            MoneyManager._instance.moneyData.AddTransaction(expense);

        }


        Referesh();
    }

    void CancelTransaction()
    {
        Referesh();
    }
    void StartChoosingPanelForCategory(TextMeshProUGUI text)
    {
        ChangeAllChoosingPanelColorToSecondary();
        ColorPalette.ChangeColor(text.GetComponentInParent<Image>(), ColorType.primary);
        List<string> categories = new List<string>();
        if (MoneyManager._instance.transactionPanel.transactionTypeButtonPanel.transactionTypeSelected == TransactionType.income)
        {
            categories.AddRange(MoneyManager._instance.moneyData.categories.FindAll (x => x.transactionType == TransactionType.income ).Select(m=>m.categoryName));
            
                
                }
        else if (MoneyManager._instance.transactionPanel.transactionTypeButtonPanel.transactionTypeSelected == TransactionType.expense)
        {
            categories.AddRange(MoneyManager._instance.moneyData.categories.FindAll (x => x.transactionType == TransactionType.expense ).Select(m=>m.categoryName));
        }
        choosingPanel.Referesh(categories, text, text.GetComponentInParent<Image>());
    }
    void StartChoosingPanelForAccount(TextMeshProUGUI text)
    {
        ChangeAllChoosingPanelColorToSecondary();
        ColorPalette.ChangeColor(text.GetComponentInParent<Image>(), ColorType.primary);
                      choosingPanel.Referesh(MoneyManager._instance.moneyData.GetAllAccountsName(), text, text.GetComponentInParent<Image>());
    }
    void ChangeAllChoosingPanelColorToSecondary()
    {
        choosingPanel.gameObject.SetActive(false);
        
        ColorPalette.ChangeColor(account1Inp.GetComponentInParent<Image>(), ColorType.secondary);
        ColorPalette.ChangeColor(categoryInp.GetComponentInParent<Image>(), ColorType.secondary);
    }
}
