using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

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

    //#region 변결할 위치 및 건물 정보 프리팹

    //public GameObject Description;
    //public StructureInformationDisplay Display;
    //public List<StructureInformationPanel> Structure;

    //private void Start()
    //{
    //    Display = Description.GetComponent<StructureInformationDisplay>();
    //}

    //#endregion

    //public GameObject shopSystem;

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
    public void Active_InformationPanel()
    {
        informationPanel.SetActive(true);
        //여기다가 현재 오브젝트의 값을 받아오게 하면 됩니다 아시겠어요?
    }

    public void Inactive_InformationPanel()
    {
        informationPanel.SetActive(false);
        StorageSystem.instance.myBuildings.Add(ShopSystem.instance.itemList[0].itemPrefab);
    }

    //public void ClickSlot1()
    //{
    //    Display.structureInformationPanel = Structure[0];
    //}
    //public void ClickSlot2()
    //{
    //    Display.structureInformationPanel = Structure[1];
    //}
    //public void ClickSlot3()
    //{
    //    Display.structureInformationPanel = Structure[2];
    //}
    #endregion

    //---여기까지 패널 할당 완료됨--//
}
