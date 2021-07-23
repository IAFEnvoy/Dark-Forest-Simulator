using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(Click);
    }
    void Click()
    {
        if (KeyBoardControl.show)
            UnityEngine.Application.Quit();
    }
    void OnDestroy()
    {
        Debug.Log("OnDestroy");
        Debug.Log("当前进程名：" + System.Diagnostics.Process.GetCurrentProcess().ProcessName);
        if(System.Diagnostics.Process.GetCurrentProcess().ProcessName.Contains("Unity"))
            Debug.Log("检测到为编辑器环境，将不执行快速关闭代码");
        else System.Diagnostics.Process.GetCurrentProcess().Kill();
    }
}
