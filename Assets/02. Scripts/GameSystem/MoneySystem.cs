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
    public Text yumiN2;
    public Text cellSnack1N2;

    public float Timer;
    public int MaxRoutine;
    public Text MaxRoutineT;
    public Text MaxRoutineT2;
    public GameObject MaxRoutineS;
    public GameObject MaxRoutineS2;

    [Header("건물 보유 여부")]
    public bool CellFactory;

    [Header("콘텐츠")]
    public List<GameObject> CellFactoryContents;

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
        //건물 보유 여부
        if(CellFactory == true)
        {
            for(int i = 0; i < CellFactoryContents.Count; i++)
            {
                CellFactoryContents[i].SetActive(true);
            }
        }
        else if (CellFactory == false)
        {
            for (int i = 0; i < CellFactoryContents.Count; i++)
            {
                CellFactoryContents[i].SetActive(false);
            }
        }

        //텍스트
        staminaText.text = stamina.ToString() + "/30";
        for (int i = 0; i < yumiText.Length; i++)
        {
            yumiText[i].text = yumi.ToString();
            zemText[i].text = zem.ToString();
        }

        MaxRoutineT.text = MaxRoutine + "분 / 180분";
        MaxRoutineS.GetComponent<Slider>().value = (float)MaxRoutine / 180f;

        MaxRoutineT2.text = MaxRoutine.ToString() + "분 / 180분";
        MaxRoutineS2.GetComponent<Slider>().value = (float)MaxRoutine / 180f;

        yumiM.text = (yumiPower * 6).ToString();
        cellSnack1M.text = (cellSnack1Power * 6).ToString();

        yumiN.text = tempYumi.ToString();
        cellSnack1N.text = tempCellSnack1.ToString();
        yumiN2.text = tempYumi.ToString();
        cellSnack1N2.text = tempCellSnack1.ToString();

        //수급
        if (MaxRoutine < 180)
        {
            if (Timer > 0f)
            {
                Timer -= Time.deltaTime * 1f;
            }
            else
            {
                MaxRoutine += 1;
                tempCellSnack1 += cellSnack1Power;
                tempYumi += yumiPower;
                Timer = 60f;
            }
        }
    }

    public void Cheat()
    {
        yumi += 5000;
        cellSnack1 += 10;
        zem += 500;
    }
}
