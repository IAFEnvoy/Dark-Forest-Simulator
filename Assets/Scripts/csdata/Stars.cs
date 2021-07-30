using System.Collections.Generic;
using System;

[Serializable]
class Stars
{
    public Stars(int num, float x, float y, float z)
    {
        this.num = num;
        this.x = x;
        this.y = y;
        this.z = z;
        this.life = true;
        this.civil = -1;
        this.score = Init.startscore;
    }
    public int num;//仅供数组索引使用
    public float x, y, z;//三维坐标
    public bool life;//是否存在
    public int civil;//上面存在的文明的编号，如没有文明则为-1
    public int score;//得分
}
