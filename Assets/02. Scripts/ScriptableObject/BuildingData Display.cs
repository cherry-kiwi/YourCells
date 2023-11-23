using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingDataDisplay : MonoBehaviour
{
    public BuildingData buildingData;
    public List<BuildingData> buildingSlot = new List<BuildingData>();

    public Text[] nameText;
    public Text[] levelText;
    public Text[] typeText;
    public Text cellSynergyText;
    public Text informationText;

    public Image[] buildingImage;

    public Text upgradeInforText;
    public Image upgradeInforImage;
    public Text costText;

    public Text abiltyInforText;

    void Update()
    {
        for (int i = 0; i < nameText.Length; i++)
        {
            nameText[i].text = buildingData.BuildingName;
            levelText[i].text = "LV. " + buildingData.BuildingLevel.ToString();
            typeText[i].text = buildingData.Type;
            buildingImage[i].sprite = buildingData.Image;
        }
        cellSynergyText.text = buildingData.CellSynergy;
        informationText.text = buildingData.Information;

        if (upgradeInforText != null)
        {
            upgradeInforText.text = buildingData.UpgradeInfor;
            upgradeInforImage.sprite = buildingData.Image;
            costText.text = buildingData.UpgradeCost.ToString();
        }

        abiltyInforText.text = buildingData.AbiltyInfor;
    }
}
