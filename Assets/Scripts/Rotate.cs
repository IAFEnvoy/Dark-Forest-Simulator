using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public int rotate_delta = 45;
    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.up, rotate_delta * Time.deltaTime, Space.Self);
    }
}
