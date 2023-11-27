using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpBar : MonoBehaviour
{
    private Slider HP_Bar;

    protected float Hp_To_Time; //* 현재 체력
    public float maxHealth; //* 시작 체력 / 나중에 체력 받아오는 시스템 필요

    

    private void Start()
    {
        HP_Bar = GetComponent<Slider>();
        Hp_To_Time = maxHealth * 0.6f; //체력 시간 전환 설정
        // 슬라이더의 밸류값에 연결 필요
    }



    public void SetHp(float amount) //*Hp설정
    {
        maxHealth = amount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
