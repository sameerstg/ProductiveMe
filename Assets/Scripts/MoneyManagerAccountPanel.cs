using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManagerAccountPanel : MonoBehaviour
{
    public List<GameObject> slots = new();
    public GameObject slot;
    private void OnEnable()
    {

        MoneyManager.OnDataUpdate += SetCategories;
        SetCategories();
    }
    private void OnDisable()
    {
        MoneyManager.OnDataUpdate -= SetCategories;

    }
    public void SetCategories()
    {
        if (MoneyManager._instance.moneyManagerData.accounts.Count == 0 )
        {
            return;
        }
        if (slots.Count > 0)
        {
            foreach (var item in slots)
            {

                Destroy(item.gameObject);

            }
            slots.Clear();
        }
        foreach (var item in MoneyManager._instance.moneyManagerData.accounts)
        {
            var slot = Instantiate(this.slot, transform.GetChild(1));
            slot.GetComponentInChildren<TextMeshProUGUI>().text = item.name;
            slot.GetComponent<Button>().onClick.AddListener(() => { MoneyManager._instance.moneyManagerUi.SetSelectedAcount(item);transform.gameObject.SetActive(false); });
            slots.Add(slot); 
        }
    }
    
}
