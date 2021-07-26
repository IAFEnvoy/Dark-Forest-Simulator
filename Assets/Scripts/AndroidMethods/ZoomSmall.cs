using UnityEngine;
using UnityEngine.UI;

public class ZoomSmall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(Click);
    }
    void Click()
    {
        camera_move.distance += 50;
    }
}
