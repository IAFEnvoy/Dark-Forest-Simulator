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
        Init.startcnt = int.Parse(GameObject.Find("Canvas/Setting/Spawn1/startcnt/Value").GetComponent<Text>().text);
        Init.startscore = int.Parse(GameObject.Find("Canvas/Setting/Spawn1/startscore/Value").GetComponent<Text>().text);
        Speed.travel_speed = double.Parse(GameObject.Find("Canvas/Setting/Speed/travel_speed/Value").GetComponent<Text>().text);
        Speed.develop = int.Parse(GameObject.Find("Canvas/Setting/Speed/develop/Value").GetComponent<Text>().text);
        Speed.cooperation = int.Parse(GameObject.Find("Canvas/Setting/Speed/cooperation/Value").GetComponent<Text>().text);
        Speed.attack = int.Parse(GameObject.Find("Canvas/Setting/Speed/attack/Value").GetComponent<Text>().text);
        SpawnCivil.allow = GameObject.Find("Canvas/Setting/Spawn1/allowspawn/Value").GetComponent<Text>().text == "是" ? true : false;
        SpawnCivil.probability = int.Parse(GameObject.Find("Canvas/Setting/Spawn1/spawnprobability/Value").GetComponent<Text>().text);
        Civil.cooldowntime = int.Parse(GameObject.Find("Canvas/Setting/Civils/cooldowntime/Value").GetComponent<Text>().text);
        SpawnCivil.rangex = double.Parse(GameObject.Find("Canvas/Setting/Spawn1/rangex/Value").GetComponent<Text>().text);
        SpawnCivil.rangey = double.Parse(GameObject.Find("Canvas/Setting/Spawn1/rangey/Value").GetComponent<Text>().text);
        SpawnCivil.rangez = double.Parse(GameObject.Find("Canvas/Setting/Spawn1/rangez/Value").GetComponent<Text>().text);
        Civil.defensetimes = int.Parse(GameObject.Find("Canvas/Setting/Civils/defensetimes/Value").GetComponent<Text>().text);
        SpawnCivil.peace = int.Parse(GameObject.Find("Canvas/Setting/Spawn2/peace/Value").GetComponent<Text>().text);
        SpawnCivil.middle = int.Parse(GameObject.Find("Canvas/Setting/Spawn2/middle/Value").GetComponent<Text>().text);
        SpawnCivil.attacks = int.Parse(GameObject.Find("Canvas/Setting/Spawn2/attacks/Value").GetComponent<Text>().text);
        TechBoom.allow = GameObject.Find("Canvas/Setting/TechBoom/allowtechboom/Value").GetComponent<Text>().text == "是" ? true : false;
        TechBoom.max = int.Parse(GameObject.Find("Canvas/Setting/TechBoom/techboommax/Value").GetComponent<Text>().text);
        TechBoom.addon = int.Parse(GameObject.Find("Canvas/Setting/TechBoom/techboom_addon/Value").GetComponent<Text>().text);
        TechBoom.probability = int.Parse(GameObject.Find("Canvas/Setting/TechBoom/techboom_probability/Value").GetComponent<Text>().text);
        Attack_2d.allow = GameObject.Find("Canvas/Setting/2D/allow2d/Value").GetComponent<Text>().text == "是" ? true : false;
        Attack_2d.score = int.Parse(GameObject.Find("Canvas/Setting/2D/score2d/Value").GetComponent<Text>().text);
        Attack_2d.speed = double.Parse(GameObject.Find("Canvas/Setting/2D/speed2d/Value").GetComponent<Text>().text);
        Attack_2d.cooldown = int.Parse(GameObject.Find("Canvas/Setting/2D/cooldown2d/Value").GetComponent<Text>().text);
        Civil.allow_attack_help = GameObject.Find("Canvas/Setting/Civils/allow_attack_help/Value").GetComponent<Text>().text == "是" ? true : false;

        GameObject.Find("Canvas/Setting").GetComponent<CanvasGroup>().alpha = 0;
        GameObject.Find("Canvas/Setting").GetComponent<CanvasGroup>().interactable = false;
        GameObject.Find("Canvas/Setting").GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
}
