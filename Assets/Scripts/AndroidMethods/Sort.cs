using UnityEngine;
using UnityEngine.UI;

public class Sort : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(Click);
    }

    // Update is called once per frame
    void Click()
    {
        Calculate.sortscore = !Calculate.sortscore;
    }
}
