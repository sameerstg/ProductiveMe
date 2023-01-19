using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddChoice : MonoBehaviour
{
    public GameObject enterChoicePanel;
    public string choiceEnterCategory;

    public void Start()
    {
        var go = GetComponent<Button>(); go.onClick.AddListener(() => enterChoicePanel.SetActive(true));
        enterChoicePanel.GetComponent<EnterPanel>().SetCategoryName(choiceEnterCategory);
    }
}
