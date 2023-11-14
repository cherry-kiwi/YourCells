using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    #region 패널 담을 변수들
    public GameObject userProfilePopUpPanel;
    public GameObject storagePanel;
    public GameObject subContentsPopUpPanel;
    public GameObject cellGatchaPanel;
    public GameObject shopPanel;
    public GameObject informationPanel;
    #endregion

    public GameObject structureInforDisplay;
    public int nowIndex = 0;

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

        for (int i = 0; i < StorageSystem.instance.myBuildings.Count; i++)
        {
            StorageSystem.instance.Content[i].GetComponent<Image>().sprite = StorageSystem.instance.myBuildings[i];
        }
    }

    public void Inactive_StoragePanel()
    {
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

    /// <summary>
    /// 건물을 샀을때 보관함에 건물이 담김
    /// </summary>
    public void Buy_Structure()
    {
        //StorageSystem.instance.myBuildings.Add(ShopSystem.instance.itemList[nowIndex].image);

        GameManager.instance.isEditing = true;

        BuildingSystem.instance.InitializeBuilding(ShopSystem.instance.itemList[nowIndex].itemPrefab);
    }

    public void Inactive_InformationPanel()
    {
        informationPanel.SetActive(false);
    }



    #endregion

    #region Editing Panel

    /// <summary>
    /// 편집 모드가 취소됐을 때
    /// </summary>
    public void Editing_Cancel()
    {
        GameManager.instance.isEditing = false;
        BuildingSystem.instance.cancleBuilding();
        BuildingSystem.instance.myInstalledBuildings.Remove(BuildingSystem.instance.temp.gameObject);
    }

    /// <summary>
    /// 편집 모드가 완료됐을 때
    /// </summary>
    public void Editing_Confirm()
    {
        if (BuildingSystem.instance.temp.CanBePlaced())
        {
            GameManager.instance.isEditing = false;
            BuildingSystem.instance.placeBuilding();
            //BuildingSystem.instance.myInstalledBuildings.Add(BuildingSystem.instance.temp.gameObject);
        }
    }

    #endregion

    //---여기까지 패널 할당 완료됨--//
}
