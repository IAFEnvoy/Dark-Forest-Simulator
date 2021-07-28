using System;
using UnityEngine;
using UnityEngine.UI;

public class GetSliderValue : MonoBehaviour
{
    public Slider slider;
    public bool toboolvalue = false;
    public int rounddigit = 0;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (toboolvalue) text.text = slider.value == 0 ? "否" : "是";
        else text.text = Math.Round(slider.value, rounddigit).ToString();
    }
}
