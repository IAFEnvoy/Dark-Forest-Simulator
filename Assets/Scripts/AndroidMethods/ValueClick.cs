using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(Click);
    }
    void Click()
    {
        if (GameObject.Find("Canvas/Menu").GetComponent<CanvasGroup>().alpha == 0)
        {
            GameObject.Find("Canvas/Setting").GetComponent<CanvasGroup>().alpha = 1 - GameObject.Find("Canvas/Setting").GetComponent<CanvasGroup>().alpha;
            GameObject.Find("Canvas/Setting").GetComponent<CanvasGroup>().interactable = !GameObject.Find("Canvas/Setting").GetComponent<CanvasGroup>().interactable;
            GameObject.Find("Canvas/Setting").GetComponent<CanvasGroup>().blocksRaycasts = !GameObject.Find("Canvas/Setting").GetComponent<CanvasGroup>().blocksRaycasts;
        }
    }
}
