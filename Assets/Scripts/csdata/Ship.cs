using System;
using System.Collections.Generic;

[Serializable]
class Ships
{
    public Ships(int start, int target, double defense, Stars startstar, Stars targetstar, List<Civils> civils)
    {
        this.life = true;
        this.start = start;
        this.target = target;
        this.distance = 0;
        this.total = Math.Sqrt((startstar.x - targetstar.x) * (startstar.x - targetstar.x)
            + (startstar.y - targetstar.y) * (startstar.y - targetstar.y) + (startstar.z - targetstar.z) * (startstar.z - targetstar.z));
        this.stats = 0;
        this.defense = defense;
        if (targetstar.civil == -1) type = 2;
        else if (civils[startstar.civil].type == 1) type = 1;
        else if (civils[startstar.civil].type == -1)
        {
            if (civils[targetstar.civil].type == 1) if (Civil.allow_attack_help) type = 0; else type = 1;
            if (civils[targetstar.civil].type == -1) type = 0;
            if (civils[targetstar.civil].type == 0) type = 0;
        }
        else if (civils[startstar.civil].type == 0)
        {
            if (civils[targetstar.civil].type == 1) type = 1;
            if (civils[targetstar.civil].type == -1) type = 0;
            if (civils[targetstar.civil].type == 0) type = -1;
        }

        float asd = (float)(total / Speed.travel_speed);
        this.directionx = (targetstar.x - startstar.x) / asd;
        this.directiony = (targetstar.y - startstar.y) / asd;
        this.directionz = (targetstar.z - startstar.z) / asd;

        this.nowx = startstar.x;
        this.nowy = startstar.y;
        this.nowz = startstar.z;
    }
    public bool life;//是否存活
    public int start;//母星的下标
    public int target;//目标恒星的下标
    public double distance, total;//已飞行距离和总距离
    public int stats;//状态，0=飞行，1=攻击
    public double defense;//舰队强度，当发展速度所减的值等于此值时舰队会返回
    public int type;//0为合作，1为攻击，-1则不会产生任何事情，2为探索
    public float directionx, directiony, directionz;//单位方向向量
    public float nowx, nowy, nowz;//当前位置
}

