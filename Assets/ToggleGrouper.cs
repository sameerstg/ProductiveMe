using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleGrouper : MonoBehaviour
{
/*    public Color pressedColor, deselectColor;
    public List<Button> buttons = new();
    public List<Image> images = new();
    void Awake()
    {
        pressedColor = transform.GetChild(0).GetComponent<Image>().color;
        deselectColor = transform.GetChild(1).GetComponent<Image>().color;
        for (int i = 0; i < transform.childCount; i++)
        {
            buttons.Add(transform.GetChild(i).GetComponent<Button>());
            images.Add(transform.GetChild(i).GetComponent<Image>());
            int x = i;

            buttons[i].onClick.AddListener(() => { OnPressed(images[x]); });
            transform.GetChild(i).name = ((MoneyManager.TransactionType)(i)).ToString();
        }
        
    }
    void OnPressed(Image obj)
    {
        foreach (var item in images)
        {
            item.color = deselectColor;

        }
        obj.color = pressedColor;
        MoneyManager._instance.SetTransactionType(obj.gameObject.name);
    }
*/    
    
}
