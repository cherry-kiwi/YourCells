using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject count;

    public static bool GamePlaying = false;

    private void Update()
    {
        if (count.activeSelf == false)
        {
            GamePlaying = true;
        }
        else
        {
            GamePlaying = false;
        }
    }
}
