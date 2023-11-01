using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem instance; // 싱글톤 형식

    public GridLayout gridLayout;
    public Tilemap mainTilemap;
    public TileBase takenTile;

    #region Tilemap Management (타일맵 관리)

    /// <summary>
    /// 타일 배열을 가져오는 함수
    /// </summary>
    /// <param name="area"></param>
    /// <param name="tilemap"></param>
    /// <returns></returns>
    private static TileBase[] GetTilesBlock(BoundsInt area, Tilemap tilemap)
    {
        // 타일베이스 베열
        TileBase[] array = new TileBase[area.size.x * area.size.y];
        int counter = 0;

        // BoundsInt(area) 내의 모든 위치를 탐색함
        foreach (var v in area.allPositionsWithin)
        {
            // 위치를 가져와 pos에 저장
            Vector3Int pos = new Vector3Int(v.x, v.y, 0);
            // 특정 위치의 타일맵에서 얻은 타일로 배열 초기화
            // GetTile() 함수: 셀 좌표를 이용해 타일이 있는지 없는지 판단하거나 타일을 얻을 수 있음
            array[counter] = new Tilemap().GetTile(pos); 
            counter++;
        }

        return array;
    }

    /// <summary>
    /// 타일 배열을 채우는 함수
    /// </summary>
    /// <param name="area"></param>
    /// <param name="tileBase"></param>
    /// <param name="tilemap"></param>
    private static void SetTilesBlock(BoundsInt area, TileBase tileBase, Tilemap tilemap)
    {
        TileBase[] tileArray = new TileBase[area.size.x * area.size.y];
        FillTiles(tileArray, tileBase);
        // 타일로 채우기
        tilemap.SetTilesBlock(area, tileArray);
    }

    /// <summary>
    /// 타일 채우는 함수
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="tileBase"></param>
    private static void FillTiles(TileBase[] arr, TileBase tileBase)
    {
        for(int i = 0; i < arr.Length; i++)
        {
            arr[i] = tileBase;
        }
    }

    /// <summary>
    /// BoundsInt 영역 매개변수와 타일맵을 삭제하는 함수
    /// </summary>
    /// <param name="area"></param>
    /// <param name="tilemap"></param>
    public void ClearArea(BoundsInt area,Tilemap tilemap)
    {
        SetTilesBlock(area, null, tilemap);
    }

    #endregion

    #region Building Placement (건물 배치)

    /// <summary>
    /// 
    /// </summary>
    /// <param name="building"></param>
    /// <param name="pos"></param>
    public void InitializeWithObject(GameObject building, Vector3 pos)
    {
        pos.z = 0;
        // 스프라이트 높이의 절반 (스프라이트 렌더러 경계 크기의 절반에 해당하는 오프셋을 뺌)
        pos.y -= building.GetComponent<SpriteRenderer>().bounds.size.y / 2f;

        // 그리드 스냅 보장하기 (셀 위치로 변환 후, 보간된 로컬 위치로 되돌림)
        Vector3Int cellPos = gridLayout.WorldToCell(pos);
        Vector3 position = gridLayout.CellToLocalInterpolated(cellPos);

        GameObject obj = Instantiate(building, position, Quaternion.identity);
        PlacableObject temp=obj.transform.GetComponent<PlacableObject>();
        temp.gameObject.AddComponent<ObjectDrag>();
    }

    /// <summary>
    /// 지역 차지 가능한지 여부 알아보는 함수 (타일맵에서 해당 영역의 타일 배열을 받음)
    /// </summary>
    /// <param name="area"></param>
    /// <returns></returns>
    public bool CanTakeArea(BoundsInt area)
    {
        TileBase[] baseArray = GetTilesBlock(area, mainTilemap);

        // 각 타일이 가져온 타일과 동일한지 확인
        foreach (var b in baseArray)
        {
            if (b == takenTile)
            {
                // 해당 지역 사용 불가
                return false;
            }
        }

        // 해당 지역 사용 가능
        return true;
    }

     
    public void TakeArea(BoundsInt ara)
    {

    }

    #endregion
}
