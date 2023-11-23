using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneySystem : MonoBehaviour
{
    public static MoneySystem instance;

    public Text staminaText;
    public Text[] yumiText;
    public Text[] zemText;

    public float Timer = 60;

    public int stamina;
    public int yumi;
    public int zem;

    public int yumiPower;

    public int tempYumi;
    public int tempZem;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        staminaText.text = stamina.ToString() + "/30";
        for (int i = 0; i < yumiText.Length; i++)
        {
            yumiText[i].text = yumi.ToString();
            zemText[i].text = zem.ToString();
        }

        //수급
        if (Timer > 0f)
        {
            Timer -= Time.deltaTime * 1f;
        }
        else
        {
            tempYumi += yumiPower;
            Timer = 60f;
        }
    }
}
