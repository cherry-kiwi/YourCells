using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject BuildingDisplayPanel;

    public GameObject buildingDisplay;

    public List<GameObject> mainUI;
    public List<GameObject> generalModeUI;
    public List<GameObject> BuyModeUI;
    public List<GameObject> editModeUI;

    public bool isEditing = false;
    public bool isBuying = false;

    public Vector3 touchPos;

    private void Awake()
    {
        instance = this;
    }


    void Update()
    {
        //Touch

        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);

        //    //if(OnTriggerEnter2D == Camera.main.ScreenToWorldPoint(touch.position));

        //}

        if (Input.touchCount > 0)
        {
            touchPos = Input.GetTouch(0).position;

            if (Input.GetTouch(0).phase != TouchPhase.Began)
                return;

            if (EventSystem.current.IsPointerOverGameObject(0))
            {
                return;
            }

            Vector2 pos = Camera.main.ScreenToWorldPoint(touchPos);

            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name);

                if (hit.collider.gameObject.CompareTag("Building"))
                {
                    if(isEditing || isBuying)
                    {
                        return;
                    }

                    BuildingDisplayPanel.SetActive(true);

                    string[] SplitResult = hit.collider.name.Split("(Clone)");

                    StringBuilder stringBuilder = new StringBuilder();

                    for (int i = 0; i < SplitResult.Length; i++)
                    {
                        stringBuilder.Append(SplitResult[i]);
                    }

                    for (int i = 0; i < buildingDisplay.GetComponent<BuildingDataDisplay>().buildingSlot.Count; i++)
                    {
                        if (hit.collider.name == buildingDisplay.GetComponent<BuildingDataDisplay>().buildingSlot[i].name)
                        {
                            buildingDisplay.GetComponent<BuildingDataDisplay>().buildingData = buildingDisplay.GetComponent<BuildingDataDisplay>().buildingSlot[i];
                        }
                        else if (stringBuilder.ToString() == buildingDisplay.GetComponent<BuildingDataDisplay>().buildingSlot[i].name)
                        {
                            buildingDisplay.GetComponent<BuildingDataDisplay>().buildingData = buildingDisplay.GetComponent<BuildingDataDisplay>().buildingSlot[i];
                        }
                    }
                }
            }
        }


        //Mod Change
        if (isEditing)
        {
            for (int i = 0; i < generalModeUI.Count; i++)
            {
                mainUI[i].SetActive(false);
                generalModeUI[i].SetActive(false);
            }

            for(int i=0;i< editModeUI.Count; i++)
            {
                editModeUI[i].SetActive(true);
            }
        }
        else if (isBuying)
        {
            for (int i = 0; i < generalModeUI.Count; i++)
            {
                mainUI[i].SetActive(false);
                generalModeUI[i].SetActive(false);
            }

            for (int i = 0; i < BuyModeUI.Count; i++)
            {
                BuyModeUI[i].SetActive(true);
            }
        }
        else
        {

            for (int i = 0; i < mainUI.Count; i++)
            {
                mainUI[i].SetActive(true);
            }

            for (int i = 0; i < editModeUI.Count; i++)
            {
                editModeUI[i].SetActive(false);
            }

            for (int i = 0; i < BuyModeUI.Count; i++)
            {
                BuyModeUI[i].SetActive(false);
            }
        }
    }
}
