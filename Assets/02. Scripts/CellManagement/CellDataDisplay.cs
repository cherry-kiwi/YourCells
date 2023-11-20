using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellDataDisplay : MonoBehaviour
{
    public CellData cellData;

    public Text cellGrade;
    public Text cellName;
    public Text cellHP;
    public Text cellPower;
    public Text cellUpgradeCost;
    public Text cellSkillDescription;
    public Image cellPortrait;

    public void Start()
    {
        cellGrade.text = cellData.grade;
        cellName.text = cellData.name;
        cellHP.text = cellData.hP.ToString();
        cellPower.text = cellData.power.ToString();
        cellUpgradeCost.text = cellData.upgradeCost.ToString();
        cellSkillDescription.text = cellData.description;
        cellPortrait.sprite = cellData.image;
    }
}
