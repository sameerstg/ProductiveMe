using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoosingPanel : MonoBehaviour
{
    public GameObject choosingSlot;
    public List<GameObject> slots = new();
    public GameObject parent;
    public void Referesh(List<string> texts, TextMeshProUGUI text,Image image) 
    {
        

        gameObject.SetActive(true);
        foreach (var item in slots)
        {
            Destroy(item.gameObject);

        }
        slots.Clear();
        foreach (var item in texts)
        {
            var s = Instantiate(choosingSlot, parent.transform);
            s.GetComponentInChildren<TextMeshProUGUI>().text = item;
            s.GetComponent<Button>().onClick.AddListener(() => OnClickOnSlot(text,item,image));
            slots.Add(s);

        }
    }
    public void OnClickOnSlot(TextMeshProUGUI text,string str,Image image)
    {
        text.text = str;
        
        ColorPalette.ChangeColor(image, ColorType.secondary);
        gameObject.SetActive(false);
    }
}
public delegate void ChosePanel(TextMeshProUGUI text);
