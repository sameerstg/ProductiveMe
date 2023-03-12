using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeButton : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => GameManager._instance.StartMainMenu());
    }
}
