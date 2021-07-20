using System.Collections.Generic;
using UnityEngine;

public class Calculate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public bool execute = false;
    int time = 0;
    List<Stars> stars = new List<Stars>();
    System.Random rd = new System.Random();
    void spawnstar()
    {
        stars.Add(new Stars((float)(rd.NextDouble() * global.rangex), (float)(rd.NextDouble() * global.rangey), rd.Next() % 3 - 1, rd.Next() % 2 == 1, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (!execute) return;
        time += 1;//加一年

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
                Debug.Log(i.ToString() + "号文明被消灭，存活了" + (time - stars[i].lifetime).ToString() + "年");
                continue;
            }
            if (stars[i].isout)
            {
                if (stars[i].havetarget)
                {
                    //execute ships
                    if (stars[i].ship.stats == 0)//飞行状态
                    {
                        stars[i].ship.distance += global.travel_speed;
                        
                    }
                }
                else
                {

                }
            }


            stars[i].score += global.develop;
        }
    }
}
