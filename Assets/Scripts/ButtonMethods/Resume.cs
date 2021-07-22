using UnityEngine;
using UnityEngine.UI;

public class Resume : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(Click);
    }
    void Click()
    {
        KeyBoardControl.escapeclick = true;
    }
}
