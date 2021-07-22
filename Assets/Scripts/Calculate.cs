using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculate : MonoBehaviour
{
    public Material red, yellow, green;
    public Material redl, yellowl, greenl;
    // Start is called before the first frame update
    void Start()
    {
        if (global.peace + global.middle + global.attacks != 100)
        {
            execute = false;
            Debug.LogError("生成概率出错，无法执行程序");
        }
        for (int i = 0; i < global.startcnt; i++)
            spawnstar();
    }
    public static bool execute = true, sortscore = false;
    int time = 0;
    static List<Stars> stars = new List<Stars>(); int deathcnt = 0;
    System.Random rd = new System.Random();
    void spawnstar()
    {
        int num = rd.Next() % 100, asd;
        if (0 <= num && num < global.peace) asd = -1;
        else if (global.peace <= num && num < global.peace + global.middle) asd = 0;
        else asd = 1;

        stars.Add(new Stars(stars.Count + 1, (float)((rd.NextDouble() - 0.5) * 2 * global.rangex), (float)((rd.NextDouble() - 0.5) * 2 * global.rangey),
            (float)((rd.NextDouble() - 0.5) * 2 * global.rangez), asd, rd.Next() % 2 == 1, time));

        GameObject star = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        star.transform.position = new Vector3(stars[stars.Count - 1].x, stars[stars.Count - 1].y, stars[stars.Count - 1].z);
        star.name = "Star" + (stars.Count - 1).ToString();
        star.transform.localScale = new Vector3(5, 5, 5);
        star.AddComponent<HighlightableObject>();
        switch (asd)
        {
            case 1: { star.AddComponent<HighLightControlRed>(); star.GetComponent<Renderer>().material = red; break; }
            case -1: { star.AddComponent<HighLightControlGreen>(); star.GetComponent<Renderer>().material = green; break; }
            case 0: { star.AddComponent<HighLightControlYellow>(); star.GetComponent<Renderer>().material = yellow; break; }
        }
        star.transform.parent = GameObject.Find("Stars").GetComponent<Transform>();
    }
    bool checkhelplist(List<int> helplist, int number)
    {
        foreach (int l in helplist)
            if (number == l) return false;
        return true;
    }
    // Update is called once per frame
    void Update()
    {
        if (!execute)
        {
            for (int i = 0; i < stars.Count; i++)
                if (stars[i].life && stars[i].havetarget)
                    GameObject.Find("Stars/Star" + i.ToString() + "/Ship").GetComponent<TrailRenderer>().time += Time.deltaTime;
            return;
        }

        for (int j = 0; j < stars.Count; j++)
            if (stars[j].life && stars[j].havetarget)
                if (GameObject.Find("Stars/Star" + j.ToString() + "/Ship").GetComponent<TrailRenderer>().time > 1)
                    GameObject.Find("Stars/Star" + j.ToString() + "/Ship").GetComponent<TrailRenderer>().time -= Time.deltaTime;
                else GameObject.Find("Stars/Star" + j.ToString() + "/Ship").GetComponent<TrailRenderer>().time = 1;

        GameObject.Find("Canvas/ScoreBoard").GetComponent<Text>().text = "";
        time += 1;//加一年
        GameObject.Find("Canvas/Time").GetComponent<Text>().text = time.ToString() + "年";

        //生成新文明
        if (global.allowspawn)
            if (rd.Next() % global.spawnprobability == 0)
            {
                spawnstar();
            }

        for (int i = 0; i < stars.Count; i++)
        {
            if (!stars[i].life) continue;//死亡判断
            if (stars[i].score < 0)
            {
                stars[i].life = false;
                foreach (int it in stars[i].helplist)
                {
                    stars[it].helpcnt -= 1;
                }
                GameObject.Find("Canvas/Message1").GetComponent<Text>().text = (i + 1).ToString() + "号文明被消灭，存活了" + (time - stars[i].lifetime).ToString() + "年";
                Destroy(GameObject.Find("Stars/Star" + i.ToString()).GetComponent<Transform>().gameObject);
                deathcnt += 1;
                continue;
            }

            stars[i].score += global.develop + stars[i].helpcnt * global.cooperation + stars[i].techboomcnt * global.techboom_addon;//加分
            if (global.allowtechboom)//技术爆炸代码
            {
                if (stars[i].techboomcnt < global.techboommax)
                    if (rd.Next() % global.techboom_probability == 0)
                    {
                        stars[i].techboomcnt += 1;
                        GameObject.Find("Canvas/Message1").GetComponent<Text>().text = (i + 1).ToString() + "号文明发生第" + stars[i].techboomcnt.ToString() + "次技术爆炸";
                    }
            }
            if (stars[i].isout)//飞船计算代码
            {
                if (stars[i].havetarget)
                {
                    //execute ships
                    if (!stars[stars[i].ship.target].life)//判断目标是否死亡
                    {
                        Destroy(GameObject.Find("Stars/Star" + i.ToString() + "/Ship").GetComponent<Transform>().gameObject);
                        stars[i].havetarget = false;
                    }
                    else if (stars[i].ship.stats == 0)//飞行状态
                    {
                        GameObject.Find("Stars/Star" + i.ToString() + "/Ship").GetComponent<Transform>().position += stars[i].ship.direction;
                        stars[i].ship.distance += global.travel_speed;
                        if (stars[i].ship.distance >= stars[i].ship.total)//到达目的地
                            stars[i].ship.stats = 1;
                    }
                    else
                    {
                        if (stars[i].ship.type == -1)//没有效果，直接返回
                        {
                            Destroy(GameObject.Find("Stars/Star" + i.ToString() + "/Ship").GetComponent<Transform>().gameObject);
                            stars[i].havetarget = false;
                        }
                        if (stars[i].ship.type == 0)//加入合作列表
                        {
                            Destroy(GameObject.Find("Stars/Star" + i.ToString() + "/Ship").GetComponent<Transform>().gameObject);
                            stars[i].havetarget = false;
                            stars[i].helplist.Add(stars[i].ship.target);
                            stars[stars[i].ship.target].helpcnt += 1;
                        }
                        if (stars[i].ship.type == 1)//打起来了。。。
                        {
                            if (stars[i].ship.defense <= 0)
                            {
                                Destroy(GameObject.Find("Stars/Star" + i.ToString() + "/Ship").GetComponent<Transform>().gameObject);
                                stars[i].havetarget = false;
                            }
                            else
                            {
                                stars[stars[i].ship.target].score += global.attack;
                                stars[i].ship.defense += global.attack;
                            }
                        }
                    }
                }
                else//新建飞船实体
                {
                    if (stars.Count == 1) continue;//欸，人呢？
                    if (stars[i].score < global.cooldowntime) continue;//发展不足，同志仍需努力(～￣▽￣)～

                    int target = rd.Next() % stars.Count;
                    Ships ship = new Ships(i, target, stars[i].score / global.defensetimes, stars[i], stars[target]);
                    stars[i].havetarget = true;
                    stars[i].ship = ship;

                    GameObject.Find("Canvas/Message").GetComponent<Text>().text = (i + 1).ToString() + "号文明发出飞船，目标" + (target + 1).ToString() + "号文明";

                    GameObject _ship = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    _ship.transform.position = new Vector3(stars[stars.Count - 1].x, stars[stars.Count - 1].y, stars[stars.Count - 1].z);
                    _ship.name = "Ship";
                    _ship.transform.localScale = new Vector3(2, 2, 2);
                    _ship.AddComponent<TrailRenderer>();
                    _ship.GetComponent<TrailRenderer>().time = 1;
                    switch (ship.type)
                    {
                        case 1: { _ship.GetComponent<Renderer>().material = red; _ship.GetComponent<TrailRenderer>().material = redl; break; }
                        case -1: { _ship.GetComponent<Renderer>().material = yellow; _ship.GetComponent<TrailRenderer>().material = yellowl; break; }
                        case 0: { _ship.GetComponent<Renderer>().material = green; _ship.GetComponent<TrailRenderer>().material = greenl; break; }
                    }
                    _ship.transform.parent = GameObject.Find("Stars/Star" + i.ToString()).GetComponent<Transform>();
                    _ship.transform.localPosition = new Vector3(0, 0, 0);
                }
            }
        }

        GameObject.Find("Canvas/ScoreBoard").GetComponent<Text>().text = "文明总数：" + (stars.Count - deathcnt).ToString()
            + "，fps:" + Math.Round(1.0 / Time.deltaTime).ToString() + "\n";
        if (sortscore)
        {
            Stars[] temp = new Stars[stars.Count + 10];
            for (int i = 0; i < stars.Count; i++)
                temp[i] = stars[i];
            for (int i = 0; i < stars.Count; i++)
                for (int j = 0; j < i; j++)
                    if (temp[i].score > temp[j].score)
                    {
                        Stars l = temp[i];
                        temp[i] = temp[j];
                        temp[j] = l;
                    }
            GC.Collect();
            for (int i = 0; i < stars.Count; i++)
                if (temp[i].life)
                {
                    switch (temp[i].type)
                    {
                        case 1: { GameObject.Find("Canvas/ScoreBoard").GetComponent<Text>().text += "<color=#FF0000>"; break; }
                        case -1: { GameObject.Find("Canvas/ScoreBoard").GetComponent<Text>().text += "<color=#00FF00>"; break; }
                        case 0: { GameObject.Find("Canvas/ScoreBoard").GetComponent<Text>().text += "<color=#FFFF00>"; break; }
                    }
                    GameObject.Find("Canvas/ScoreBoard").GetComponent<Text>().text += temp[i].num.ToString() + "号文明得分：" + temp[i].score.ToString()
                        + ",文明类型:" + (temp[i].isout ? "外向型" : "内向型") + "</color>\n";
                }

            GC.Collect();
        }
        else
            for (int i = 0; i < stars.Count; i++)
                if (stars[i].life)
                {
                    switch (stars[i].type)
                    {
                        case 1: { GameObject.Find("Canvas/ScoreBoard").GetComponent<Text>().text += "<color=#FF0000>"; break; }
                        case -1: { GameObject.Find("Canvas/ScoreBoard").GetComponent<Text>().text += "<color=#00FF00>"; break; }
                        case 0: { GameObject.Find("Canvas/ScoreBoard").GetComponent<Text>().text += "<color=#FFFF00>"; break; }
                    }
                    GameObject.Find("Canvas/ScoreBoard").GetComponent<Text>().text += stars[i].num.ToString() + "号文明得分：" + stars[i].score.ToString()
                        + ",文明类型:" + (stars[i].isout ? "外向型" : "内向型") + "</color>\n";
                }
    }
}
