using System.Collections.Generic;

class Stars
{
    public Stars(float x, float y, float z, int type, bool isout, int lifetime)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.score = global.startscore;
        this.life = true;
        this.type = type;
        this.isout = isout;
        this.lifetime = lifetime;
        this.havetarget = false;
        this.helpcnt = 0;
        this.helplist = new List<int>();
        this.techboomcnt = 0;

        if (this.type == 1) this.isout = true;//攻击性文明默认外向
    }
    public float x, y, z;//三维坐标
    public int score;//得分
    public bool life;//是否存活，score为0时自动归为false
    public int type;//文明类型，-1为和平型，0为中立型，1为攻击型
    public bool isout;//是否为外向型文明（是则会发飞船去探索其他星球）
    public int lifetime;//出生时间，用于在打印信息时计算用
    public bool havetarget;//是否有飞船发出（一次只能发出一艘）,isout属性为false时此值恒为false
    public Ships ship;//舰队，当havetarget属性为false时此值为null
    public int helpcnt;//帮助这个文明的文明个数，当type的值为1时此值恒为0
    public List<int> helplist;//帮助的其他文明，当type的值为1时此数组的项数恒为0
    public int techboomcnt;//技术爆炸次数
}
