using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngineInternal;

public class ShowChoice : MonoBehaviour
{
    public GameObject slot,content;
    List<GameObject> slots = new List<GameObject>();
    public Button addButton;
    public GameObject addPanel;
    public TMP_InputField addText;
    public Button actionCancelButton, actionAddButton;

    private void Start()
    {
        addButton.onClick.AddListener(() => {addPanel.SetActive(true); addText.text = null; });
        actionCancelButton.onClick.AddListener(() => { addPanel.SetActive(false);addText.text = null; });
    }
    void SetAddPanel(string type)
    {
        Debug.Log(type);
        addPanel.SetActive(false);
        if (type.Contains("Account"))
        {
              SetForAddAccount(addText.text); 
        }
        else
        {
            
            SetForAddCategory(addText.text);        
        }
        Show(type);
    }
    public void Show(string type)
    {
        gameObject.SetActive(true);
        Destroyall();
        actionAddButton.onClick.RemoveAllListeners();
        actionAddButton.onClick.AddListener(() => {
            SetAddPanel(type);
        });
        if (type == "Account1")
        {
            addText.GetComponentInChildren<TextMeshProUGUI>().text = "Enter Account";
           
            foreach (var item in MoneyManager._instance.moneyManagerData.accounts)
            {
                if (item != MoneyManager._instance.moneyManagerUi.selectedAccount1)
                {

                    var obj = Instantiate(slot, content.transform);
                    obj.GetComponentInChildren<TextMeshProUGUI>().text = item.name;
                    obj.GetComponent<Button>().onClick.AddListener(() => { gameObject.SetActive(false); MoneyManagerUI._instance.SetAccount1(item); });
                    slots.Add(obj);
                   
                }

            }
        }
        else if(type == "Account2")
        {
           
                addText.GetComponentInChildren<TextMeshProUGUI>().text = "Enter Account";
                       foreach (var item in MoneyManager._instance.moneyManagerData.accounts)
            {
                if (item != MoneyManager._instance.moneyManagerUi.selectedAccount)
                {

                    var obj = Instantiate(slot, content.transform);
                    obj.GetComponentInChildren<TextMeshProUGUI>().text = item.name;
                    obj.GetComponent<Button>().onClick.AddListener(() => { gameObject.SetActive(false); MoneyManagerUI._instance.SetAccount2(item); });
                    slots.Add(obj);


                }

            }
                   }
        else
        {
                addText.GetComponentInChildren<TextMeshProUGUI>().text = "Enter Category";
                                   foreach (var item in MoneyManager._instance.moneyManagerData.category)
            {
                
                    var obj = Instantiate(slot, content.transform);
                    obj.GetComponentInChildren<TextMeshProUGUI>().text = item.categoryName;
                    obj.GetComponent<Button>().onClick.AddListener(() => { gameObject.SetActive(false); MoneyManagerUI._instance.SetCategory(item); });
                slots.Add(obj);

            }
            
        }
    }
    void SetForAddAccount(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return;
        }
        foreach (var item in MoneyManager._instance.moneyManagerData.accounts)
        {
            if (item.name == addText.text)
            {
                return;
            }
        }
        MoneyManager._instance.moneyManagerData.accounts.Add(new Account(name));
        MoneyManager._instance.SaveData();

    }  void SetForAddCategory(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return;
        }
        foreach (var item in MoneyManager._instance.moneyManagerData.category)
        {
            if (item.categoryName == addText.text)
            {
                return;
            }
        }
        MoneyManager._instance.moneyManagerData.category.Add(new Category(name));
        MoneyManager._instance.SaveData();

    }
    void Destroyall()
    {
        print("d");
        if (slots.Count>0)
        {
            foreach (var item in slots)
            {
                Destroy(item);
            }
        }
        slots.Clear();
    }
}
