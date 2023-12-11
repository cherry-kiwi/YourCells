using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FoodGenerater : MonoBehaviour
{
    public GameObject Food;
    public List<GameObject> Foods;

    float Timer = 0.0f;
    float GenerateCool = 0.3f;

    public TextMeshProUGUI scoreText;

    int Score = 0;
    public int goal = 0;

    public CellData myCell;
    public CellSkill skillInfo;

    public int comboInt = 0;
    public event Action Com_bo; 
    public TMP_Text _Combo_text;
    public TMP_Text _Goal;

    [SerializeField] private hpBar_Fac ha_bar;

    [Header("Result")]
    public GameObject Result_main;
    public TMP_Text Clear_or_Failed;
    public TMP_Text result_goal;
    public TMP_Text result_Score;
    public UnityEngine.UI.Slider result_Slider;
    public TMP_Text result_Money;
    public GameObject result_money_main;
    public UnityEngine.UI.Image result_cellImage;
    public TMP_Text CellSkillInfo;
    public TMP_Text Final_Score;

    private void Start()
    {
        myCell = StageCtrl.instance.SelectCell;
        goal = StageCtrl.instance.goalScore;

        _Goal.text = "목표: " + goal;
        result_cellImage.sprite = myCell.image;

        CellSkillInfo = result_cellImage.GetComponentInChildren<TMP_Text>();
    }

    private void Update()
    {

        if (GameStart.GamePlaying == true)
        {
            Timer += Time.deltaTime;

            if (Foods.Count < 10)
            {
                if (Timer > GenerateCool)
                {
                    Generate();

                    Timer = 0;
                }
            }

            ChageLayer();
        }
    }

    void Generate()
    {
        Foods.Add(Instantiate(Food, transform.position, Quaternion.identity));
    }

    void ChageLayer()
    {
        for (int i = 0; i < Foods.Count; i++)
        {
            Foods[i].transform.GetComponent<SpriteRenderer>().sortingOrder = -i;
        }
    }

    public void LeftBtn()
    {
        if(Foods[0].GetComponent<Food>().Tag == "딸기")
        {
            Foods[0].GetComponent<BoxCollider2D>().enabled = false;
            Foods[0].GetComponent<Rigidbody2D>().AddForce(Vector2.left * 1000);
            Foods.Remove(Foods[0]);

            Score += 1;
            Com_bo();
            comboInt += 1;
            textpUpdate();
        }
        else
        {
            ha_bar.umm_didyouHit();
            comboInt = 0;
            textpUpdate();
        }
    }

    public void DownBtn()
    {
        if (Foods[0].GetComponent<Food>().Tag == "쌀")
        {
            Foods[0].GetComponent<BoxCollider2D>().enabled = false;
            Foods[0].GetComponent<Rigidbody2D>().AddForce(Vector2.down * 1000);
            Foods.Remove(Foods[0]);

            Score += 1;
            Com_bo();
            comboInt += 1;
            textpUpdate();
        }
        else
        {
            ha_bar.umm_didyouHit();
            comboInt = 0;
            textpUpdate();
        }
    }

    public void RightBtn()
    {
        if (Foods[0].GetComponent<Food>().Tag == "떡꼬치")
        {
            Foods[0].GetComponent<BoxCollider2D>().enabled = false;
            Foods[0].GetComponent<Rigidbody2D>().AddForce(Vector2.right * 1000);
            Foods.Remove(Foods[0]);

            Score += 1;
            Com_bo();
            comboInt += 1;
            textpUpdate();
        }
        else
        {
            ha_bar.umm_didyouHit();
            comboInt = 0;
            textpUpdate();

        }
    }

    public void textpUpdate()
    {

        scoreText.text = "<sprite=0> " + Score.ToString();

        if (comboInt > 1)
        {
            _Combo_text.text = comboInt + " Combo! ";
        }
        else
        {
            _Combo_text.text = "";
        }
    }


    public void Result_Start()
    {
        GameStart.GamePlaying = false;
        //버튼 비활성화
        //스포너 비활성화
        Result_main.SetActive(true);
        result_ScoreSlide();
    }


    public void result_ScoreSlide()
    {
        result_goal.text = "" + goal;
        result_Score.text = "" + skillInfo.E_sung_cell(Score);
        CellSkillInfo.text = skillInfo.E_sung_cell_sInfo() + " " + Score + " + " + (skillInfo.E_sung_cell(Score) - Score);
        StartCoroutine(result_SliderAmount_coin());
        MoneySystem.instance.yumi += skillInfo.E_sung_cell(Score / 100);
    }

    private IEnumerator result_SliderAmount_coin()
    {
        Debug.Log("start");
        float HowOnePer = skillInfo.E_sung_cell(Score) * 100 / goal; // 내 점수가 몇퍼인지 산출 ) 목표가 200, 점수가 50 이면 25 출력
        float k = 0;

        while (true)
        {
            k += Time.deltaTime * HowOnePer / 2f;
            result_Slider.value = k;
            Debug.Log("update");
            if (k >= HowOnePer || result_Slider.value >= 100)
            {
                break;
            }
            yield return null;
        }

        yield return new WaitForSeconds(1);

        if (HowOnePer >= 100)
        {
            Clear_or_Failed.text = "클리어 ! ";
        }
        else if (HowOnePer < 100)
        {
            Clear_or_Failed.text = "실패... ";
        }

        yield return new WaitForSeconds(1);

        result_money_main.SetActive(true);
        result_Money.text = skillInfo.E_sung_cell(Score / 100) + " 유미 획득!";

        Final_Score.text = skillInfo.E_sung_cell(Score) + " 점!";

    }






    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

}
