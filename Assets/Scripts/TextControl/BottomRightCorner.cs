using UnityEngine;

public class BottomRightCorner : MonoBehaviour
{
    int width, height;
    public int mewidth, meheight;
    // Update is called once per frame
    void Update()
    {
        width = Screen.width;
        height = Screen.height;
        transform.localPosition = new Vector3(width / 2 - mewidth / 2 - 170, -height / 2 + meheight / 2, 0);
    }
}
