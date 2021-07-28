using UnityEngine;

public class TopRightCorner : MonoBehaviour
{
    int width, height;
    public int mewidth, meheight;
    // Update is called once per frame
    void Update()
    {
        width = Screen.width;
        height = Screen.height;
        transform.localPosition = new Vector3(width / 2 - mewidth / 2 + 10, height / 2 - meheight / 2 - 30, 0);
    }
}
