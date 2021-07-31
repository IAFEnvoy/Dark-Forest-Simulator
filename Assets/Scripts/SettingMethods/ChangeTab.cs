using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTab : MonoBehaviour
{
    public int num = -1;
    public GameObject[] tabs = new GameObject[5];
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject tab in tabs)
        {
            tab.GetComponent<CanvasGroup>().alpha = 0;
            tab.GetComponent<CanvasGroup>().interactable = false;
            tab.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        tabs[0].GetComponent<CanvasGroup>().alpha = 1;
        tabs[0].GetComponent<CanvasGroup>().interactable = true;
        tabs[0].GetComponent<CanvasGroup>().blocksRaycasts = true;

        if (0 <= num && num < tabs.Length)
            this.GetComponent<Button>().onClick.AddListener(Click);
    }
    void Click()
    {
        foreach (GameObject tab in tabs)
        {
            tab.GetComponent<CanvasGroup>().alpha = 0;
            tab.GetComponent<CanvasGroup>().interactable = false;
            tab.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        tabs[num].GetComponent<CanvasGroup>().alpha = 1;
        tabs[num].GetComponent<CanvasGroup>().interactable = true;
        tabs[num].GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
