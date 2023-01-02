using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakingTransactionPanelUi : MonoBehaviour
{
    public List<GameObject> allOptionsGo = new List<GameObject>();
    public Button accountButton, categoryButton;
    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            allOptionsGo.Add(transform.GetChild(i).gameObject);
        } 
    }
    public void ToggleAccountPanel()
    {
        
    }
    public void ToggleCategoryPanel()
    {

    }
    public void TurnOffAllOptions()
    {
        foreach (GameObject go in allOptionsGo)
        {
            go.SetActive(false);
        }         
    }
}
