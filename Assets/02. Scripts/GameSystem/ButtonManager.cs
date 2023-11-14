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
    #region gameObjects
    public GameObject userProfilePopUpPanel;
    public GameObject storagePanel;
    public GameObject subContentsPopUpPanel;
    public GameObject cellGatchaPanel;
    public GameObject shopPanel;
    public GameObject informationPanel;
    public GameObject BuildingDisplayPanel;
    #endregion

    public GameObject structureInforDisplay;
    
    public int nowIndex = 0;
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

    public void Inctive_SubContentsPopUpPanel()
    {
        subContentsPopUpPanel.SetActive(false);
    }
    #endregion

    #region Cell Gatcha Panel
    public void Active_CellGatchaPanel()
    {
        cellGatchaPanel.SetActive(true);
    }

    public void Inctive_CellGatchaPanel()
    {
        cellGatchaPanel.SetActive(false);
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
