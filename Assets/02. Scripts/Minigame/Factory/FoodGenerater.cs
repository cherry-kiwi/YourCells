using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class FoodGenerater : MonoBehaviour
{
    

    public GameObject Food;
    public List<GameObject> Foods = new List<GameObject>();
    public List<Transform> FoodPoint = new List<Transform>();

    public Button[] btn;

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

    [SerializeField] private float ShakeAmount;
    float ShakeTime;
    Vector3 initPos;
    [SerializeField] private Transform _Cam;

    private void Start()
    {
        myCell = StageCtrl.instance.SelectCell;
        goal = StageCtrl.instance.goalScore;

        _Goal.text = "목표: " + goal;
        result_cellImage.sprite = myCell.image;

        CellSkillInfo = result_cellImage.GetComponentInChildren<TMP_Text>();

        initPos = _Cam.transform.position;
    }



    private void Update()
    {
        if (GameStart.GamePlaying == true)
        {
            Timer += Time.deltaTime;

            if (Foods.Count < 5)
            {
                if (Timer > GenerateCool)
                {
                    Generate();
                    StartCoroutine(ConveyorOn(Foods.Count));
                    

                    Timer = 0;
                }
            }
            ChageLayer();
        }

        if (ShakeTime > 0)
        {
            _Cam.position = UnityEngine.Random.insideUnitSphere * ShakeAmount + initPos;
            ShakeTime -= Time.deltaTime;
        }
        else
        {
            ShakeTime = 0;
            _Cam.position = initPos;
        }

    }

    public void VibeTime(float _time)
    {
        ShakeTime = _time;
    }

    void Generate()
    {
        Foods.Add(Instantiate(Food, transform.position, Quaternion.identity));
    }

    void ChageLayer()
    {
        //for (int i = 0; i < Foods.Count; i++)
        //{
        //    Foods[i].transform.GetComponent<SpriteRenderer>().sortingOrder = -i;
        //}
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
            VibeTime(0.1f);
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
            VibeTime(0.1f);
        }
    }


    private IEnumerator ConveyorOn(int Count)
    {
        btn[0].interactable = false;
        btn[1].interactable = false;

        for (int k = 0; k < Count; k++)
        {
            while (Vector2.Distance(Foods[k].transform.position, FoodPoint[k].transform.position) >= 0.1f)
            {
                Foods[k].transform.position = Vector2.MoveTowards(Foods[k].transform.position, FoodPoint[k].transform.position, 0.3f);
                yield return null;
            }

            switch (k)
            {
                case 0:
                    Foods[k].transform.localScale = new Vector2(2, 2);
                    break;

                case 1:
                    Foods[k].transform.localScale = new Vector2(1.5f, 1.5f);
                    break;

                case 2:
                    Foods[k].transform.localScale = new Vector2(1.2f, 1.2f);
                    break;

                case 3:
                    Foods[k].transform.localScale = new Vector2(0.8f, 0.8f);
                    break;

                case 4:
                    Foods[k].transform.localScale = new Vector2(0.6f, 0.6f);
                    break;

                default:
                    break;
            }
        }
        btn[0].interactable = true;
        btn[1].interactable = true;

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

    #region 결과창

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

    #endregion


    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

}
