using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Building Data", menuName = "Scriptable Object/Building Data")]

public class BuildindData : ScriptableObject
{
    [SerializeField]
    private string buildingName;
    public string BuildingName { get { return buildingName; } }

    [SerializeField] 
    private int buildingLevel;
    public int BuildingLevel { get {  return buildingLevel; } }

    [SerializeField]
    private string type;
    public string Type { get { return type; } }

    [SerializeField]
    private Sprite image;
    public Sprite Image { get { return image; } }

    [SerializeField]
    private string cellSynergy;
    public string CellSynergy { get { return cellSynergy; } }

    [SerializeField]
    private string information;
    public string Information { get { return information; } }

    [SerializeField]
    private string upgradeInfor;
    public string UpgradeInfor { get { return upgradeInfor; } }

    [SerializeField]
    private int upgradeCost;
    public int UpgradeCost { get { return upgradeCost; } }
}
