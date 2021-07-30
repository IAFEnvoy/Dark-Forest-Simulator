using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Calculate : MonoBehaviour
{
    public Material red, yellow, green, white, blue;
    public Material redl, yellowl, greenl;
    public static bool reload = false;
    public static bool execute = true, sortscore = false;
    static int time = 0;
    static List<Stars> stars = new List<Stars>(); static int deathstars = 0;
    static List<Civils> civils = new List<Civils>(); static int deathcivils = 0;
    System.Random rd = new System.Random();
    public void Load()
    {
        time = 0;
        GameObject.Find("Canvas/UI/Message").GetComponent<Text>().text = "初始化完毕";
        for (int i = 0; i < stars.Count; i++)
            if (stars[i].life)
                Destroy(GameObject.Find("Stars/Star" + i.ToString()).GetComponent<Transform>().gameObject);
        stars.Clear(); deathstars = 0;

        for (int i = 0; i < Galaxy.startcnt; i++)
            spawnstar();
    }
    void spawnstar()//生成一个恒星的代码
    {
        double a, distance, height;
        distance = rd.Next() % Galaxy.size; a = rd.Next() % (Math.PI * 2); height = rd.Next() % (Galaxy.height * 2) - Galaxy.height;
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        go.transform.position = new Vector3((float)(distance * Math.Sin(a)), (float)(height / (distance / 1000 + 0.3)), (float)(distance * Math.Cos(a)));
        go.GetComponent<Renderer>().material = white;
        go.name = "Star" + stars.Count.ToString();
        go.transform.localScale = new Vector3(5, 5, 5);
        go.transform.parent = GameObject.Find("Galaxy").GetComponent<Transform>();

        Stars star = new Stars(stars.Count, (float)(distance * Math.Sin(a)), (float)(height / (distance / 1000 + 0.3)), (float)(distance * Math.Cos(a)));
        stars.Add(star);
    }
    void spawncivil()//生成一个文明的代码
    {
        int star = rd.Next() % stars.Count, whilecnt = 0;
        while (stars[star].civil != -1 || !stars[star].life)//生成失败
        {
            star = (star + 1) % stars.Count;
            whilecnt++;
            if (whilecnt >= stars.Count) return;
        }
        stars[star].civil = civils.Count;
        int asd = rd.Next() % 3 - 1;
        GameObject _star = GameObject.Find("Galaxy/Star" + star.ToString());
        _star.AddComponent<HighlightableObject>();
        switch (asd)
        {
            case 1: { _star.AddComponent<HighLightControlRed>(); _star.GetComponent<Renderer>().material = red; break; }
            case -1: { _star.AddComponent<HighLightControlGreen>(); _star.GetComponent<Renderer>().material = green; break; }
            case 0: { _star.AddComponent<HighLightControlYellow>(); _star.GetComponent<Renderer>().material = yellow; break; }
        }
        civils.Add(new Civils(civils.Count, star, asd, rd.Next() % 2 == 1 ? true : false, time));
    }
    bool checkhelplist(List<int> helplist, int number)
    {
        foreach (int l in helplist)
            if (number == l) return false;
        return true;
    }
    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        if (reload) { reload = false; Load(); }


        GameObject.Find("Canvas/UI/ScoreBoard").GetComponent<Text>().text = "";
        time += 1;//加一年
        GameObject.Find("Canvas/UI/Time").GetComponent<Text>().text = time.ToString() + "年";

        if (Galaxy.allowspawn)//生成新恒星
            if (rd.Next() % Galaxy.spawnprobability == 0)
                spawnstar();

        if (SpawnCivil.allow)//生成新文明
            if (rd.Next() % SpawnCivil.probability == 0)
                spawncivil();

        for (int i = 0; i < civils.Count; i++)//恒星计算
        {
            if (!civils[i].life) continue;//死亡判断
            if (civils[i].home.Count == 0)//死亡
            {
                civils[i].life = false;
                foreach (int star in civils[i].home)
                {
                    stars[star].life = false;
                    Destroy(GameObject.Find("Galaxy/Star" + star.ToString()).GetComponent<Transform>().gameObject);
                }
                foreach (int it in civils[i].helplist)
                    civils[it].helpcnt -= 1;
                GameObject.Find("Canvas/UI/Message1").GetComponent<Text>().text = (i + 1).ToString() + "号文明被消灭，存活了" + (time - civils[i].lifetime).ToString() + "年";
                deathstars += 1; deathcivils += 1;
                continue;
            }

            civils[i].scorelast = 0;
            foreach(int it in civils[i].home){
                civils[i].scorelast += stars[it].score;
                stars[it].score += Speed.develop + civils[i].helpcnt * Speed.cooperation + civils[i].techboomcnt * TechBoom.addon;//加分
            }

            if (TechBoom.allow)//技术爆炸代码
            {
                if (civils[i].techboomcnt < TechBoom.max)
                    if (rd.Next() % TechBoom.probability == 0)
                    {
                        civils[i].techboomcnt += 1;
                        GameObject.Find("Canvas/UI/Message1").GetComponent<Text>().text = (i + 1).ToString() + "号文明发生第" + civils[i].techboomcnt.ToString() + "次技术爆炸";
                    }
            }

            if (civils[i].isout)//探索代码
            {
                for (int j = 0; j < civils[i].ship.Count; j++)//遍历飞船
                {
                    if (!civils[i].ship[j].life) continue;
                    if (!stars[civils[i].ship[j].target].life)//判断目标是否死亡
                    {
                        Destroy(GameObject.Find("Galaxy/Star" + i.ToString() + "/Ship" + j.ToString()).GetComponent<Transform>().gameObject);
                        civils[i].ship[j].life = false;
                    }
                    else if (civils[i].ship[j].stats == 0)//飞行状态
                    {
                        GameObject.Find("Galaxy/Star" + i.ToString() + "/Ship" + j.ToString()).GetComponent<Transform>().position
                            += new Vector3(civils[i].ship[j].directionx, civils[i].ship[j].directiony, civils[i].ship[j].directionz);
                        civils[i].ship[j].nowx += civils[i].ship[j].directionx;
                        civils[i].ship[j].nowy += civils[i].ship[j].directiony;
                        civils[i].ship[j].nowz += civils[i].ship[j].directionz;
                        civils[i].ship[j].distance += Speed.travel_speed;
                        if (civils[i].ship[j].distance >= civils[i].ship[j].total)//到达目的地
                            civils[i].ship[j].stats = 1;
                    }
                    else//到达状态
                    {
                        if (civils[i].ship[j].type == -1)//没有效果，直接返回
                        {
                            Destroy(GameObject.Find("Galaxy/Star" + i.ToString() + "/Ship" + j.ToString()).GetComponent<Transform>().gameObject);
                            civils[i].ship[j].life = false;
                        }
                        else if (civils[i].ship[j].type == 0)//加入合作列表
                        {
                            Destroy(GameObject.Find("Galaxy/Star" + i.ToString() + "/Ship" + j.ToString()).GetComponent<Transform>().gameObject);
                            civils[i].ship[j].life = false;
                            bool flag = false;
                            for (int k = 0; k < civils[i].helplist.Count; k++)
                                flag = flag || civils[i].helplist[k] == stars[civils[i].ship[j].target].civil;
                            if (!flag)
                            {
                                civils[i].helplist.Add(stars[civils[i].ship[j].target].civil);
                                civils[stars[civils[i].ship[j].target].civil].helpcnt += 1;
                            }
                        }
                        else if (civils[i].ship[j].type == 1)//打起来了。。。
                        {
                            if (civils[i].ship[j].defense <= 0)
                            {
                                Destroy(GameObject.Find("Galaxy/Star" + i.ToString() + "/Ship" + j.ToString()).GetComponent<Transform>().gameObject);
                                civils[i].ship[j].life = false;
                            }
                            else
                            {
                                stars[civils[i].ship[j].target].score += Speed.attack;
                                civils[i].ship[j].defense += Speed.attack;
                            }
                        }
                        else if (civils[i].ship[j].type == 2)//探索
                        {
                            stars[civils[i].ship[j].target].civil = i;
                            civils[i].home.Add(civils[i].ship[j].target);
                            GameObject _star = GameObject.Find("Galaxy/Star" + civils[i].ship[j].target.ToString());
                            switch (civils[i].type)
                            {
                                case 1: { _star.AddComponent<HighLightControlRed>(); _star.GetComponent<Renderer>().material = red; break; }
                                case -1: { _star.AddComponent<HighLightControlGreen>(); _star.GetComponent<Renderer>().material = green; break; }
                                case 0: { _star.AddComponent<HighLightControlYellow>(); _star.GetComponent<Renderer>().material = yellow; break; }
                            }
                            Destroy(GameObject.Find("Galaxy/Star" + i.ToString() + "/Ship" + j.ToString()).GetComponent<Transform>().gameObject);
                            civils[i].ship[j].life = false;
                        }
                    }
                }
                if (Ship.allow && civils.Count > 1)
                    if (civils[i].ship.Count < Ship.max && rd.Next() % Ship.spawn_probability == 0)//飞船生成
                    {
                        int target = rd.Next() % stars.Count, whilecnt = 0;
                        while (!stars[target].life)//生成失败
                        {
                            target = (target + 1) % stars.Count;
                            whilecnt++;
                            if (whilecnt > stars.Count) continue;
                        }
                        Ships ship = new Ships(i, target, stars[civils[i].home[0]].score / Civil.defensetimes, stars[civils[i].home[0]], stars[target], civils);
                        civils[i].ship.Add(ship);

                        GameObject _ship = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        _ship.transform.position = new Vector3( stars[civils[i].home[0]].x,  stars[civils[i].home[0]].y,  stars[civils[i].home[0]].z);
                        _ship.name = "Ship" + (civils[i].ship.Count - 1).ToString();
                        _ship.transform.localScale = new Vector3(2, 2, 2);
                        _ship.AddComponent<TrailRenderer>();
                        _ship.GetComponent<TrailRenderer>().time = 1;
                        _ship.AddComponent<HighlightableObject>();
                        switch (ship.type)
                        {
                            case 1: { _ship.GetComponent<Renderer>().material = red; _ship.GetComponent<TrailRenderer>().material = redl; break; }
                            case -1: { _ship.GetComponent<Renderer>().material = yellow; _ship.GetComponent<TrailRenderer>().material = yellowl; break; }
                            case 0: { _ship.GetComponent<Renderer>().material = green; _ship.GetComponent<TrailRenderer>().material = greenl; break; }
                            case 2: { _ship.GetComponent<Renderer>().material = blue; _ship.GetComponent<TrailRenderer>().material = blue; break; }
                        }
                        _ship.transform.parent = GameObject.Find("Galaxy/Star" + i.ToString()).GetComponent<Transform>();
                        _ship.transform.localPosition = new Vector3(0, 0, 0);
                    }
            }
        }
        GameObject.Find("Canvas/UI/ScoreBoard").GetComponent<Text>().text = "文明总数：" + (civils.Count - deathcivils).ToString()
            + "，fps:" + Math.Round(1.0 / Time.deltaTime).ToString() + "\n";

        for (int i = 0; i < civils.Count; i++)
            if (civils[i].life)
            {
                switch (civils[i].type)
                {
                    case 1: { GameObject.Find("Canvas/UI/ScoreBoard").GetComponent<Text>().text += "<color=#FF0000>"; break; }
                    case -1: { GameObject.Find("Canvas/UI/ScoreBoard").GetComponent<Text>().text += "<color=#00FF00>"; break; }
                    case 0: { GameObject.Find("Canvas/UI/ScoreBoard").GetComponent<Text>().text += "<color=#FFFF00>"; break; }
                    default: { GameObject.Find("Canvas/UI/ScoreBoard").GetComponent<Text>().text += "<color=#FFFFFF>"; break; }
                }
                int score = 0;
                foreach (int it in civils[i].home)
                    score += stars[it].score;
                GameObject.Find("Canvas/UI/ScoreBoard").GetComponent<Text>().text += (score > civils[i].scorelast ? "↑" : "↓") + civils[i].num.ToString() + "号文明得分：" + score.ToString()
                    + ",文明类型:" + (civils[i].isout ? "外向型" : "内向型") + "</color>\n";
            }
    }
}
