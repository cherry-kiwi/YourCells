using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    public bool Placed { get; private set; }
    public BoundsInt area;

    public BuildingData buildingData;
    public int buildngAbiltyPower;

    #region Build Methods

    private void Start()
    {
        buildngAbiltyPower = buildingData.AbiltyPower;

        //수급 파워
        MoneySystem.instance.yumiPower += buildngAbiltyPower;
    }

    private void Update()
    {
        // Change Layer
        for (int i = 0; i < BuildingSystem.instance.myInstalledBuildings.Count; i++)
        {
            if (BuildingSystem.instance.myInstalledBuildings[i].gameObject == gameObject)
            {
                BuildingSystem.instance.myInstalledBuildings[i].transform.GetComponent<SpriteRenderer>().sortingOrder =
                    3000 + (int)(Camera.main.WorldToScreenPoint(this.transform.position).y * -1);
                //BuildingSystem.instance.myInstalledBuildings.Count + 20 - Mathf.RoundToInt(gameObject.transform.position.y);
            }
        }
    }

    private void OnDestroy()
    {
        //수급 파워
        MoneySystem.instance.yumiPower -= buildngAbiltyPower;
    }

    /// <summary>
    /// Functions to check if they are installable
    /// </summary>
    public bool CanBePlaced()
    {
        Vector3Int positionInt = BuildingSystem.instance.gridLayout.LocalToCell(transform.position);
        BoundsInt areaTemp = area;
        areaTemp.position = positionInt;

        if (BuildingSystem.instance.CanTakeArea(areaTemp))
        {
            return true;
        }

        return false;
    }

    public void Place()
    {
        Vector3Int positionInt = BuildingSystem.instance.gridLayout.LocalToCell(transform.position);
        BoundsInt areaTemp = area;
        areaTemp.position = positionInt;
        Placed = true;
        BuildingSystem.instance.TakeArea(areaTemp);
    }

#endregion
}
