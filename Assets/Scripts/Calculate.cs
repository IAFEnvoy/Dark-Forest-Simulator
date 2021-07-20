using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculate : MonoBehaviour
{
    public Material red, yellow, green;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 50; i++)
        {
            spawnstar();
        }
    }
    public bool execute = true;
    int time = 0;
    List<Stars> stars = new List<Stars>();
    System.Random rd = new System.Random();
    void spawnstar()
    {
        int asd = rd.Next() % 3 - 1;
        stars.Add(new Stars((float)((rd.NextDouble() - 0.5) * 2 * global.rangex), (float)((rd.NextDouble() - 0.5) * 2 * global.rangey), 
            (float)((rd.NextDouble() - 0.5) * 2 * global.rangez), asd, rd.Next() % 2 == 1, time));

        GameObject star = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        star.transform.position = new Vector3(stars[stars.Count - 1].x, stars[stars.Count - 1].y, stars[stars.Count - 1].z);
        star.name = "Star" + (stars.Count - 1).ToString();
        star.transform.localScale = new Vector3(5, 5, 5);
        switch (asd)
        {
            case 1: { star.AddComponent<HighLightControlRed>(); star.GetComponent<Renderer>().material = red; break; }
            case -1: { star.AddComponent<HighLightControlYellow>(); star.GetComponent<Renderer>().material = green; break; }
            case 0: { star.AddComponent<HighLightControlBlue>(); star.GetComponent<Renderer>().material = yellow; break; }
        }
        star.transform.parent = GameObject.Find("Stars").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!execute) return;

        time += 1;//加一年
        GameObject.Find("Canvas/Time").GetComponent<Text>().text = time.ToString() + "年";

        //生成新文明
        if (rd.Next() % global.spawnprobability == 0)
        {
            spawnstar();
        }

        for(int i=0;i<stars.Count;i++)
        {
            if (!stars[i].life) continue;
            if (stars[i].score <= 0)
            {
                stars[i].life = false;
                foreach (int it in stars[i].helplist)
                {
                    stars[it].helpcnt -= 1;
                }
                Debug.LogWarning(i.ToString() + "号文明被消灭，存活了" + (time - stars[i].lifetime).ToString() + "年");
                Destroy(GameObject.Find("Stars/Star" + i.ToString()).GetComponent<Transform>().gameObject);
                continue;
            }
            if (stars[i].isout)
            {
                if (stars[i].havetarget)
                {
                    //execute ships
                    if (!stars[stars[i].ship.target].life)//判断目标是否死亡
                        stars[i].havetarget = false;
                    else if (stars[i].ship.stats == 0)//飞行状态
                    {
                        stars[i].ship.distance += global.travel_speed;
                        if (stars[i].ship.distance >= stars[i].ship.total)//到达目的地
                            stars[i].ship.stats = 1;
                    }
                    else
                    {
                        if (stars[i].ship.type == -1)//没有效果，直接返回
                        {
                            stars[i].havetarget = false;
                        }
                        if(stars[i].ship.type == 0)//加入合作列表
                        {
                            stars[i].havetarget = false;
                            stars[i].helplist.Add(stars[i].ship.target);
                            stars[stars[i].ship.target].helpcnt += 1;
                        }
                        if (stars[i].ship.type == 1)//打起来了。。。
                        {
                            if (stars[i].ship.defense <= 0)
                                stars[i].havetarget = false;
                            else
                            {
                                stars[stars[i].ship.target].score -= global.attack;
                                stars[i].ship.defense -= global.attack;
                            }
                        }
                    }
                }
                else
                {//新建飞船实体
                    int target = rd.Next() % stars.Count;
                    Ships ship = new Ships(i, target, stars[i].score / global.defensetimes, stars[i], stars[target]);
                    stars[i].havetarget = true;
                    stars[i].ship = ship;
                    Debug.Log(i.ToString() + "号文明发出飞船，目标" + target.ToString() + "号文明");
                }
            }
            stars[i].score += global.develop + stars[i].helpcnt * global.cooperation;
        }
    }
}
