using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneySystem : MonoBehaviour
{
    public static MoneySystem instance;

    [Header("텍스트")]
    public Text staminaText;
    public Text[] yumiText;
    public Text[] zemText;

    //분당 생산량
    public Text yumiM;
    public Text cellSnack1M;
    //public Text zemM;

    //현재 생산량
    public Text yumiN;
    public Text cellSnack1N;

    public float Timer;
    public int MaxRoutine;
    public Text MaxRoutineT;

    [Header("재화")]
    public int stamina;
    public int yumi;
    public int zem;
    public int cellSnack1;

    [Header("생산력")]
    public int yumiPower;
    public int cellSnack1Power;

    [Header("임시 생산량")]
    public int tempYumi;
    public int tempCellSnack1;
    public int tempZem;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        //텍스트
        staminaText.text = stamina.ToString() + "/30";
        for (int i = 0; i < yumiText.Length; i++)
        {
            yumiText[i].text = yumi.ToString();
            zemText[i].text = zem.ToString();
        }

        MaxRoutineT.text = MaxRoutine + "분 / 180분";

        yumiM.text = (yumiPower * 6).ToString();
        cellSnack1M.text = (cellSnack1 * 6).ToString();

        yumiN.text = tempYumi.ToString();
        cellSnack1N.text = tempCellSnack1.ToString();

        //수급
        if (Timer > 0f)
        {
            Timer -= Time.deltaTime * 1f;
        }
        else
        {
            MaxRoutine += 1;
            tempCellSnack1 += cellSnack1Power;
            tempYumi += yumiPower;
            Timer = 10f;
        }
    }
}
