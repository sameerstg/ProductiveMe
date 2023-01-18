using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class MoneyManagerCategoryPanel : MonoBehaviour
{
    public List<GameObject> slots = new();
    public GameObject slot;
    private void OnEnable()
    {
        SetCategories();
    }
    public void SetCategories()
    {
        if (MoneyManager._instance.moneyManagerData.category.Count ==0)
        {
            return;
        }
        if (slots.Count>0)
        {
            foreach (var item in slots)
            {

                Destroy(item.gameObject);

            }
            slots.Clear();
        }
        
        foreach (var item in MoneyManager._instance.moneyManagerData.category)
        {
            var slot = Instantiate(this.slot, transform.GetChild(0));
            slot.GetComponentInChildren<TextMeshProUGUI>().text = item.categoryName;
        }
    }    
}
