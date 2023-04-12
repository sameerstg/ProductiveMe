using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TransactionPanelTransfer : MonoBehaviour
{
    public TextMeshProUGUI dateInp;
    public TextMeshProUGUI account1Inp, account2Inp, categoryInp;
    public TMP_InputField amountInp, noteInp, descriptionInp;
    public Account account1, account2;
    public float amount;
    public Category category;
    public string note, description;
    public Button saveButton,cancelButton;
    public ChoosingPanel choosingPanel;
    public CalenderManager calenderManager;
    public void Referesh()
    {
        dateInp.text = DateTime.Now.Date.GetDateTimeFormats()[6];
        account1Inp.text = "Tap to select account";
        account2Inp.text = "Tap to select account";
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

    internal void Start()
    {
        dateInp.transform.parent.GetComponent<Button>().onClick.AddListener(() => calenderManager.gameObject.SetActive(true));
        account1Inp.transform.parent.GetComponent<Button>().onClick.AddListener(() => StartChoosingPanelForAccount(account1Inp));
        account2Inp.transform.parent.GetComponent<Button>().onClick.AddListener(() => StartChoosingPanelForAccount(account2Inp));
        categoryInp.transform.parent.GetComponent<Button>().onClick.AddListener(() => StartChoosingPanelForCategory(categoryInp));
        

        saveButton.onClick.AddListener(() => SaveTransaction());
        cancelButton.onClick.AddListener(() => CancelTransaction());
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
        if (account1Inp.text.ToString().Contains("Tap")) return;
        if (account2Inp.text.ToString().Contains("Tap")) return;

        if (categoryInp.text.ToString().Contains("Tap")) return;
        if (MoneyManager._instance.transactionPanel.transactionTypeButtonPanel.transactionTypeSelected == TransactionType.transfer)
        {

            Transfer transfer = new Transfer(DateTime.ParseExact(dateInp.text, "dd-MMM-yy", CultureInfo.InvariantCulture), float.Parse(amountInp.text), account1Inp.text,account2Inp.text, noteInp.text, descriptionInp.text);
            MoneyManager._instance.moneyData.AddTransaction( transfer);

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
                 if (MoneyManager._instance.transactionPanel.transactionTypeButtonPanel.transactionTypeSelected == TransactionType.transfer)
        {
            categories.AddRange(MoneyManager._instance.moneyData.categories.FindAll(x => x.transactionType == TransactionType.transfer).Select(m => m.categoryName));

        }
        choosingPanel.Referesh(categories, text, text.GetComponentInParent<Image>());
    }
    void StartChoosingPanelForAccount(TextMeshProUGUI text)
    {
        ChangeAllChoosingPanelColorToSecondary();
        ColorPalette.ChangeColor(text.GetComponentInParent<Image>(),ColorType.primary);
        choosingPanel.Referesh(MoneyManager._instance.moneyData.GetAllAccountsName(), text, text.GetComponentInParent<Image>());
    }
    void ChangeAllChoosingPanelColorToSecondary()
    {
        choosingPanel.gameObject.SetActive(false);

        ColorPalette.ChangeColor(account1Inp.GetComponentInParent<Image>(), ColorType.secondary);
        ColorPalette.ChangeColor(account2Inp.GetComponentInParent<Image>(), ColorType.secondary);
        ColorPalette.ChangeColor(categoryInp.GetComponentInParent<Image>(), ColorType.secondary);
    }
}
