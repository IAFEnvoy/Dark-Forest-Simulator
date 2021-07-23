using UnityEngine;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(Click);
    }
    void Click()
    {
        if (KeyBoardControl.show)
        {
            Calculate.reload = true;
            KeyBoardControl.close = true;
        }
    }
}
