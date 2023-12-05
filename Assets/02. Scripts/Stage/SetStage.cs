using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetStage : MonoBehaviour
{
    [Header("스토리")]
    public int WhatGame;

    public string TitleS;
    public string TypeS;
    public Sprite thumbnail;

    public int ClearI;
    public string ClearS;


    [Header("스테이지")]
    public Text Title;
    public Text Type;
    public GameObject thumbnailG;

    public Text ClearText;

    public void ClickStage()
    {
        Title.text = TitleS;
        Type.text = TypeS;
        thumbnailG.GetComponent<Image>().sprite = thumbnail;

        ClearText.text = ClearI + ClearS;

        StageCtrl.instance.goalScore = ClearI;
        StageCtrl.instance.gameNum = WhatGame;
    }
}
