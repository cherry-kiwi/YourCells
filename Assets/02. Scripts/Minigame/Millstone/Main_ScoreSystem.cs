using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class  Main_ScoreSystem : MonoBehaviour
{
    public CellData myCell;
    public CellSkill skillInfo;

    public TMP_Text _Score;
    public TMP_Text _Combo_text;
    public TMP_Text _Goal;

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

    private MillStone Millstone_scr;

    
    Touch[] toto;
    public float _Time = 120;
    public int scoreInt = 0;
    public int comboInt = 0;
    public int goal = 0;

    bool Stun = false;
    [SerializeField] private GameObject stunEft;
    [SerializeField] private Spawner spw_er;
    [SerializeField] private ParticleSystem[] Bomb_counterParticle;

    public event Action Com_bo;
    Vector2 Touch_start_pos;

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

        #region  Click info
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 clickPos = new Vector2(worldPos.x, worldPos.y);
        Collider2D clickCol = Physics2D.OverlapPoint(clickPos);
        #endregion

        if (GameStart.GamePlaying)
        {
            if (Input.touchCount > 0)
            {
                for (int i = 0; i < Input.touchCount; i++)
                {
                    toto[i] = Input.GetTouch(i);


                    if (toto[i].phase == TouchPhase.Began)
                    {
                        if (clickCol != null && clickCol.tag == "Mill" && !Stun)
                        {
                            Combo_and_Score_Update();
                            textpUpdate();
                            clickCol.TryGetComponent(out Millstone_scr);
                            Millstone_scr.BingBingDolaganeun();
                        } //콤보,점수,텍스트 업데이트
                        else if (clickCol != null && clickCol.tag == "Obs")
                        {
                            if (clickCol.TryGetComponent(out Obstacle obs))
                            {
                                obs.Bomb_obs_Click();
                                Bomb_Counter_Eft(clickCol.transform);
                            }
                        }
                        else if (clickCol != null && clickCol.name.StartsWith("Slide"))
                        {
                            Touch_start_pos = toto[i].position;
                        }

                    }

                    if (clickCol != null && toto[i].phase == TouchPhase.Moved)
                    {
                        if (clickCol.TryGetComponent(out FatMan_Slide_Range ok_slide))
                        {
                            if (Vector2.Distance(Touch_start_pos, toto[i].position) >= 500)
                            {
                                Touch_start_pos = toto[i].position;
                                ok_slide.Slide_Succes();
                            }
                        }
                    }
                }


            }
        }
    }

    private void Bomb_Counter_Eft(Transform point)
    {
        int i = 0;
        if (Bomb_counterParticle[i].isPlaying == true)
        {
            i++;
        }
        Bomb_counterParticle[i].transform.position = point.position;
        Bomb_counterParticle[i].Play();
    }

    public void textpUpdate()
    {
        _Score.text = scoreInt + "";

        if (comboInt > 1)
        {
            _Combo_text.text = comboInt + " Combo! ";
        } else
        {
            _Combo_text.text = "";
        }
    }


    private void Combo_and_Score_Update()
    {
        scoreInt += (comboInt + 20);

        Com_bo();
        comboInt += 1;
    }

    public IEnumerator StunFunc()
    {
        Stun = true;
        stunEft.SetActive(true);
        yield return new WaitForSeconds(2);
        Stun= false;
        stunEft.SetActive(false);
    }



    public void Result_Start()
    {
        GameStart.GamePlaying = false;
        Millstone_scr.GetComponent<BoxCollider2D>().enabled= false;
        spw_er.gameObject.SetActive(false);
        Result_main.SetActive(true);
        result_ScoreSlide();
    }

    
    public void result_ScoreSlide()
    {
        result_goal.text = ""+goal;
        result_Score.text = "" + skillInfo.E_sung_cell(scoreInt);
        CellSkillInfo.text = skillInfo.E_sung_cell_sInfo() + " " + scoreInt + " + " + (skillInfo.E_sung_cell(scoreInt) - scoreInt);
        StartCoroutine(result_SliderAmount_coin());
        MoneySystem.instance.yumi += skillInfo.E_sung_cell(scoreInt / 100);
    }

    private IEnumerator result_SliderAmount_coin()
    {
        Debug.Log("start");
        float HowOnePer = skillInfo.E_sung_cell(scoreInt) * 100 / goal; // 내 점수가 몇퍼인지 산출 ) 목표가 200, 점수가 50 이면 25 출력
        float k = 0;

        while (true) 
        {
            k += Time.deltaTime * HowOnePer/2f;
            result_Slider.value = k;
            Debug.Log("update");
            if (k >= HowOnePer || result_Slider.value >= 100)
            {
                break;
            }
            yield return null;
        }

        yield return new WaitForSeconds(1);

        if(HowOnePer >= 100)
        {
            Clear_or_Failed.text = "클리어 ! ";
        }else if(HowOnePer < 100) 
        {
            Clear_or_Failed.text = "실패... ";
        }

        yield return new WaitForSeconds(1);

        result_money_main.SetActive(true);
        result_Money.text = skillInfo.E_sung_cell(scoreInt/100) + " 유미 획득!";

        Final_Score.text = skillInfo.E_sung_cell(scoreInt) + " 점!";

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
