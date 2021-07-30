using System.Collections.Generic;
using System;

[Serializable]
class Civils
{
    public Civils(int num,int home, int type, bool isout, int lifetime)
    {
        this.num = num;
        this.home=new List<int>();
        this.ship=new List<Ships>();
        this.home.Add(home);
        this.scorelast = 0;
        this.life = true;
        this.type = type;
        this.isout = isout;
        this.lifetime = lifetime;
        this.helpcnt = 0;
        this.helplist = new List<int>();
        this.techboomcnt = 0;
        this.time2d = -Attack_2d.cooldown;

        if (this.type == 1) this.isout = true;//攻击性文明默认外向
    }
    public int num;//仅供数组索引使用
    public List<int> home;//自己的所有星系
    public int scorelast;//上一轮得分，仅供计分板计算使用
    public bool life;//是否存活，score为0时自动归为false
    public int type;//文明类型，-1为和平型，0为中立型，1为攻击型
    public bool isout;//是否为外向型文明（是则会发飞船去探索其他星球）
    public int lifetime;//出生时间，用于在打印信息时计算用
    public List<Ships> ship;//舰队，当havetarget属性为false时此值为null
    public int helpcnt;//帮助这个文明的文明个数
    public List<int> helplist;//帮助的其他文明，当type的值为1时此数组的项数恒为0
    public int techboomcnt;//技术爆炸次数
    public int time2d;//上一次使用二向箔时间
}
