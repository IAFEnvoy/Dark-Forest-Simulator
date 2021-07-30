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
    static Material reds, yellows, greens, blues, whites;
    static Material redls, yellowls, greenls;
    public static bool reload = false;
    public static bool execute = true, sortscore = false;
    static int time = 0;
    static List<Stars> stars = new List<Stars>(); static int deathcnt = 0;
    static List<Biaxial_foil> bfs = new List<Biaxial_foil>();
    System.Random rd = new System.Random();
    public static void savefile(string path)
    {
        StreamWriter sw = new StreamWriter(path);
        sw.WriteLine(Encoding.ASCII.GetString(Binary.SerializeBinary(new Datas(stars, bfs))));
        sw.Close();
        sw.Dispose();
    }
    public static void loadfile(string path)
    {
        StreamReader sr = new StreamReader(path);
        Datas datas = (Datas)Binary.DeserializeBinary(Encoding.ASCII.GetBytes(sr.ReadToEnd()));

        time = 0;
        GameObject.Find("Canvas/UI/Message").GetComponent<Text>().text = "初始化完毕";
        for (int i = 0; i < stars.Count; i++)
            if (stars[i].life)
                Destroy(GameObject.Find("Stars/Star" + i.ToString()).GetComponent<Transform>().gameObject);
        stars.Clear(); deathcnt = 0;
        for (int i = 0; i < bfs.Count; i++)
            if (bfs[i].life)
                Destroy(GameObject.Find("Biaxial_foil/bf" + i.ToString()).GetComponent<Transform>().gameObject);
        bfs.Clear();

        stars = datas.stars;

        for (int i = 0; i < stars.Count; i++)
            if (stars[i].life)
            {
                GameObject star = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                star.transform.position = new Vector3(stars[i].x, stars[i].y, stars[i].z);
                star.name = "Star" + i.ToString();
                star.transform.localScale = new Vector3(5, 5, 5);
                star.AddComponent<HighlightableObject>();

                if (stars[i].type != 1 && stars[i].type != 0) stars[i].type = -1;

                switch (stars[i].type)
                {
                    case 1: { star.AddComponent<HighLightControlRed>(); star.GetComponent<Renderer>().material = reds; break; }
                    case -1: { star.AddComponent<HighLightControlGreen>(); star.GetComponent<Renderer>().material = greens; break; }
                    case 0: { star.AddComponent<HighLightControlYellow>(); star.GetComponent<Renderer>().material = yellows; break; }
                }
                star.AddComponent<TrailRenderer>();
                star.GetComponent<TrailRenderer>().time = 2;
                star.GetComponent<TrailRenderer>().material = blues;
                star.transform.parent = GameObject.Find("Stars").GetComponent<Transform>();

                stars[i].havetarget = false; stars[i].ship = null;
                if (stars[i].havetarget)
                {
                    GameObject _ship = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    _ship.transform.position = new Vector3(stars[i].ship.nowx, stars[i].ship.nowy, stars[i].ship.nowz);
                    _ship.name = "Ship";
                    _ship.transform.localScale = new Vector3(2, 2, 2);
                    _ship.AddComponent<TrailRenderer>();
                    _ship.GetComponent<TrailRenderer>().time = 1;
                    switch (stars[i].ship.type)
                    {
                        case 1: { _ship.GetComponent<Renderer>().material = reds; _ship.GetComponent<TrailRenderer>().material = redls; break; }
                        case -1: { _ship.GetComponent<Renderer>().material = yellows; _ship.GetComponent<TrailRenderer>().material = yellowls; break; }
                        case 0: { _ship.GetComponent<Renderer>().material = greens; _ship.GetComponent<TrailRenderer>().material = greenls; break; }
                    }
                    _ship.transform.parent = GameObject.Find("Stars/Star" + i.ToString()).GetComponent<Transform>();
                }
            }
    }
    // Start is called before the first frame update
    void Start()
    {
        reds = red; yellows = yellow; greens = green; blues = blue; whites = white;
        redls = redl; yellowls = yellowl; greenls = greenl;
        Load();
    }
    public void Load()
    {
        time = 0;
        GameObject.Find("Canvas/UI/Message").GetComponent<Text>().text = "初始化完毕";
        for (int i = 0; i < stars.Count; i++)
            if (stars[i].life)
                Destroy(GameObject.Find("Stars/Star" + i.ToString()).GetComponent<Transform>().gameObject);
<<<<<<< HEAD
        stars.Clear(); deathcnt = 0;
        for (int i = 0; i < bfs.Count; i++)
            if (bfs[i].life)
                Destroy(GameObject.Find("Biaxial_foil/bf" + i.ToString()).GetComponent<Transform>().gameObject);
        bfs.Clear();

        for (int i = 0; i < global.startcnt; i++)
            spawnstar();
    }
    bool isattack(int start, int target)
    {
        if (stars[start].type == 1) return true;
        if (stars[start].type == -1)
        {
            if (stars[target].type == 1) if (global.allow_attack_help) return false; else return true;
            return false;
        }
        if (stars[start].type == 0)
=======
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
>>>>>>> c9ac9a4e942d5354bbaead34db92897d2fd98abf
        {
            star = (star + 1) % stars.Count;
            whilecnt++;
            if (whilecnt >= stars.Count) return;
        }
<<<<<<< HEAD
        return false;
    }
    void spawnstar()
    {
        int num = rd.Next() % (global.peace + global.middle + global.attacks), asd;
        if (num < global.peace) asd = -1;
        else if (global.peace <= num && num < global.peace + global.middle) asd = 0;
        else asd = 1;

        stars.Add(new Stars(stars.Count + 1, (float)((rd.NextDouble() - 0.5) * 2 * global.rangex), (float)((rd.NextDouble() - 0.5) * 2 * global.rangey),
            (float)((rd.NextDouble() - 0.5) * 2 * global.rangez), asd, rd.Next() % 2 == 1, time));

        GameObject star = GameObject.CreatePrimitive(PrimitiveType.Sphere), starl = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        starl.transform.position = new Vector3(stars[stars.Count - 1].x, stars[stars.Count - 1].y, stars[stars.Count - 1].z);
        star.transform.position = new Vector3(stars[stars.Count - 1].x, stars[stars.Count - 1].y, stars[stars.Count - 1].z);
        starl.name = "Star" + (stars.Count - 1).ToString();
        star.name = "Star";
        starl.transform.localScale = new Vector3(1, 1, 1);
        star.transform.localScale = new Vector3(5, 5, 5);
        star.AddComponent<HighlightableObject>();
=======
        stars[star].civil = civils.Count;
        int asd = rd.Next() % 3 - 1;
        GameObject _star = GameObject.Find("Galaxy/Star" + star.ToString());
        _star.AddComponent<HighlightableObject>();
>>>>>>> c9ac9a4e942d5354bbaead34db92897d2fd98abf
        switch (asd)
        {
            case 1: { _star.AddComponent<HighLightControlRed>(); _star.GetComponent<Renderer>().material = red; break; }
            case -1: { _star.AddComponent<HighLightControlGreen>(); _star.GetComponent<Renderer>().material = green; break; }
            case 0: { _star.AddComponent<HighLightControlYellow>(); _star.GetComponent<Renderer>().material = yellow; break; }
        }
<<<<<<< HEAD
        starl.AddComponent<TrailRenderer>();
        starl.GetComponent<TrailRenderer>().time = 2;
        starl.GetComponent<TrailRenderer>().material = blue;
        star.AddComponent<Rotate>();
        starl.transform.parent = GameObject.Find("Stars").GetComponent<Transform>();
        star.transform.parent = starl.transform;
=======
        civils.Add(new Civils(civils.Count, star, asd, rd.Next() % 2 == 1 ? true : false, time));
>>>>>>> c9ac9a4e942d5354bbaead34db92897d2fd98abf
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
<<<<<<< HEAD
        // if (!execute)
        // {
        //     for (int i = 0; i < stars.Count; i++)
        //         if (stars[i].life && stars[i].havetarget)
        //             GameObject.Find("Stars/Star" + i.ToString() + "/Ship").GetComponent<TrailRenderer>().time += Time.deltaTime;
        //     return;
        // }

        // for (int j = 0; j < stars.Count; j++)
        //     if (stars[j].life && stars[j].havetarget)
        //         if (GameObject.Find("Stars/Star" + j.ToString() + "/Ship").GetComponent<TrailRenderer>().time > 1)
        //             GameObject.Find("Stars/Star" + j.ToString() + "/Ship").GetComponent<TrailRenderer>().time -= Time.deltaTime;
        //         else GameObject.Find("Stars/Star" + j.ToString() + "/Ship").GetComponent<TrailRenderer>().time = 1;
=======

>>>>>>> c9ac9a4e942d5354bbaead34db92897d2fd98abf

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
                foreach (int it in civils[i].helplist)
                    civils[it].helpcnt -= 1;
                GameObject.Find("Canvas/UI/Message1").GetComponent<Text>().text = (i + 1).ToString() + "号文明被消灭，存活了" + (time - civils[i].lifetime).ToString() + "年";
                deathstars += 1; deathcivils += 1;
                continue;
            }
<<<<<<< HEAD
            GameObject.Find("Biaxial_foil/bf" + i.ToString()).GetComponent<Transform>().position += new Vector3(bfs[i].directionx, bfs[i].directiony, bfs[i].directionz);
            bfs[i].distance += global.speed2d;
            bfs[i].nowx += bfs[i].directionx;
            bfs[i].nowy += bfs[i].directiony;
            bfs[i].nowz += bfs[i].directionz;

            if (bfs[i].distance >= bfs[i].total)//到达目的地
            {
                bfs[i].life = false;
                Destroy(GameObject.Find("Biaxial_foil/bf" + i.ToString()).GetComponent<Transform>().gameObject);
                if (stars[bfs[i].target].helpcnt > 0 && stars[bfs[i].target].type != 1)//欸，我溜了（当有文明帮助）
                {
                    stars[bfs[i].target].x = (float)((rd.NextDouble() - 0.5) * 2 * global.rangex);
                    stars[bfs[i].target].y = (float)((rd.NextDouble() - 0.5) * 2 * global.rangey);
                    stars[bfs[i].target].z = (float)((rd.NextDouble() - 0.5) * 2 * global.rangez);
                    GameObject.Find("Stars/Star" + bfs[i].target.ToString()).GetComponent<Transform>().position
                        = new Vector3(stars[bfs[i].target].x, stars[bfs[i].target].y, stars[bfs[i].target].z);
                    if (stars[bfs[i].target].havetarget)
                    {
                        stars[bfs[i].target].havetarget = false;
                        Destroy(GameObject.Find("Stars/Star" + bfs[i].target.ToString() + "/Ship").GetComponent<Transform>().gameObject);
                    }
                    GameObject.Find("Canvas/UI/Message1").GetComponent<Text>().text = bfs[i].target.ToString() + "号文明受到降维打击，已经迁移位置";
                }
                else//awsl
                {
                    stars[bfs[i].target].life = false;

                    GameObject.Find("Canvas/UI/Message1").GetComponent<Text>().text = (bfs[i].target + 1).ToString() + "号文明受到降维打击，存活了" + (time - stars[bfs[i].target].lifetime).ToString() + "年";
                    Destroy(GameObject.Find("Stars/Star" + bfs[i].target.ToString()).GetComponent<Transform>().gameObject);
                    deathcnt += 1;
                }
            }
        }

        for (int i = 0; i < stars.Count; i++)
        {
            if (!stars[i].life) continue;//死亡判断
            stars[i].scorelast = stars[i].score;

            if (stars[i].score < 0)
            {
                stars[i].life = false;
                foreach (int it in stars[i].helplist)
                {
                    stars[it].helpcnt -= 1;
                }
                GameObject.Find("Canvas/UI/Message1").GetComponent<Text>().text = (i + 1).ToString() + "号文明被消灭，存活了" + (time - stars[i].lifetime).ToString() + "年";
                Destroy(GameObject.Find("Stars/Star" + i.ToString()).GetComponent<Transform>().gameObject);
                deathcnt += 1;
                continue;
=======

            civils[i].scorelast = 0;
            foreach (int it in civils[i].home)
            {
                civils[i].scorelast += stars[it].score;
                stars[it].score += Speed.develop + civils[i].helpcnt * Speed.cooperation + civils[i].techboomcnt * TechBoom.addon;//加分
>>>>>>> c9ac9a4e942d5354bbaead34db92897d2fd98abf
            }

            if (TechBoom.allow)//技术爆炸代码
            {
                if (civils[i].techboomcnt < TechBoom.max)
                    if (rd.Next() % TechBoom.probability == 0)
                    {
<<<<<<< HEAD
                        stars[i].techboomcnt += 1;
                        GameObject.Find("Canvas/UI/Message1").GetComponent<Text>().text = (i + 1).ToString() + "号文明发生第" + stars[i].techboomcnt.ToString() + "次技术爆炸";
=======
                        civils[i].techboomcnt += 1;
                        GameObject.Find("Canvas/UI/Message1").GetComponent<Text>().text = (i + 1).ToString() + "号文明发生第" + civils[i].techboomcnt.ToString() + "次技术爆炸";
>>>>>>> c9ac9a4e942d5354bbaead34db92897d2fd98abf
                    }
            }

            if (civils[i].isout)//探索代码
            {
                for (int j = 0; j < civils[i].ship.Count; j++)//遍历飞船
                {
<<<<<<< HEAD
                    if (GameObject.Find("Stars/Star" + i.ToString() + "/Ship") == null) { }//DO NOTHING
                    //execute ships
                    else if (!stars[stars[i].ship.target].life)//判断目标是否死亡
=======
                    if (!civils[i].ship[j].life) continue;
                    if (!stars[civils[i].ship[j].target].life)//判断目标是否死亡
>>>>>>> c9ac9a4e942d5354bbaead34db92897d2fd98abf
                    {
                        Destroy(GameObject.Find("Galaxy/Star" + civils[i].home[0].ToString() + "/Ship" + j.ToString()).GetComponent<Transform>().gameObject);
                        civils[i].ship[j].life = false;
                    }
                    else if (civils[i].ship[j].stats == 0)//飞行状态
                    {
<<<<<<< HEAD
                        GameObject.Find("Stars/Star" + i.ToString() + "/Ship").GetComponent<Transform>().position += new Vector3(stars[i].ship.directionx, stars[i].ship.directiony, stars[i].ship.directionz);
                        stars[i].ship.nowx += stars[i].ship.directionx;
                        stars[i].ship.nowy += stars[i].ship.directiony;
                        stars[i].ship.nowz += stars[i].ship.directionz;
                        stars[i].ship.distance += global.travel_speed;
                        if (stars[i].ship.distance >= stars[i].ship.total)//到达目的地
                            stars[i].ship.stats = 1;
=======
                        GameObject.Find("Galaxy/Star" + civils[i].home[0].ToString() + "/Ship" + j.ToString()).GetComponent<Transform>().position
                            += new Vector3(civils[i].ship[j].directionx, civils[i].ship[j].directiony, civils[i].ship[j].directionz);
                        civils[i].ship[j].nowx += civils[i].ship[j].directionx;
                        civils[i].ship[j].nowy += civils[i].ship[j].directiony;
                        civils[i].ship[j].nowz += civils[i].ship[j].directionz;
                        civils[i].ship[j].distance += Speed.travel_speed;
                        if (civils[i].ship[j].distance >= civils[i].ship[j].total)//到达目的地
                            civils[i].ship[j].stats = 1;
>>>>>>> c9ac9a4e942d5354bbaead34db92897d2fd98abf
                    }
                    else//到达状态
                    {
<<<<<<< HEAD
                        if (stars[i].ship.targetv_x != stars[stars[i].ship.target].x || stars[i].ship.targetv_y != stars[stars[i].ship.target].y || stars[i].ship.targetv_z != stars[stars[i].ship.target].z)
=======
                        if (civils[i].ship[j].type == -1)//没有效果，直接返回
>>>>>>> c9ac9a4e942d5354bbaead34db92897d2fd98abf
                        {
                            Destroy(GameObject.Find("Galaxy/Star" + civils[i].home[0].ToString() + "/Ship" + j.ToString()).GetComponent<Transform>().gameObject);
                            civils[i].ship[j].life = false;
                        }
                        else if (civils[i].ship[j].type == 0)//加入合作列表
                        {
                            Destroy(GameObject.Find("Galaxy/Star" + civils[i].home[0].ToString() + "/Ship" + j.ToString()).GetComponent<Transform>().gameObject);
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
                                Destroy(GameObject.Find("Galaxy/Star" + civils[i].home[0].ToString() + "/Ship" + j.ToString()).GetComponent<Transform>().gameObject);
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
                            if (stars[civils[i].ship[j].target].civil == -1)
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
                                Destroy(GameObject.Find("Galaxy/Star" + civils[i].home[0].ToString() + "/Ship" + j.ToString()).GetComponent<Transform>().gameObject);
                                civils[i].ship[j].life = false;
                            }
                        }
                    }
                }
                if (Ship.allow)
                    if (civils[i].ship.Count < Ship.max && rd.Next() % Ship.spawn_probability == 0)//飞船生成
                    {
                        int target = rd.Next() % stars.Count, whilecnt = 0;
                        while (!stars[target].life)//生成失败
                        {
<<<<<<< HEAD
                            stars[i].time2d = time;

                            Biaxial_foil bf = new Biaxial_foil(bfs.Count, i, target, stars[i], stars[target]);
                            bfs.Add(bf);

                            GameObject _bf = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                            _bf.transform.position = new Vector3(stars[i].x, stars[i].y, stars[i].z);
                            _bf.name = "bf" + (bfs.Count - 1).ToString();
                            _bf.transform.localScale = new Vector3(2, 2, 2);
                            _bf.AddComponent<TrailRenderer>();
                            _bf.GetComponent<TrailRenderer>().time = 1;
                            _bf.GetComponent<TrailRenderer>().material = white;
                            _bf.GetComponent<Renderer>().material = white;
                            _bf.transform.parent = GameObject.Find("Biaxial_foil").GetComponent<Transform>();

                            GameObject.Find("Canvas/UI/Message2").GetComponent<Text>().text = (i + 1).ToString() + "号文明发出二向箔，目标" + (target + 1).ToString() + "号文明";
                            continue;
                        }

                    Ships ship = new Ships(i, target, stars[i].score / global.defensetimes, stars[i], stars[target]);
                    stars[i].havetarget = true;
                    stars[i].ship = ship;

                    GameObject.Find("Canvas/UI/Message").GetComponent<Text>().text = (i + 1).ToString() + "号文明发出飞船，目标" + (target + 1).ToString() + "号文明";

                    GameObject _ship = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    _ship.transform.position = new Vector3(stars[i].x, stars[i].y, stars[i].z);
                    _ship.name = "Ship";
                    _ship.transform.localScale = new Vector3(2, 2, 2);
                    _ship.AddComponent<TrailRenderer>();
                    _ship.GetComponent<TrailRenderer>().time = 1;
                    switch (ship.type)
                    {
                        case 1: { _ship.GetComponent<Renderer>().material = red; _ship.GetComponent<TrailRenderer>().material = redl; break; }
                        case -1: { _ship.GetComponent<Renderer>().material = yellow; _ship.GetComponent<TrailRenderer>().material = yellowl; break; }
                        case 0: { _ship.GetComponent<Renderer>().material = green; _ship.GetComponent<TrailRenderer>().material = greenl; break; }
=======
                            target = (target + 1) % stars.Count;
                            whilecnt++;
                            if (whilecnt > stars.Count) continue;
                        }

                        Ships ship = new Ships(i, target, stars[civils[i].home[0]].score / Civil.defensetimes, stars[civils[i].home[0]], stars[target], civils);
                        civils[i].ship.Add(ship);

                        GameObject _ship = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        _ship.transform.localPosition = new Vector3(0, 0, 0);
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
                        _ship.transform.parent = GameObject.Find("Galaxy/Star" + civils[i].home[0].ToString()).GetComponent<Transform>();
                        _ship.transform.localPosition = new Vector3(0, 0, 0);
>>>>>>> c9ac9a4e942d5354bbaead34db92897d2fd98abf
                    }
            }
        }
<<<<<<< HEAD

        GameObject.Find("Canvas/UI/ScoreBoard").GetComponent<Text>().text = "文明总数：" + (stars.Count - deathcnt).ToString()
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
                        case 1: { GameObject.Find("Canvas/UI/ScoreBoard").GetComponent<Text>().text += "<color=#FF0000>"; break; }
                        case -1: { GameObject.Find("Canvas/UI/ScoreBoard").GetComponent<Text>().text += "<color=#00FF00>"; break; }
                        case 0: { GameObject.Find("Canvas/UI/ScoreBoard").GetComponent<Text>().text += "<color=#FFFF00>"; break; }
                        default: { GameObject.Find("Canvas/UI/ScoreBoard").GetComponent<Text>().text += "<color=#FFFFFF>"; break; }
                    }
                    GameObject.Find("Canvas/UI/ScoreBoard").GetComponent<Text>().text += (temp[i].score > temp[i].scorelast ? "↑" : "↓") + temp[i].num.ToString() + "号文明得分：" + temp[i].score.ToString()
                        + ",文明类型:" + (temp[i].isout ? "外向型" : "内向型") + "</color>\n";
                }
=======
        GameObject.Find("Canvas/UI/ScoreBoard").GetComponent<Text>().text = "文明总数：" + (civils.Count - deathcivils).ToString()
            + "，fps:" + Math.Round(1.0 / Time.deltaTime).ToString() + "\n";
>>>>>>> c9ac9a4e942d5354bbaead34db92897d2fd98abf

        for (int i = 0; i < civils.Count; i++)
            if (civils[i].life)
            {
                switch (civils[i].type)
                {
<<<<<<< HEAD
                    switch (stars[i].type)
                    {
                        case 1: { GameObject.Find("Canvas/UI/ScoreBoard").GetComponent<Text>().text += "<color=#FF0000>"; break; }
                        case -1: { GameObject.Find("Canvas/UI/ScoreBoard").GetComponent<Text>().text += "<color=#00FF00>"; break; }
                        case 0: { GameObject.Find("Canvas/UI/ScoreBoard").GetComponent<Text>().text += "<color=#FFFF00>"; break; }
                        default: { GameObject.Find("Canvas/UI/ScoreBoard").GetComponent<Text>().text += "<color=#FFFFFF>"; break; }
                    }
                    GameObject.Find("Canvas/UI/ScoreBoard").GetComponent<Text>().text += (stars[i].score > stars[i].scorelast ? "↑" : "↓") + stars[i].num.ToString() + "号文明得分：" + stars[i].score.ToString()
                        + ",文明类型:" + (stars[i].isout ? "外向型" : "内向型") + "</color>\n";
=======
                    case 1: { GameObject.Find("Canvas/UI/ScoreBoard").GetComponent<Text>().text += "<color=#FF0000>"; break; }
                    case -1: { GameObject.Find("Canvas/UI/ScoreBoard").GetComponent<Text>().text += "<color=#00FF00>"; break; }
                    case 0: { GameObject.Find("Canvas/UI/ScoreBoard").GetComponent<Text>().text += "<color=#FFFF00>"; break; }
                    default: { GameObject.Find("Canvas/UI/ScoreBoard").GetComponent<Text>().text += "<color=#FFFFFF>"; break; }
>>>>>>> c9ac9a4e942d5354bbaead34db92897d2fd98abf
                }
                int score = 0;
                foreach (int it in civils[i].home)
                    score += stars[it].score;
                GameObject.Find("Canvas/UI/ScoreBoard").GetComponent<Text>().text += (score > civils[i].scorelast ? "↑" : "↓") + civils[i].num.ToString() + "号文明得分：" + score.ToString()
                    + ",文明类型:" + (civils[i].isout ? "外向型" : "内向型") + "</color>\n";
            }
    }
}
