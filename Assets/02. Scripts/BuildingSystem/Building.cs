using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Building : MonoBehaviour
{
    public bool Placed { get; private set; }
    public BoundsInt area;

    #region Build Methods

    private void Update()
    {
        Vector3Int positionInt = BuildingSystem.instance.gridLayout.LocalToCell(transform.position);
        BoundsInt areaTemp = area;
        areaTemp.position = positionInt;

        for (int i = 0; i < BuildingSystem.instance.myInstalledBuildings.Count; i++)
        {
            if (BuildingSystem.instance.myInstalledBuildings[i].gameObject == gameObject)
            {
                BuildingSystem.instance.myInstalledBuildings[i].transform.GetComponent<SpriteRenderer>().sortingOrder =
                    BuildingSystem.instance.myInstalledBuildings.Count + 1 - (int)Mathf.Round(gameObject.transform.position.y) * 2;
            }
        }
    }

    /// <summary>
    /// 영역을 초기화하여 BuildingSystem에 전달
    /// </summary>
    /// <returns></returns>
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
