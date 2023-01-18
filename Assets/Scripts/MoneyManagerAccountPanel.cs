using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManagerAccountPanel : MonoBehaviour
{
    public List<GameObject> slots = new();
    public GameObject slot;
    private void OnEnable()
    {
        SetCategories();
    }
    public void SetCategories()
    {
        if (MoneyManager._instance.moneyManagerData.accounts.Count == 0)
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
            var slot = Instantiate(this.slot, transform.GetChild(0));
            slot.GetComponentInChildren<TextMeshProUGUI>().text = item.name;
        }
    }
    
}
