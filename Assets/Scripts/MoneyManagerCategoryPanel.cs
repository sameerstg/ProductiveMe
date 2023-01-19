using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManagerCategoryPanel : MonoBehaviour
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
        if (MoneyManager._instance.moneyManagerData.category.Count == 0)
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
        foreach (var item in MoneyManager._instance.moneyManagerData.category)
        {
            var slot = Instantiate(this.slot, transform.GetChild(1));
            slot.GetComponentInChildren<TextMeshProUGUI>().text = item.categoryName;
            slot.GetComponent<Button>().onClick.AddListener(() => { MoneyManager._instance.moneyManagerUi.SetSelectedCategory( item); transform.gameObject.SetActive(false); });
            slots.Add(slot);
        }
    }
}
