using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Minigame_Obj : MonoBehaviour
{

    [Header("세포")]
    public CellData myCell;
    public CellSkill skillInfo;

    [Header("인게임")]
    public TMP_Text _Score;
    public TMP_Text _Combo_text;
    public TMP_Text _Goal;

    [Header("결과창")]
    public GameObject Result_main; //결과창

    public TMP_Text Clear_or_Failed; //성공 / 실패 텍스트

    public TMP_Text result_goal; // 목표점수
    public TMP_Text result_Score; //현재점수
    public UnityEngine.UI.Slider result_Slider; //두 점수 간 슬라이더

    public TMP_Text result_Money; //유미코인 아이콘
    public GameObject result_money_main; //유미코인 수치

    public UnityEngine.UI.Image result_cellImage; //세포스킬창 아이콘
    public TMP_Text CellSkillInfo; //세포스킬 정보

    public TMP_Text Final_Score; //최종점수


    // Start is called before the first frame update
    void Start()
    {
        result_cellImage.sprite = myCell.image;

        CellSkillInfo = result_cellImage.GetComponentInChildren<TMP_Text>();
        CellSkillInfo.text = skillInfo.E_sung_cell_sInfo();
    }

    public void Result_Start()
    {
        GameStart.GamePlaying = false;
        Result_main.SetActive(true);
        result_ScoreSlide();
    }


    public void result_ScoreSlide()
    {

        StartCoroutine(result_SliderAmount_coin());
    }

    private IEnumerator result_SliderAmount_coin()
    {
        Debug.Log("start");
        //float HowOnePer = scoreInt * 100 / goal; // 내 점수가 몇퍼인지 산출 ) 목표가 200, 점수가 50 이면 25 출력
        float k = 0;

        while (true)
        {
            k += Time.deltaTime * 0.1f;
            result_Slider.value += k;
            Debug.Log("update");
            //if (k >= HowOnePer || result_Slider.value >= 100)
            //{
            //    break;
            //}
            yield return null;
        }

        //yield return new WaitForSeconds(1);

        //if (HowOnePer >= 100)
        //{
        //    Clear_or_Failed.text = "Clear ! ";
        //}
        //else if (HowOnePer < 100)
        //{
        //    Clear_or_Failed.text = "Failed... ";
        //}

        //yield return new WaitForSeconds(1);

        //result_money_main.SetActive(true);
        //result_Money.text = "" + skillInfo.E_sung_cell(scoreInt);


        //Final_Score.text = skillInfo.E_sung_cell(scoreInt) + " Score !";

    }
}
