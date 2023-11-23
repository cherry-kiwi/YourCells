using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneySystem : MonoBehaviour
{
    public static MoneySystem instance;

    public Text staminaText;
    public Text yumiText;
    public Text zemText;

    public int stamina;
    public int yumi;
    public int zem;

    public int tempYumi;
    public int tempZem;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        staminaText.text = stamina.ToString() + "/30";
        yumiText.text = yumi.ToString();
        zemText.text = zem.ToString();
    }
}
