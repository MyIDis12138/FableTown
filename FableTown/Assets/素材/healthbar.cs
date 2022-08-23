using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update

    public Slider slider;// Slider 控制血条血量
    public Text nowHp;
    public Image fill;

    public void maxHealthValue(int hp)
    {
        slider.maxValue = hp;
        slider.value = hp;
  
    }
    public void currentHealthValue(int hp)
    {
        slider.value = hp;
        nowHp.text = hp + "/100";
    }

}

