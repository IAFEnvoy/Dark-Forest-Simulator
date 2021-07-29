using System;
using System.Collections.Generic;

[Serializable]
class EmptyStars
{
    public EmptyStars(int num, float x, float y, float z)
    {
        this.num = num;
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public int num;
    public float x, y, z;
}

