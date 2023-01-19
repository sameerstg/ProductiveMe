using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowChoice : MonoBehaviour
{
    public GameObject slot,content;
    List<GameObject> slots = new List<GameObject>();
    public void Show(string type)
    {
        gameObject.SetActive(true);
        Destroyall();
        if (type == "Account1")
        {
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
            foreach (var item in MoneyManager._instance.moneyManagerData.accounts)
            {
                if (item != MoneyManager._instance.moneyManagerUi.selectedAccount1)
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
            foreach (var item in MoneyManager._instance.moneyManagerData.category)
            {
                
                    var obj = Instantiate(slot, content.transform);
                    obj.GetComponentInChildren<TextMeshProUGUI>().text = item.categoryName;
                    obj.GetComponent<Button>().onClick.AddListener(() => { gameObject.SetActive(false); MoneyManagerUI._instance.SetCategory(item); });
                slots.Add(obj);

            }
        }
    }
    void Destroyall()
    {
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
