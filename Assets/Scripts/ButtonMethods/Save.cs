using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(Click);
    }
    void Click()
    {
        if (!KeyBoardControl.show) return;

        KeyBoardControl.close = true;
        
        OpenFileName openFileName = new OpenFileName();
        openFileName.structSize = Marshal.SizeOf(openFileName);
        openFileName.filter = "*.dfs\0*.dfs";
        openFileName.file = new string(new char[256]);
        openFileName.maxFile = openFileName.file.Length;
        openFileName.fileTitle = new string(new char[64]);
        openFileName.maxFileTitle = openFileName.fileTitle.Length;
        openFileName.initialDir = (UnityEngine.Application.dataPath + @"\Saves").Replace('/', '\\');//默认路径
        openFileName.title = "保存";
        openFileName.flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000008;

        if (LocalDialog.GetSaveFileName(openFileName)){
            if (openFileName.file.Contains(".dfs") == false) openFileName.file += ".dfs";
            Calculate.savefile(openFileName.file);
        }
    }
}
