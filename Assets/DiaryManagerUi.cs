using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DiaryManagerUi : MonoBehaviour
{
    internal DateTimeSetter dateTimeSetter;
    public TMP_InputField title, diaryContent;
    public GameObject writingPanel;
    public GameObject diaryListParrent;
    public GameObject diarySlotPanel;
    public GameObject slotPrefab;
    public List<GameObject> slots = new List<GameObject>();    

    void Start()
    {
        dateTimeSetter = GetComponentInChildren<DateTimeSetter>();
        writingPanel = dateTimeSetter.transform.parent.gameObject;                       
    }
    internal void  SetDiarySlotPanel(List<DiaryData> diaryData)
    {
        foreach (var item in slots)
        {
            Destroy(item.gameObject);

        }
        slots.Clear();
        foreach (var item in diaryData)
        {
            GameObject slot = Instantiate(slotPrefab, diarySlotPanel.transform);
            slot.GetComponentInChildren<TextMeshProUGUI>().text = item.title.ToString();
        }
    }
   }
