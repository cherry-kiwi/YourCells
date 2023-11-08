using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacableObject : MonoBehaviour
{
    // 위치 저장하기 위한 필드
    public bool Placed { get; private set; }
    private Vector3 origin;

    public BoundsInt area;

    public bool CanBePlaced()
    {
        // 그리드에서 개체 위치 저장
        Vector3Int positionInt = BuildingSystem.instance.gridLayout.LocalToCell(transform.position);
        BoundsInt areaTemp = area; // 임시 영역 생성
        areaTemp.position = positionInt; // 기존 개체 영역으로 초기화 (저장한 위치를 임시 영역에 할당)

        // 임시 영역 가용성 확인
        //if (BuildingSystem.instance.CanTakeArea(areaTemp))
        //{
        //    return true; // 가능
        //}

        //return false; // 불가능
        
        // 한줄로
        return BuildingSystem.instance.CanTakeArea(areaTemp);
    }

    public void Place()
    {
        // 그리드에서 개체 위치 저장
        Vector3Int positionInt = BuildingSystem.instance.gridLayout.LocalToCell(transform.position);
        BoundsInt areaTemp = area; // 임시 영역 생성
        areaTemp.position = positionInt; // 기존 개체 영역으로 초기화 (저장한 위치를 임시 영역에 할당)

        Placed = true;

        BuildingSystem.instance.TakeArea(areaTemp); // 해당 영역 가져오기
    }

    /// <summary>
    /// 실제로 배치 확인하는 함수
    /// </summary>
    public void CheckPlacement()
    {
        if (CanBePlaced())
        {
            Place();
            origin = transform.position;
        }
        else
        {
            Destroy(transform.gameObject);
        }
    }
}
