using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InputGetter : MonoBehaviour
{
    public TMP_InputField inputField;
    public MoneyManager.InputType inputType;
    private void Awake()
    {
        inputField = GetComponent<TMP_InputField>();   
        inputField.onValueChanged.AddListener((value) => { SendValue(value);});
    }
    void SendValue(string value)
    {
        MoneyManager._instance.SetInputDataToActiveTransaction(inputType, value);
    }
}
