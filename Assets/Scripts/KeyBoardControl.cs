using UnityEngine;

public class KeyBoardControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Canvas/Menu").GetComponent<CanvasGroup>().alpha = 0;
    }
    // Update is called once per frame
    public static bool show = false;
    public static bool open = false, close = false;
    void Update()
    {
        if (open)
        {
            GameObject.Find("Canvas/Menu").GetComponent<CanvasGroup>().alpha += Time.deltaTime * 3;
            if (GameObject.Find("Canvas/Menu").GetComponent<CanvasGroup>().alpha >= 1)
            {
                GameObject.Find("Canvas/Menu").GetComponent<CanvasGroup>().alpha = 1;
                show = true; open = false;
            }

        }
        if (close)
        {
            GameObject.Find("Canvas/Menu").GetComponent<CanvasGroup>().alpha -= Time.deltaTime * 3;
            if (GameObject.Find("Canvas/Menu").GetComponent<CanvasGroup>().alpha <= 0)
            {
                GameObject.Find("Canvas/Menu").GetComponent<CanvasGroup>().alpha = 0;
                show = false; close=false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (show == true) close = true;
            else open = true;
        }
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
