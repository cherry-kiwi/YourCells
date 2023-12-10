using System.Collections;
using System.Collections.Generic;
using TMPro;
using UltimateClean;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public GameObject St;
    public TextMeshProUGUI count;
    private float Timer = 3f;

    public static bool GamePlaying = false;

    private void Start()
    {
        St.GetComponent<ButtonSounds>().PlayCountDownSound();
    }

    private void Update()
    {
        count.text = ((int)Timer).ToString();

        if(Timer>0)
        {
            Timer -= Time.deltaTime;
        }
        else
        {
            Timer = 0f;
            count.gameObject.SetActive(false);
        }


        if (Timer <= 0)
        {
            GamePlaying = true;
        }
        else
        {
            GamePlaying = false;
        }
    }
}
