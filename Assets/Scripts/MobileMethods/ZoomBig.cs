using System;
using UnityEngine;
using UnityEngine.UI;

public class ZoomBig : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(Click);
    }
    void Click()
    {
        camera_move.distance -= 50;
        Vector2 new1 = Input.mousePosition;
        camera_move.a -= (new1.x - camera_move.now.x) * 0.01;
        camera_move.b -= (new1.y - camera_move.now.y) * 0.004;
        if (camera_move.b <= -Math.PI / 2) camera_move.b = -Math.PI / 2 + 0.04;
        if (camera_move.b >= Math.PI / 2) camera_move.b = Math.PI / 2 - 0.04;
        GameObject.Find("Main Camera").GetComponent<Camera>().transform.position = new Vector3(
          (float)Math.Cos(camera_move.a) * (float)Math.Cos(camera_move.b) * (float)camera_move.distance,
          (float)Math.Sin(camera_move.b) * (float)camera_move.distance,
          (float)Math.Sin(camera_move.a) * (float)Math.Cos(camera_move.b) * (float)camera_move.distance);
        //transform.rotation = Quaternion.Euler(0, 0, 0);
        camera_move.now = new1;
    }
}