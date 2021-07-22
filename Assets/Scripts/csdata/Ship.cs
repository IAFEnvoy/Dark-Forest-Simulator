using System;
using UnityEngine;
class Ships
{
    public Ships(int start, int target, double defense, Stars startstar, Stars targetstar)
    {
        this.start = start;
        this.target = target;
        this.distance = 0;
        this.total = Math.Sqrt((startstar.x - targetstar.x) * (startstar.x - targetstar.x)
            + (startstar.y - targetstar.y) * (startstar.y - targetstar.y) + (startstar.z - targetstar.z) * (startstar.z - targetstar.z));
        this.stats = 0;
        this.defense = defense;
        if (startstar.type == 1) type = 1;
        if (startstar.type == -1)
        {
            if (targetstar.type == 1) type = 1;
            if (targetstar.type == -1) type = 0;
            if (targetstar.type == 0) type = 0;
        }
        if (startstar.type == 0)
        {
            if (targetstar.type == 1) type = 1;
            if (targetstar.type == -1) type = 0;
            if (targetstar.type == 0) type = -1;
        }

        float asd = (float)(total / global.travel_speed);
        this.direction = new Vector3((targetstar.x - startstar.x) / asd, (targetstar.y - startstar.y) / asd, (targetstar.z - startstar.z) / asd);
    }
    public int start;//母星的下标
    public int target;//目标恒星的下标
    public double distance, total;//已飞行距离和总距离
    public int stats;//状态，0=飞行，1=攻击
    public double defense;//舰队强度，当发展速度所减的值等于此值时舰队会返回
    public int type;//0为合作，1为攻击，-1则不会产生任何事情
    public Vector3 direction;//单位方向向量
}

