using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class init : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        switch (Application.platform)
        {
            case RuntimePlatform.WindowsPlayer: { Debug.Log("Windows"); break; }
            case RuntimePlatform.Android: { Debug.Log("Android"); break; }
            case RuntimePlatform.IPhonePlayer: { Debug.Log("IOS"); break; }
            case RuntimePlatform.WindowsEditor: { Debug.Log("Unity Editor"); break; }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
