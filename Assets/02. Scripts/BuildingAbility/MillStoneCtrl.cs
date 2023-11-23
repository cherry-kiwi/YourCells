using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MillStoneCtrl : MonoBehaviour
{
    public static MillStoneCtrl instance;

    public GameObject takeButton;
    public Image img_Abilty;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        takeButton.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 1.5f, 0));
        if(MoneySystem.instance.tempYumi > 0f)
        {
            takeButton.SetActive(true);
        }
        else
        {
            takeButton.SetActive(false);
        }
    }
}
