class global
{
    public static int startcnt = 0;//初始文明数量
    public static int startscore = 0;//初始得分
    public static double travel_speed = 1.5;//旅行速度
    public static int develop = 10;//发展速度
    public static int cooperation = 5;//合作的时候额外的发展速度
    public static int attack = -30;//战争的时候额外的发展速度
                                   //（通常设置为小于-10的数，当然你也可以设置为正的。。。）
    public static bool allowspawn = true;//是否生成新文明
    public static int spawnprobability = 100;//生成概率，填1000则每一次update有1/1000的概率生成新文明
    public static int cooldowntime = 500;//需要多少score才能发射飞船
    public static double rangex = 200, rangey = 200, rangez = 200;//生成范围
    public static int defensetimes = 1;//score和舰队强度的比值
    public static int peace=20, middle=20, attacks=60;//生成概率，和必须为100，否则出错
}

