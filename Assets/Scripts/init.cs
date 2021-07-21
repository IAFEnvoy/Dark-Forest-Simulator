using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class init : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(File.Exists(Application.dataPath + @"\start_up_parameter.txt")){
            StreamReader sr=new StreamReader(Application.dataPath + @"\start_up_start_up_parameter.txt");
            global.startcnt=int.Parse(sr.ReadLine());
            global.startscore=int.Parse(sr.ReadLine());
            global.travel_speed=double.Parse(sr.ReadLine());
            global.develop=int.Parse(sr.ReadLine());
            global.cooperation=int.Parse(sr.ReadLine());
            global.attack=int.Parse(sr.ReadLine());
            global.allowspawn=bool.Parse(sr.ReadLine());
            global.spawnprobability=int.Parse(sr.ReadLine());
            global.cooldowntime=int.Parse(sr.ReadLine());
            global.rangex=double.Parse(sr.ReadLine());
            global.rangey=double.Parse(sr.ReadLine());
            global.rangez=double.Parse(sr.ReadLine());
            global.defensetimes=int.Parse(sr.ReadLine());
            global.peace=int.Parse(sr.ReadLine());
            global.middle=int.Parse(sr.ReadLine());
            global.attacks=int.Parse(sr.ReadLine());
            sr.Close();
        }
    }
}
