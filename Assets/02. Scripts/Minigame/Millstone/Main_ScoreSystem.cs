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

    Touch toto;
    public float _Time = 120;
    public int scoreInt = 0;
    public int comboInt = 0;

    public event Action Com_bo;

    Vector2 Touch_start_pos;

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
                    if (clickCol != null && clickCol.tag == "Mill")
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

}
