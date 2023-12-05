using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FoodGenerater : MonoBehaviour
{
    public GameObject Food;
    public List<GameObject> Foods;
    [SerializeField] private hpBar myHP;

    float Timer = 0.0f;
    float GenerateCool = 0.3f;

    //public TextMeshProUGUI remainTime;
    public TextMeshProUGUI scoreText;

    float GameHP = 60f;
    int Score = 0;

    private void Update()
    {
        //remainTime.text = "<sprite=0> " + ((int)GameHP).ToString();
        scoreText.text = "<sprite=0> " + Score.ToString();

        if (GameStart.GamePlaying == true)
        {
            Timer += Time.deltaTime;

            GameHP -= Time.deltaTime;

            if (Foods.Count < 10) // 현재 나온 음식이 10개 이하라면
            {
                if (Timer > GenerateCool) // 생성 쿨 0.3초가 됐으면
                {
                    Generate(); //만들어

                    Timer = 0; //쿨타임 리셋
                }
            }

            ChageLayer();
        }

        if (GameHP <= 0)
        {
            GameStart.GamePlaying = false;
        }
    }

    void Generate()
    {
        Foods.Add(Instantiate(Food, transform.position, Quaternion.identity)); //생성
    }

    void ChageLayer()
    {
        for (int i = 0; i < Foods.Count; i++)
        {
            Foods[i].transform.GetComponent<SpriteRenderer>().sortingOrder = -i; //
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
        }
        else
        {
            //GameHP -= 10;
            myHP.umm_didyouHit();
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
        }
        else
        {
            //GameHP -= 10;
            myHP.umm_didyouHit();
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
        }
        else
        {
            //GameHP -= 10;
            myHP.umm_didyouHit();
        }
    }
}
