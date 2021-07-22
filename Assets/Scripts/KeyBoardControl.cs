using UnityEngine;

public class KeyBoardControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Canvas/Menu").GetComponent<CanvasGroup>().alpha = 0;
    }
    // Update is called once per frame
    public static bool escapeclick = false;
    public static bool show = false;
    void Update()
    {
        if (escapeclick)
        {
            if (show)
            {
                GameObject.Find("Canvas/Menu").GetComponent<CanvasGroup>().alpha -= Time.deltaTime * 3;
                if (GameObject.Find("Canvas/Menu").GetComponent<CanvasGroup>().alpha <= 0)
                {
                    GameObject.Find("Canvas/Menu").GetComponent<CanvasGroup>().alpha = 0;
                    show = false; escapeclick = false;
                }
            }
            else
            {
                GameObject.Find("Canvas/Menu").GetComponent<CanvasGroup>().alpha += Time.deltaTime * 3;
                if (GameObject.Find("Canvas/Menu").GetComponent<CanvasGroup>().alpha >= 1)
                {
                    GameObject.Find("Canvas/Menu").GetComponent<CanvasGroup>().alpha = 1;
                    show = true; escapeclick = false;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape)) escapeclick = true;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Calculate.execute = !Calculate.execute;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Calculate.sortscore = !Calculate.sortscore;
        }
    }
}
