using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatMan_Slide_Range : MonoBehaviour
{
    public Transform FatMan_obs;
    private Obstacle obs_scr;
    int Swipe = 0;

    public void Slide_Succes()
    {
        obs_scr = FatMan_obs.GetComponent<Obstacle>();
        obs_scr.FatMan_obs_Click();
        Swipe++;

        if (Swipe > 25)
        {
            gameObject.SetActive(false);
            FatMan_obs.gameObject.SetActive(false);
            Swipe= 0;
        }
    }
}
