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

public class Main_ScoreSystem : MonoBehaviour
{
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

    Touch toto;
    public float _Time = 120;
    public int scoreInt = 0;
    public int comboInt = 0;
    public int goal = 15000;

    bool Stun = false;
    [SerializeField] private GameObject stunEft;
    [SerializeField] private Spawner spw_er;

    public event Action Com_bo;
    Vector2 Touch_start_pos;

    private void Start()
    {
        _Goal.text = "Goal : " + goal;
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
                toto = Input.GetTouch(0);

                if (toto.phase == TouchPhase.Began)
                {
                    if (clickCol != null && clickCol.tag == "Mill" && !Stun)
                    {
                        Combo_and_Score_Update();
                        textpUpdate();
                        clickCol.TryGetComponent(out MillStone mill__k);
                        mill__k.BingBingDolaganeun();
                    } //콤보,점수,텍스트 업데이트
                    else if (clickCol != null && clickCol.tag == "Obs")
                    {
                        if (clickCol.TryGetComponent(out Obstacle obs))
                        {
                            obs.Bomb_obs_Click();
                        }
                    }
                    else if( clickCol != null && clickCol.name.StartsWith("Slide"))
                    {
                        Touch_start_pos = toto.position;
                    }

                }

                if (clickCol != null && toto.phase == TouchPhase.Moved)
                {
                    if (clickCol.TryGetComponent(out FatMan_Slide_Range ok_slide))
                    {
                        if (Vector2.Distance(Touch_start_pos, toto.position) >= 500)
                        {
                            Touch_start_pos = toto.position;
                            ok_slide.Slide_Succes();
                        }
                    }
                }


            }
        }
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
        spw_er.gameObject.SetActive(false);
        Result_main.SetActive(true);
        result_ScoreSlide();
    }

    
    public void result_ScoreSlide()
    {
        result_goal.text = ""+goal;
        result_Score.text = "" + scoreInt;
        StartCoroutine(result_SliderAmount_coin());
    }

    private IEnumerator result_SliderAmount_coin()
    {
        Debug.Log("start");
        float HowOnePer = scoreInt * 100 / goal; // 내 점수가 몇퍼인지 산출 ) 목표가 200, 점수가 50 이면 25 출력
        float k = 0;

        while (true) 
        {
            k += 0.05f;
            result_Slider.value += 0.05f;
            Debug.Log("update");
            if (k >= HowOnePer)
            {
                break;
            }
            yield return null;
        }

        yield return new WaitForSeconds(1);

        if(HowOnePer >= 100)
        {
            Clear_or_Failed.text = "Clear ! ";
        }else if(HowOnePer < 100) 
        {
            Clear_or_Failed.text = "Failed... ";
        }

        yield return new WaitForSeconds(1);

        result_money_main.SetActive(true);
        result_Money.text = "" + scoreInt;

    }

}
