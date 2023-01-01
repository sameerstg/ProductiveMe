using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiaryListUi : MonoBehaviour
{
    public GameObject diaryListParrent;
    public GameObject diarySlotPanel;
    public GameObject slotPrefab;
    public List<GameObject> slots = new List<GameObject>();
    internal void SetDiarySlotPanel(List<DiaryData> diaryData)
    {
        gameObject.SetActive(true);
        

        foreach (var item in slots)
        {
            Destroy(item.gameObject);

        }
        slots.Clear();
        foreach (var item in diaryData)
        {
            GameObject slot = Instantiate(slotPrefab, diarySlotPanel.transform);
            slot.GetComponentInChildren<TextMeshProUGUI>().text = item.title.ToString();
            slot.name = diaryData.IndexOf(item).ToString();
            slot.GetComponent<Button>().onClick.AddListener(() => OpenDiary(int.Parse(slot.name)));
        }
    }
    public void OpenDiary(int index)
    {
        DiaryManagerUi._instance.EnableDiaryViewMode(index);
    }

}
