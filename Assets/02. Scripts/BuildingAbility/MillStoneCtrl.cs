using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MillStoneCtrl : MonoBehaviour
{
    public static MillStoneCtrl instance;

    public GameObject takeButton;
    public List<GameObject> UIimages;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        takeButton.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 1.5f, 0));
        if(MoneySystem.instance.tempYumi > 0f && MoneySystem.instance.tempYumi < 400f)
        {
            takeButton.SetActive(true);

            for(int i = 0; i <UIimages.Count;i++)
            {
                if (i == 0)
                {
                    UIimages[i].SetActive(true);
                }
                else
                {
                    UIimages[i].SetActive(false);
                }
            }
        }
        else if(MoneySystem.instance.tempYumi >= 400f && MoneySystem.instance.tempYumi < 600f)
        {
            takeButton.SetActive(true);

            for (int i = 0; i < UIimages.Count; i++)
            {
                if (i == 1)
                {
                    UIimages[i].SetActive(true);
                }
                else
                {
                    UIimages[i].SetActive(false);
                }
            }
        }
        else if (MoneySystem.instance.tempYumi >= 600f && MoneySystem.instance.tempYumi < 800f)
        {
            takeButton.SetActive(true);

            for (int i = 0; i < UIimages.Count; i++)
            {
                if (i == 2)
                {
                    UIimages[i].SetActive(true);
                }
                else
                {
                    UIimages[i].SetActive(false);
                }
            }
        }
        else if (MoneySystem.instance.tempYumi >= 800f && MoneySystem.instance.tempYumi < 1000f)
        {
            takeButton.SetActive(true);

            for (int i = 0; i < UIimages.Count; i++)
            {
                if (i == 3)
                {
                    UIimages[i].SetActive(true);
                }
                else
                {
                    UIimages[i].SetActive(false);
                }
            }
        }
        else if (MoneySystem.instance.tempYumi >= 1000f && MoneySystem.instance.tempYumi < 1600f)
        {
            takeButton.SetActive(true);

            for (int i = 0; i < UIimages.Count; i++)
            {
                if (i == 4)
                {
                    UIimages[i].SetActive(true);
                }
                else
                {
                    UIimages[i].SetActive(false);
                }
            }
        }
        else if (MoneySystem.instance.tempYumi >= 1600f && MoneySystem.instance.tempYumi < 3000f)
        {
            takeButton.SetActive(true);

            for (int i = 0; i < UIimages.Count; i++)
            {
                if (i == 5)
                {
                    UIimages[i].SetActive(true);
                }
                else
                {
                    UIimages[i].SetActive(false);
                }
            }
        }
        else if (MoneySystem.instance.tempYumi >= 3000f && MoneySystem.instance.tempYumi < 5000f)
        {
            takeButton.SetActive(true);

            for (int i = 0; i < UIimages.Count; i++)
            {
                if (i == 6)
                {
                    UIimages[i].SetActive(true);
                }
                else
                {
                    UIimages[i].SetActive(false);
                }
            }
        }
        else if (MoneySystem.instance.tempYumi >= 5000f)
        {
            takeButton.SetActive(true);

            for (int i = 0; i < UIimages.Count; i++)
            {
                if (i == 7)
                {
                    UIimages[i].SetActive(true);
                }
                else
                {
                    UIimages[i].SetActive(false);
                }
            }
        }
        else
        {
            takeButton.SetActive(false);
        }
    }
}
