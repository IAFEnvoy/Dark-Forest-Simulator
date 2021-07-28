using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class save : MonoBehaviour
{
    string savepath;
    // Start is called before the first frame update
    void Start()
    {
        switch (Application.platform)
        {
            case RuntimePlatform.WindowsPlayer: { savepath = Application.dataPath; break; }//Windows
            case RuntimePlatform.Android: { savepath = Application.persistentDataPath; break; }//安卓
            case RuntimePlatform.IPhonePlayer: { savepath = Application.dataPath; break; }//苹果移动端
            case RuntimePlatform.WindowsEditor: { savepath = Application.dataPath; break; }//Unity编辑器
            default: { savepath = Application.dataPath; break; }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
