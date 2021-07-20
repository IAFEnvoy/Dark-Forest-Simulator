using System;

class Ships
{
    public Ships(int start, int target, double defense,Stars startstar,Stars targetstar)
    {
        this.start = start;
        this.target = target;
        this.distance = 0;
        this.total = Math.Sqrt((startstar.x - targetstar.x) * (startstar.x - targetstar.x) + (startstar.y - targetstar.y) * (startstar.y - targetstar.y));
        this.stats = 0;
        this.defense = defense;
    }
    public int start;//母星的下标
    public int target;//目标恒星的下标
    public double distance, total;//已飞行距离和总距离
    public int stats;//状态，0=飞行，1=攻击
    public double defense;//舰队强度，当发展速度所减的值等于此值时舰队会返回
}

