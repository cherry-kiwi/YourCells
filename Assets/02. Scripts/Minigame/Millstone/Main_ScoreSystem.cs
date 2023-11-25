using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Main_ScoreSystem : MonoBehaviour
{
    public TMP_Text _Score;
    public TMP_Text _Timer;

    Touch toto;
    public float _Time = 120;
    public int scoreInt = 0;

    public event Action Com_bo;

    private void Update()
    {
        _Score.text = "Score : " + scoreInt;
        _Timer.text = Mathf.Floor(_Time / 60) + "m" + Mathf.Floor( _Time % 60) + "s";

        if (_Time <= 0)
        {
            UnityEditor.EditorApplication.isPaused = true;
        }

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 clickPos = new Vector2(worldPos.x, worldPos.y);
        Collider2D clickCol = Physics2D.OverlapPoint(clickPos);

        if (GameStart.GamePlaying)
        {
            _Time -= Time.deltaTime;
            if (Input.touchCount > 0)
            {
                toto = Input.GetTouch(0);

                if (toto.phase == TouchPhase.Began)
                {
                    if (clickCol != null && clickCol.tag == "Mill")
                    {
                        Debug.Log("Score");
                        scoreInt += 1;
                        Com_bo();
                    }

                    if (clickCol != null && clickCol.tag == "Obs")
                    {
                        Obstacle obs = clickCol.GetComponent<Obstacle>();
                        if (obs.Whatisthis == Obstacle.kindd.FatMan)
                        {
                            Debug.Log("I'm not Pretty");
                        }
                        clickCol.gameObject.SetActive(false);
                    }
                }
            }
        }
    }

}
