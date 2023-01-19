using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnterPanel : MonoBehaviour
{
    public string valueCategory;
    public TMP_InputField inputField;
    public Button addButton, cancelButton;

    public void Awake()
    {
        inputField = GetComponentInChildren<TMP_InputField>();
        cancelButton.onClick.AddListener(() => gameObject.SetActive(false));
        addButton.onClick.AddListener(() => OnAdd());
    }
    void OnAdd()
    {
        gameObject.SetActive(false);
        if (valueCategory.Contains( "Account"))
        {
            MoneyManager._instance.moneyManagerData.accounts.Add(new Account(inputField.text));
            

        }
        else if (valueCategory.Contains("Category"))
        {
            MoneyManager._instance.moneyManagerData.category.Add(new Category(inputField.text));
        }
        MoneyManager._instance.SaveData();
        
    }
    private void OnEnable()
    {
        inputField.text = "";
    }
    public void SetCategoryName(string valueCategoryName)
    {
        valueCategory = $"Enter {valueCategoryName}:";
    }
}
