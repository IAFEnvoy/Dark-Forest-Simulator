using System;
using UnityEngine;
class Biaxial_foil//二向箔
{
    public Biaxial_foil(){
        
    }
    public Biaxial_foil(int num, int start, int target, Stars startstar, Stars targetstar)
    {
        this.num = num;
        this.life = true;
        this.start = start;
        this.target = target;
        this.distance = 0;
        this.total = Math.Sqrt((startstar.x - targetstar.x) * (startstar.x - targetstar.x)
            + (startstar.y - targetstar.y) * (startstar.y - targetstar.y) + (startstar.z - targetstar.z) * (startstar.z - targetstar.z));

        float asd = (float)(total / Attack_2d.speed);
        this.direction = new Vector3((targetstar.x - startstar.x) / asd, (targetstar.y - startstar.y) / asd, (targetstar.z - startstar.z) / asd);
    }
    public string ToBinary(){
        string s="";
        s+=num.ToString()+"\n";
        s+=life.ToString()+"\n";
        s+=start.ToString()+"\n";
        s+=target.ToString()+"\n";
        s+=distance.ToString()+"\n";
        s+=total.ToString()+"\n";
        s+=direction.x.ToString()+"\n";
        s+=direction.y.ToString()+"\n";
        s+=direction.z.ToString()+"\n";
        return s;
    }
    public int num;//仅供数组索引使用
    public bool life;//是否存在
    public int start;//母星的下标
    public int target;//目标恒星的下标
    public double distance, total;//已飞行距离和总距离
    public Vector3 direction;//单位方向向量
}