using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public ParticleSystem touchEffect;

    public GameObject BuildingDisplayPanel;

    public GameObject buildingDisplay;

    public List<GameObject> mainUI;
    public List<GameObject> generalModeUI;
    public List<GameObject> BuyModeUI;
    public List<GameObject> editModeUI;

    public bool isEditing = false;
    public bool isBuying = false;

    public Vector3 touchPos;
    public Vector3 touchBuilding;

    public bool isDrag = false;

    private void Awake()
    {
        instance = this;
    }


    void Update()
    {
        //Touch
        if (Input.touchCount > 0)
        {
            touchPos = Input.GetTouch(0).position;

            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                touchEffect.transform.position = Camera.main.ScreenToWorldPoint(touchPos) + new Vector3(0, 0, 627);
                touchEffect.Play();
            }

            if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Stationary)
            {
                Invoke("OnDrag", 0.15f);
                return;
            }

            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId) || EventSystem.current.IsPointerOverGameObject(0))
            {
                return;
            }

            if(IsPointerOverUIObject(Input.mousePosition) || IsPointerOverUIObject(Input.GetTouch(0).position))
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
                    if (isEditing || isBuying)
                    {
                        return;
                    }

                    if (Input.GetTouch(0).phase == TouchPhase.Ended && isDrag == false)
                    {
                        BuildingDisplayPanel.SetActive(true);
                        isDrag = false;
                    }

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

                    touchBuilding = hit.collider.gameObject.transform.position + new Vector3(0, -(0.2f + (hit.collider.gameObject.GetComponent<Building>().area.size.y / 2f)), 0);
                }
            }
            else
            {
                BuildingDisplayPanel.SetActive(false);
            }    
        }
        else
        {
            CancelInvoke("OnDrag");
            isDrag = false;
        }

        BuildingDisplayPanel.transform.position = Camera.main.WorldToScreenPoint(touchBuilding);


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

    private void OnApplicationQuit()
    {
        for (int i = 0; i < GachaSystem.instance.allCells.Count; i++)
        {
            GachaSystem.instance.allCells[i].cellData.primeEnergy = 0;
        }
    }

    private void OnDrag()
    {
        isDrag = true;
    }

    public bool IsPointerOverUIObject(Vector2 touchPos)
    {
        PointerEventData eventDataCurrentPosition
            = new PointerEventData(EventSystem.current);

        eventDataCurrentPosition.position = touchPos;

        List<RaycastResult> results = new List<RaycastResult>();


        EventSystem.current
        .RaycastAll(eventDataCurrentPosition, results);

        return results.Count > 0;
    }
}
