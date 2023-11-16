using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance;

    private void Awake()
    {
        instance = this;
    }

    #region 패널 담을 변수들

    public GameObject userProfilePopUpPanel;
    public GameObject storagePanel;
    public GameObject subContentsPopUpPanel;
    public GameObject cellGatchaPanel;
    public GameObject gachaPopupPanel;
    public GameObject gachaResultPanel;
    public GameObject shopPanel;
    public GameObject informationPanel;
    public GameObject BuildingDisplayPanel;
    
    #endregion

    public Text gachaPopupText;
    public Button commonGachaButton;
    public Button eventGachaButton;

    public Sprite[] commonGachaButtonSprites = new Sprite[2];
    public Sprite[] eventGachaButtonSprites = new Sprite[2];

    public GameObject structureInforDisplay;
    
    public int nowIndex = 0;
    public int myCost;
    public int StorageIndex = 0;

    #region User Profile PopUp Panel
    public void Active_UserProfilePopUpPanel()
    {
        userProfilePopUpPanel.SetActive(true);
    }

    public void Inactive_UserProfilePopUpPanel()
    {
        userProfilePopUpPanel.SetActive(false);
    }
    #endregion

    #region Storage Panel
    public void Active_StoragePanel()
    {
        storagePanel.SetActive(true);

        for (int i = 0; i < StorageSystem.instance.myBuildingsSprites.Count; i++)
        {
            StorageSystem.instance.Content[i].GetComponent<Image>().sprite = StorageSystem.instance.myBuildingsSprites[i];
        }
    }

    public void Select_StorageItem(int index)
    {
        if(StorageSystem.instance.myBuildings[index] == null)
        {
            return;
        }
        StorageIndex = index;

        GameManager.instance.isEditing = true;

        BuildingSystem.instance.InitializeBuilding(StorageSystem.instance.myBuildings[index]);

        for (int i = 0; i < StorageSystem.instance.Content.Count; i++)
        {
            StorageSystem.instance.Content[i].GetComponent<Image>().sprite = null;
        }

        storagePanel.SetActive(false);
    }

    public void Delete_StorageItem()
    {
        StorageSystem.instance.myBuildings.Remove(StorageSystem.instance.myBuildings[StorageIndex]);
        StorageSystem.instance.myBuildingsSprites.Remove(StorageSystem.instance.myBuildingsSprites[StorageIndex]);
    }

    public void Inactive_StoragePanel()
    {
        for (int i = 0; i < StorageSystem.instance.Content.Count; i++)
        {
            StorageSystem.instance.Content[i].GetComponent<Image>().sprite = null;
        }

        storagePanel.SetActive(false);
    }
    #endregion

    #region Sub Contents PopUp Panel
    public void Active_SubContentsPopUpPanel()
    {
        subContentsPopUpPanel.SetActive(true);
    }

    public void Inactive_SubContentsPopUpPanel()
    {
        subContentsPopUpPanel.SetActive(false);
    }
    #endregion

    #region Cell Gatcha Panel
    public void Active_CellGatchaPanel()
    {
        cellGatchaPanel.SetActive(true); // 세포뽑기 패널 띄움
    }

    public void Inactive_CellGatchaPanel()
    {
        cellGatchaPanel.SetActive(false);
    }

    public void Active_GachaPopupPanel(int cost)
    {
        myCost = cost;
        gachaPopupPanel.SetActive(true);

        if (Scroll.instance.pos == 220) // Common Gacha 
        {
            gachaPopupText.text = "보석 " + cost + "개를 이용하여\r\n일반 뽑기를\r\n진행합니다.";
        }
        else if (Scroll.instance.pos == -220) // Event Gacha
        {
            gachaPopupText.text = "보석 " + cost + "개를 이용하여\r\n이벤트 뽑기를\r\n진행합니다.";
        }
    }

    public void Inactive_GachaPopupPanel()
    {
        gachaPopupPanel.SetActive(false);
    }

    public void Active_GachaResultPanel()
    {
        gachaResultPanel.SetActive(true);
    }

    public void Inactive_GachaResultPanel()
    {
        gachaResultPanel.SetActive(false);
    }

    public void Common_Button()
    {
        if (Scroll.instance.pos == 220) // Common Gacha 
        {
            commonGachaButton.GetComponent<Image>().sprite = commonGachaButtonSprites[0];
        }
        else if (Scroll.instance.pos == -220) // Event Gacha
        {
            commonGachaButton.GetComponent<Image>().sprite = commonGachaButtonSprites[1];
        }
    }

    public void Event_Button()
    {
        if (Scroll.instance.pos == 220) // Common Gacha 
        {
            eventGachaButton.GetComponent<Image>().sprite = eventGachaButtonSprites[0];
        }
        else if (Scroll.instance.pos == -220) // Event Gacha
        {
            commonGachaButton.GetComponent<Image>().sprite = eventGachaButtonSprites[1];
        }
    }

    #endregion

    #region Shop Panel
    public void Active_ShopPanel()
    {
        shopPanel.SetActive(true);
    }
    public void Inactive_ShopPanel()
    {
        shopPanel.SetActive(false);
    }
    #endregion

    #region Information Panel
    public void Active_InformationPanel(int index)
    {
        informationPanel.SetActive(true);

        nowIndex = index;
        structureInforDisplay.GetComponent<StructureInformationDisplay>().structureInformationPanel = structureInforDisplay.GetComponent<StructureInformationDisplay>().structureSlots[index];
    }

    public void Buy_Structure()
    {
        //StorageSystem.instance.myBuildings.Add(ShopSystem.instance.itemList[nowIndex].image);

        GameManager.instance.isBuying = true;

        BuildingSystem.instance.InitializeBuilding(ShopSystem.instance.itemList[nowIndex].itemPrefab);
    }

    public void Inactive_InformationPanel()
    {
        informationPanel.SetActive(false);
    }



    #endregion

    #region Editing Panel

    public void Editing_Storage()
    {
        GameManager.instance.isBuying = false;
        BuildingSystem.instance.cancleBuilding();
        StorageSystem.instance.myBuildingsSprites.Add(ShopSystem.instance.itemList[nowIndex].image);
        StorageSystem.instance.myBuildings.Add(ShopSystem.instance.itemList[nowIndex].itemPrefab);
        BuildingSystem.instance.myInstalledBuildings.Remove(BuildingSystem.instance.temp.gameObject);
    }

    public void Editing_Cancel()
    {
        GameManager.instance.isEditing = false;
        GameManager.instance.isBuying = false;
        BuildingSystem.instance.cancleBuilding();
        BuildingSystem.instance.myInstalledBuildings.Remove(BuildingSystem.instance.temp.gameObject);
    }

    public void Editing_Confirm()
    {
        if (BuildingSystem.instance.temp.CanBePlaced())
        {
            GameManager.instance.isEditing = false;
            GameManager.instance.isBuying = false;
            BuildingSystem.instance.placeBuilding();
            //BuildingSystem.instance.myInstalledBuildings.Add(BuildingSystem.instance.temp.gameObject);
        }
    }

    #endregion

    #region Building Display

    public void Inactive_BuildingDisplay()
    {
        BuildingDisplayPanel.SetActive(false);
    }

    #endregion
}
