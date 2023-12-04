using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class hpBar : MonoBehaviour
{
    private Slider HP_Bar;
    public TMP_Text _Timer;
    [SerializeField] private Main_ScoreSystem _ScoreSystem;


    protected float Hp_To_Time; //* 체력을 시간으로 환전 // 100hp 에 1분
    private float Hp_Time_conver; // Hp-to-time의 1% 값을 넣음
    public float maxHealth; //* 세포의 체력 / 나중에 체력 받아오는 시스템 필요

    float t = 0;

    private void Start()
    {
        maxHealth = StageCtrl.instance.SelectCell.hP;


        HP_Bar = GetComponent<Slider>();
        Hp_To_Time = maxHealth * 0.6f; //체력 시간 전환 설정. 100이 1분
                                       // 슬라이더의 밸류값에 연결 필요
        Hp_Time_conver = Hp_To_Time / 100 * 1;
        _Timer.text = Mathf.Floor(Hp_To_Time / 60) + "분" + Mathf.Floor(Hp_To_Time % 60) + "초";
        StartCoroutine(Timer_Hp_decrease());

    }


    private IEnumerator Timer_Hp_decrease()
    {
        while (Hp_To_Time > 0)
        {
            if (GameStart.GamePlaying)
            {
                Hp_To_Time -= Time.deltaTime;
                t += Time.deltaTime;
                _Timer.text = Mathf.Floor(Hp_To_Time / 60) + "분" + Mathf.Floor(Hp_To_Time % 60) + "초";

                if(t >= Hp_Time_conver)
                {
                    HP_Bar.value -= 0.01f;
                    t = 0; 
                }
            }
            yield return null;
        }
        _Timer.text = "끝!";
        Game_is_End();
    }

    public void umm_didyouHit()
    {
        float Tenpercent = 10 / Hp_Time_conver; //이 시간이 지나야 1퍼임
        HP_Bar.value -= 0.01f * Tenpercent;
        Hp_To_Time -= 10;
    }

    public void Game_is_End()
    {
        _ScoreSystem.Result_Start();
    }


    //public void SetHp(float amount) //*Hp설정
    //{
    //    maxHealth = amount;
    //    Hp_To_Time = maxHealth * 0.6f;
    //} 나중에 사용할 부분 - 세포 체력 받아오기


}
