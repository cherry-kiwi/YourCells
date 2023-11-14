using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingDataDisplay : MonoBehaviour
{
    public BuildindData buildingData;
    public List<BuildindData> buildingSlot = new List<BuildindData>();

    public Text nameText;
    public Text levelText;
    public Text typeText;
    public Text cellSynergyText;
    public Text informationText;

    public Image buildingImage;

    public Text upgradeInforText;
    public Text costText;

    void Update()
    {
        nameText.text = buildingData.BuildingName;
        levelText.text = "LV. " + buildingData.BuildingLevel.ToString();
        typeText.text = buildingData.Type;
        cellSynergyText.text = buildingData.CellSynergy;
        informationText.text = buildingData.Information;

        buildingImage.sprite = buildingData.Image;

        upgradeInforText.text = buildingData.UpgradeInfor;
        costText.text = buildingData.UpgradeCost.ToString();
    }
}
