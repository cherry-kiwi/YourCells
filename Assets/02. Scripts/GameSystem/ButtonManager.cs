using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UltimateClean;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    #region 싱글톤
    public static ButtonManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    #region 패널 담을 변수들

    public GameObject userProfilePopUpPanel;
    public GameObject storagePanel;
    public GameObject subContentsPopUpPanel;
    public GameObject cellGatchaPanel;
    public GameObject cellManagementPanel;
    public GameObject cellInfoPanel;
    public GameObject gachaPopupPanel;
    public GameObject gachaResultPanel;
    public GameObject shopPanel;
    public GameObject informationPanel;
    public GameObject BuildingDisplayPanel;
    public GameObject storyModePanel;
    public GameObject ResultPanel;
    public GameObject ClickB;

    #endregion

    [Header("요소들")]
    public GameObject Sounds;

    public Text gachaPopupText;
    public Button commonGachaButton;
    public Button eventGachaButton;

    public Sprite[] commonGachaButtonSprites = new Sprite[2];
    public Sprite[] eventGachaButtonSprites = new Sprite[2];

    public GameObject structureInforDisplay;
    public GameObject myCellButtonPrefab;
    public GameObject myCellContents;

    public List<GameObject> myCellButtonList;
    
    public int nowIndex = 0;
    public int myCost;
    public int StorageIndex = 0;

    private void Update()
    {
        if(BuildingDisplayPanel.activeSelf == true)
        {
            ClickB.SetActive(false);
        }
    }

    #region User Profile PopUp Panel
    public void Active_UserProfilePopUpPanel()
    {
        userProfilePopUpPanel.SetActive(true);
        Sounds.GetComponent<ButtonSounds>().PlayPressedSound();
    }

    public void Inactive_UserProfilePopUpPanel()
    {
        userProfilePopUpPanel.SetActive(false);
        Sounds.GetComponent<ButtonSounds>().PlayPressedSound();
    }
    #endregion

    #region Storage Panel
    public void Active_StoragePanel()
    {
        storagePanel.SetActive(true);
        Sounds.GetComponent<ButtonSounds>().PlayPressedSound();

        for (int k = 0; k < StorageSystem.instance.Content.Count; k++)
        {
            StorageSystem.instance.Content[k].SetActive(true);
        }

        for (int i = 0; i < StorageSystem.instance.myBuildingsSprites.Count; i++)
        {
            StorageSystem.instance.Content[i].GetComponent<Image>().sprite = StorageSystem.instance.myBuildingsSprites[i];
        }

        for (int j = 0; j < StorageSystem.instance.Content.Count; j++)
        {
            if (StorageSystem.instance.Content[j].GetComponent<Image>().sprite == null)
            {
                StorageSystem.instance.Content[j].SetActive(false);
            }
        }
    }

    public void Select_StorageItem(int index)
    {
        Sounds.GetComponent<ButtonSounds>().PlayPressedSound();

        if (StorageSystem.instance.myBuildings[index] == null)
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
        Sounds.GetComponent<ButtonSounds>().PlayPressedSound();

        for (int i = 0; i < StorageSystem.instance.Content.Count; i++)
        {
            if (StorageSystem.instance.Content[i] != null)
            {
                StorageSystem.instance.Content[i].GetComponent<Image>().sprite = null;
            }
        }

        storagePanel.SetActive(false);
    }
    #endregion

    #region Sub Contents PopUp Panel
    public void Active_SubContentsPopUpPanel()
    {
        subContentsPopUpPanel.SetActive(true);

        Sounds.GetComponent<ButtonSounds>().PlayPressedSound();
    }

    public void Inactive_SubContentsPopUpPanel()
    {
        subContentsPopUpPanel.SetActive(false);

        Sounds.GetComponent<ButtonSounds>().PlayPressedSound();
    }
    #endregion

    #region Cell Management Panel

    public void Active_CellManagementPanel()
    {
        Sounds.GetComponent<ButtonSounds>().PlayPressedSound();

        cellManagementPanel.SetActive(true);

        for (int i = 0; i < CellManager.instance.myCells.Count; i++)
        {
            myCellButtonList.Add(Instantiate(myCellButtonPrefab, myCellContents.transform.position, Quaternion.identity));
            myCellButtonList[i].gameObject.GetComponent<Image>().sprite = CellManager.instance.myCells[i].cellData.image;
            myCellButtonList[i].transform.SetParent(myCellContents.transform);
            myCellButtonList[i].transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void Inactive_CellManagementPanel()
    {
        Sounds.GetComponent<ButtonSounds>().PlayPressedSound();

        cellManagementPanel.SetActive(false);
    }

    #endregion

    #region Cell Info Panel

    public void Active_CellInfoPanel()
    {
        Sounds.GetComponent<ButtonSounds>().PlayPressedSound();

        cellInfoPanel.SetActive(true);
    }
    public void Inactive_CellInfoPanel()
    {
        Sounds.GetComponent<ButtonSounds>().PlayPressedSound();

        cellInfoPanel.SetActive(false);
    }

    #endregion

    #region Cell Gatcha Panel
    public void Active_CellGatchaPanel()
    {
        Sounds.GetComponent<ButtonSounds>().PlayPressedSound();

        cellGatchaPanel.SetActive(true); // 세포뽑기 패널 띄움
    }

    public void Inactive_CellGatchaPanel()
    {
        Sounds.GetComponent<ButtonSounds>().PlayPressedSound();

        cellGatchaPanel.SetActive(false);
    }

    public void Active_GachaPopupPanel(int cost)
    {
        Sounds.GetComponent<ButtonSounds>().PlayPressedSound();

        myCost = cost;
        gachaPopupPanel.SetActive(true);

        if (Scroll.instance.pos >= 220) // Common Gacha 
        {
            gachaPopupText.text = "보석 " + cost + "개를 이용하여\r\n일반 뽑기를\r\n진행합니다.";
        }
        else if (Scroll.instance.pos <= -220) // Event Gacha
        {
            gachaPopupText.text = "보석 " + cost + "개를 이용하여\r\n이벤트 뽑기를\r\n진행합니다.";
        }
    }

    public void Inactive_GachaPopupPanel()
    {
        Sounds.GetComponent<ButtonSounds>().PlayPressedSound();

        gachaPopupPanel.SetActive(false);
    }

    public void Active_GachaResultPanel()
    {
        Sounds.GetComponent<ButtonSounds>().PlayPressedSound();

        gachaResultPanel.SetActive(true);
    }

    public void Inactive_GachaResultPanel()
    {
        Sounds.GetComponent<ButtonSounds>().PlayPressedSound();

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
        Sounds.GetComponent<ButtonSounds>().PlayPressedSound();

        shopPanel.SetActive(true);
    }
    public void Inactive_ShopPanel()
    {
        Sounds.GetComponent<ButtonSounds>().PlayPressedSound();

        shopPanel.SetActive(false);
    }
    #endregion

    #region Information Panel
    public void Active_InformationPanel(int index)
    {
        Sounds.GetComponent<ButtonSounds>().PlayPressedSound();

        informationPanel.SetActive(true);

        nowIndex = index;
        structureInforDisplay.GetComponent<StructureInformationDisplay>().structureInformationPanel = structureInforDisplay.GetComponent<StructureInformationDisplay>().structureSlots[index];
    }

    public void Buy_Structure()
    {
        Sounds.GetComponent<ButtonSounds>().PlayPressedSound();

        //StorageSystem.instance.myBuildings.Add(ShopSystem.instance.itemList[nowIndex].image);
        if (MoneySystem.instance.yumi >= structureInforDisplay.GetComponent<StructureInformationDisplay>().structureSlots[nowIndex].price)
        {
            MoneySystem.instance.yumi -= structureInforDisplay.GetComponent<StructureInformationDisplay>().structureSlots[nowIndex].price;

            GameManager.instance.isBuying = true;

            BuildingSystem.instance.InitializeBuilding(ShopSystem.instance.itemList[nowIndex].itemPrefab);
        }
        else
        {
            AndroidToast.I.ShowToastMessage("유미가 부족합니다!");
        }
    }

    public void Inactive_InformationPanel()
    {
        Sounds.GetComponent<ButtonSounds>().PlayPressedSound();

        informationPanel.SetActive(false);
    }



    #endregion

    #region Editing Panel

    public void Editing_Storage()
    {
        if (GameManager.instance.isTutorial == false)
        {
            Sounds.GetComponent<ButtonSounds>().PlayPressedSound();

            GameManager.instance.isBuying = false;
            BuildingSystem.instance.cancleBuilding();
            StorageSystem.instance.myBuildingsSprites.Add(ShopSystem.instance.itemList[nowIndex].image);
            StorageSystem.instance.myBuildings.Add(ShopSystem.instance.itemList[nowIndex].itemPrefab);
            BuildingSystem.instance.myInstalledBuildings.Remove(BuildingSystem.instance.temp.gameObject);
        }
        else
        {
            AndroidToast.I.ShowToastMessage("지금은 보관이 불가능합니다.");
        }
    }

    public void Editing_Cancel()
    {
        Sounds.GetComponent<ButtonSounds>().PlayPressedSound();

        GameManager.instance.isEditing = false;
        GameManager.instance.isBuying = false;
        BuildingSystem.instance.cancleBuilding();
        BuildingSystem.instance.myInstalledBuildings.Remove(BuildingSystem.instance.temp.gameObject);
    }

    public void Editing_Cancel2()
    {
        if (GameManager.instance.isTutorial == false)
        {
            Sounds.GetComponent<ButtonSounds>().PlayPressedSound();

            MoneySystem.instance.yumi += structureInforDisplay.GetComponent<StructureInformationDisplay>().structureSlots[nowIndex].price;

            GameManager.instance.isEditing = false;
            GameManager.instance.isBuying = false;
            BuildingSystem.instance.cancleBuilding();
            BuildingSystem.instance.myInstalledBuildings.Remove(BuildingSystem.instance.temp.gameObject);
        }
        else
        {
            AndroidToast.I.ShowToastMessage("지금은 취소가 불가능합니다.");
        }
    }

    public void Editing_Confirm()
    {
        Sounds.GetComponent<ButtonSounds>().PlayPressedSound();

        if (BuildingSystem.instance.temp.CanBePlaced())
        {
            GameManager.instance.isEditing = false;
            GameManager.instance.isBuying = false;
            BuildingSystem.instance.placeBuilding();
            //BuildingSystem.instance.myInstalledBuildings.Add(BuildingSystem.instance.temp.gameObject);

            if (GameManager.instance.isTutorial)
            {
                TutorialManager.instance.ActiveNextIndex();
                TutorialManager.instance.items[15].SetActive(false);
                TutorialManager.instance.TouchGuard.SetActive(true);
                GameManager.instance.MainOn();
            }
        }
    }

    #endregion

    #region Building Display

    public void Active_BuildingDisplay()
    {
        Sounds.GetComponent<ButtonSounds>().PlayPressedSound();
        BuildingDisplayPanel.SetActive(true);
    }

    public void Inactive_BuildingDisplay()
    {
        Sounds.GetComponent<ButtonSounds>().PlayPressedSound();
        BuildingDisplayPanel.SetActive(false);
    }

    #endregion

    #region Story Mode Panel

    public void Active_StoryModePanel()
    {
        Sounds.GetComponent<ButtonSounds>().PlayPressedSound();

        storyModePanel.SetActive(true);
    }
    public void Inactive_StoryModePanel()
    {
        Sounds.GetComponent<ButtonSounds>().PlayPressedSound();

        storyModePanel.SetActive(false);
    }

    #endregion

    #region Money System

    public void TakeMoney()
    {
        if (GameManager.instance.isEditing == false && GameManager.instance.isBuying == false && GameManager.instance.isCapturing == false && GameManager.instance.isfixing == false)
        {
            MoneySystem.instance.yumi += MoneySystem.instance.tempYumi;
            MoneySystem.instance.tempYumi = 0;
            MoneySystem.instance.cellSnack1 += MoneySystem.instance.tempCellSnack1;
            MoneySystem.instance.tempCellSnack1 = 0;

            MoneySystem.instance.Timer = 60f;
            MoneySystem.instance.MaxRoutine = 0;
        }
    }

    public void ReseltPanelTrue()
    {
        if (MoneySystem.instance.MaxRoutine > 0)
        {
            ResultPanel.SetActive(true);
        }
    }

    #endregion

    #region Capture Panel

    public void CaptureOn()
    {
        GameManager.instance.isCapturing = true;
    }

    public void CaptureOff()
    {
        GameManager.instance.isCapturing = false;
    }

    #endregion

    #region Fix Button

    public void FixOn()
    {
        GameManager.instance.isfixing = true;
    }

    public void FixOff()
    {
        GameManager.instance.isfixing = false;
    }

    public void Fixing_Storage()
    {
        Sounds.GetComponent<ButtonSounds>().PlayPressedSound();

        if (BuildingSystem.instance.myFixedBuildings.Count > 0)
        {
            StorageSystem.instance.myBuildingsSprites.Add(BuildingSystem.instance.temp.buildingData.Image);
            StorageSystem.instance.myBuildings.Add(BuildingSystem.instance.temp.buildingData.Prefab);
            BuildingSystem.instance.myInstalledBuildings.Remove(BuildingSystem.instance.temp.gameObject);
            BuildingSystem.instance.myFixedBuildings.Remove(BuildingSystem.instance.temp);
            BuildingSystem.instance.cancleBuilding();

            for (int j = 0; j < GameManager.instance.fixPanels.Count; j++)
            {
                GameManager.instance.fixPanels[j].SetActive(false);
            }
        }
    }

    public void Fixing_Cancel()
    {
        Sounds.GetComponent<ButtonSounds>().PlayPressedSound();

        if (BuildingSystem.instance.myFixedBuildings.Count <= 0)
        {
            GameManager.instance.isfixing = false;
        }
        else
        {
            AndroidToast.I.ShowToastMessage("설치 중입니다.");
        }
    }

    public void Fixing_Confirm()
    {
        Sounds.GetComponent<ButtonSounds>().PlayPressedSound();

        if (BuildingSystem.instance.temp.CanBePlaced())
        {
            BuildingSystem.instance.myFixedBuildings.Remove(BuildingSystem.instance.temp);
            BuildingSystem.instance.placeBuilding();
            //BuildingSystem.instance.myInstalledBuildings.Add(BuildingSystem.instance.temp.gameObject);

            for (int j = 0; j < GameManager.instance.fixPanels.Count; j++)
            {
                GameManager.instance.fixPanels[j].SetActive(false);
            }
        }
    }

    #endregion
}
