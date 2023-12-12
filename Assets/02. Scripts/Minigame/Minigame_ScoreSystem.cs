using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Minigame_ScoreSystem : MonoBehaviour
{
    [Header("세포")]
    public CellData myCell;
    public CellSkill skillInfo;

    [Header("인게임")]
    public TMP_Text _Score;
    public TMP_Text _Combo_text;
    public TMP_Text _Goal;


    public float _Time = 120;
    public int scoreInt = 0;
    public int comboInt = 0;
    public int goal = 0;

    public event Action Com_bo;

    //public event Action GameEndset;


    //[Header("결과창")]
    //public GameObject Result_main;
    //public TMP_Text Clear_or_Failed;
    //public TMP_Text result_goal;
    //public TMP_Text result_Score;
    //public UnityEngine.UI.Slider result_Slider;
    //public TMP_Text result_Money;
    //public GameObject result_money_main;
    //public UnityEngine.UI.Image result_cellImage;
    //public TMP_Text CellSkillInfo;

    //public TMP_Text Final_Score;



    // Start is called before the first frame update
    void Start()
    {
        goal = StageCtrl.instance.goalScore;

        _Goal.text = "목표: " + goal;
    }

    #region Score
    public void textpUpdate()
    {
        _Score.text = scoreInt + "";

        if (comboInt > 1)
        {
            _Combo_text.text = comboInt + " Combo! ";
        }
        else
        {
            _Combo_text.text = "";
        }
    }

    public void Combo_and_Score_Update()
    {
        scoreInt += (comboInt + 20);

        Com_bo();
        comboInt += 1;
    }
    #endregion

    //public void Result_Start()
    //{
    //    GameStart.GamePlaying = false;
    //    //Millstone_scr.GetComponent<BoxCollider2D>().enabled = false;
    //    //spw_er.gameObject.SetActive(false);
    //    GameEndset();
    //    Result_main.SetActive(true);
    //    result_ScoreSlide();
    //}


    //public void result_ScoreSlide()
    //{
    //    result_goal.text = "" + goal;
    //    result_Score.text = "" + skillInfo.E_sung_cell(scoreInt);
    //    CellSkillInfo.text = skillInfo.E_sung_cell_sInfo() + " " + scoreInt + " + " + (skillInfo.E_sung_cell(scoreInt) - scoreInt);
    //    StartCoroutine(result_SliderAmount_coin());
    //    MoneySystem.instance.yumi += skillInfo.E_sung_cell(scoreInt / 100);
    //}

    //private IEnumerator result_SliderAmount_coin()
    //{
    //    Debug.Log("start");
    //    float HowOnePer = skillInfo.E_sung_cell(scoreInt) * 100 / goal; // 내 점수가 몇퍼인지 산출 ) 목표가 200, 점수가 50 이면 25 출력
    //    float k = 0;

    //    while (true)
    //    {
    //        k += Time.deltaTime * HowOnePer / 2f;
    //        result_Slider.value = k;
    //        Debug.Log("update");
    //        if (k >= HowOnePer || result_Slider.value >= 100)
    //        {
    //            break;
    //        }
    //        yield return null;
    //    }

    //    yield return new WaitForSeconds(1);

    //    if (HowOnePer >= 100)
    //    {
    //        Clear_or_Failed.text = "클리어 ! ";
    //    }
    //    else if (HowOnePer < 100)
    //    {
    //        Clear_or_Failed.text = "실패... ";
    //    }

    //    yield return new WaitForSeconds(1);

    //    result_money_main.SetActive(true);
    //    result_Money.text = skillInfo.E_sung_cell(scoreInt / 100) + " 유미 획득!";

    //    Final_Score.text = skillInfo.E_sung_cell(scoreInt) + " 점!";

    //}

    //public void PauseGame()
    //{
    //    Time.timeScale = 0;
    //}
    //public void ResumeGame()
    //{
    //    Time.timeScale = 1;
    //}

}
