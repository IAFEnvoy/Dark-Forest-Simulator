using UnityEngine;
using UnityEngine.UI;

public class Accept : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(Click);
    }
    void Click()
    {
        if (GameObject.Find("Canvas/Setting").GetComponent<CanvasGroup>().alpha == 0) return;
<<<<<<< HEAD
        global.startcnt = int.Parse(GameObject.Find("Canvas/Setting/startcnt/Value").GetComponent<Text>().text);
        global.startscore = int.Parse(GameObject.Find("Canvas/Setting/startscore/Value").GetComponent<Text>().text);
        global.travel_speed = double.Parse(GameObject.Find("Canvas/Setting/travel_speed/Value").GetComponent<Text>().text);
        global.develop = int.Parse(GameObject.Find("Canvas/Setting/develop/Value").GetComponent<Text>().text);
        global.cooperation = int.Parse(GameObject.Find("Canvas/Setting/cooperation/Value").GetComponent<Text>().text);
        global.attack = int.Parse(GameObject.Find("Canvas/Setting/attack/Value").GetComponent<Text>().text);
        global.allowspawn = GameObject.Find("Canvas/Setting/allowspawn/Value").GetComponent<Text>().text == "是" ? true : false;
        global.spawnprobability = int.Parse(GameObject.Find("Canvas/Setting/spawnprobability/Value").GetComponent<Text>().text);
        global.cooldowntime = int.Parse(GameObject.Find("Canvas/Setting/cooldowntime/Value").GetComponent<Text>().text);
        global.rangex = double.Parse(GameObject.Find("Canvas/Setting/rangex/Value").GetComponent<Text>().text);
        global.rangey = double.Parse(GameObject.Find("Canvas/Setting/rangey/Value").GetComponent<Text>().text);
        global.rangez = double.Parse(GameObject.Find("Canvas/Setting/rangez/Value").GetComponent<Text>().text);
        global.defensetimes = int.Parse(GameObject.Find("Canvas/Setting/defensetimes/Value").GetComponent<Text>().text);
        global.peace = int.Parse(GameObject.Find("Canvas/Setting/peace/Value").GetComponent<Text>().text);
        global.middle = int.Parse(GameObject.Find("Canvas/Setting/middle/Value").GetComponent<Text>().text);
        global.attacks = int.Parse(GameObject.Find("Canvas/Setting/attacks/Value").GetComponent<Text>().text);
        global.allowtechboom = GameObject.Find("Canvas/Setting/allowtechboom/Value").GetComponent<Text>().text == "是" ? true : false;
        global.techboommax = int.Parse(GameObject.Find("Canvas/Setting/techboommax/Value").GetComponent<Text>().text);
        global.techboom_addon = int.Parse(GameObject.Find("Canvas/Setting/techboom_addon/Value").GetComponent<Text>().text);
        global.techboom_probability = int.Parse(GameObject.Find("Canvas/Setting/techboom_probability/Value").GetComponent<Text>().text);
        global.allow2d = GameObject.Find("Canvas/Setting/allow2d/Value").GetComponent<Text>().text == "是" ? true : false;
        global.score2d = int.Parse(GameObject.Find("Canvas/Setting/score2d/Value").GetComponent<Text>().text);
        global.speed2d = double.Parse(GameObject.Find("Canvas/Setting/speed2d/Value").GetComponent<Text>().text);
        global.cooldown2d = int.Parse(GameObject.Find("Canvas/Setting/cooldown2d/Value").GetComponent<Text>().text);
        global.allow_attack_help = GameObject.Find("Canvas/Setting/allow_attack_help/Value").GetComponent<Text>().text == "是" ? true : false;
=======
        Init.startcnt = int.Parse(GameObject.Find("Canvas/Setting/startcnt/Value").GetComponent<Text>().text);
        Init.startscore = int.Parse(GameObject.Find("Canvas/Setting/startscore/Value").GetComponent<Text>().text);
        Speed.travel_speed = double.Parse(GameObject.Find("Canvas/Setting/travel_speed/Value").GetComponent<Text>().text);
        Speed.develop = int.Parse(GameObject.Find("Canvas/Setting/develop/Value").GetComponent<Text>().text);
        Speed.cooperation = int.Parse(GameObject.Find("Canvas/Setting/cooperation/Value").GetComponent<Text>().text);
        Speed.attack = int.Parse(GameObject.Find("Canvas/Setting/attack/Value").GetComponent<Text>().text);
        SpawnCivil.allow = GameObject.Find("Canvas/Setting/allowspawn/Value").GetComponent<Text>().text == "是" ? true : false;
        SpawnCivil.probability = int.Parse(GameObject.Find("Canvas/Setting/spawnprobability/Value").GetComponent<Text>().text);
        Civil.cooldowntime = int.Parse(GameObject.Find("Canvas/Setting/cooldowntime/Value").GetComponent<Text>().text);
        SpawnCivil.rangex = double.Parse(GameObject.Find("Canvas/Setting/rangex/Value").GetComponent<Text>().text);
        SpawnCivil.rangey = double.Parse(GameObject.Find("Canvas/Setting/rangey/Value").GetComponent<Text>().text);
        SpawnCivil.rangez = double.Parse(GameObject.Find("Canvas/Setting/rangez/Value").GetComponent<Text>().text);
        Civil.defensetimes = int.Parse(GameObject.Find("Canvas/Setting/defensetimes/Value").GetComponent<Text>().text);
        SpawnCivil.peace = int.Parse(GameObject.Find("Canvas/Setting/peace/Value").GetComponent<Text>().text);
        SpawnCivil.middle = int.Parse(GameObject.Find("Canvas/Setting/middle/Value").GetComponent<Text>().text);
        SpawnCivil.attacks = int.Parse(GameObject.Find("Canvas/Setting/attacks/Value").GetComponent<Text>().text);
        TechBoom.allow = GameObject.Find("Canvas/Setting/allowtechboom/Value").GetComponent<Text>().text == "是" ? true : false;
        TechBoom.max = int.Parse(GameObject.Find("Canvas/Setting/techboommax/Value").GetComponent<Text>().text);
        TechBoom.addon = int.Parse(GameObject.Find("Canvas/Setting/techboom_addon/Value").GetComponent<Text>().text);
        TechBoom.probability = int.Parse(GameObject.Find("Canvas/Setting/techboom_probability/Value").GetComponent<Text>().text);
        Attack_2d.allow = GameObject.Find("Canvas/Setting/allow2d/Value").GetComponent<Text>().text == "是" ? true : false;
        Attack_2d.score = int.Parse(GameObject.Find("Canvas/Setting/score2d/Value").GetComponent<Text>().text);
        Attack_2d.speed = double.Parse(GameObject.Find("Canvas/Setting/speed2d/Value").GetComponent<Text>().text);
        Attack_2d.cooldown = int.Parse(GameObject.Find("Canvas/Setting/cooldown2d/Value").GetComponent<Text>().text);
        Civil.allow_attack_help = GameObject.Find("Canvas/Setting/allow_attack_help/Value").GetComponent<Text>().text == "是" ? true : false;
>>>>>>> c9ac9a4e942d5354bbaead34db92897d2fd98abf

        GameObject.Find("Canvas/Setting").GetComponent<CanvasGroup>().alpha = 0;
        GameObject.Find("Canvas/Setting").GetComponent<CanvasGroup>().interactable = false;
        GameObject.Find("Canvas/Setting").GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
}
