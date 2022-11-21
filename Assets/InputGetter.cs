using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InputGetter : MonoBehaviour
{
    public TMP_InputField inputField;
    private void Awake()
    {
        inputField = GetComponent<TMP_InputField>();   
    }
}
