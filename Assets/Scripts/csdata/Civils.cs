using System;

[Serializable]
class Civils//文明
{
    public Civils(int num, int star, int type, bool isout, int timenow)
    {
        this.num = num;
        this.home.Add(star);
        this.type = type;
        this.isout = isout;
        this.lifetime = timenow;
        this.havetarget = false;
    }
    public int num;//仅供数组索引使用
    public List<int> home;//所有殖民的星系
    public int type;//文明类型，-1为和平型，0为中立型，1为攻击型
    public bool isout;//是否为外向型文明（是则会发舰队去探索其他星球）
    public int lifetime;//出生时间，用于在打印信息时计算用
    public bool havetarget;//是否有舰队发出（一次只能发出一支）,isout属性为false时此值恒为false
    public Ships ship;//舰队，当havetarget属性为false时此值为null
    public int techboomcnt;//技术爆炸次数
    public int time2d;//上一次使用二向箔时间
}