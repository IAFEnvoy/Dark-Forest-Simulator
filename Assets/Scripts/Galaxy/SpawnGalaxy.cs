using System;
using UnityEngine;

public class SpawnGalaxy : MonoBehaviour
{
    public Material white;
    // Start is called before the first frame update
    void Start()
    {
        System.Random rd = new System.Random();
        for (int i = 0; i < 500; i++)
        {
            double a, distance, height;
            distance = rd.Next() % 1000; a = rd.Next() % (Math.PI * 2); height = rd.Next() % 100 - 50;
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            go.transform.position = new Vector3((float)(distance * Math.Sin(a)), (float)(height / (distance / 1000+0.3)), (float)(distance * Math.Cos(a)));
            go.name = "star" + i.ToString();
            go.GetComponent<Renderer>().material = white;
            go.transform.localScale = new Vector3(5, 5, 5);
            go.transform.parent = GameObject.Find("Galaxy").GetComponent<Transform>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
