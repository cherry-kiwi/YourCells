using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class GridBuildingSystem : MonoBehaviour
{
    public static GridBuildingSystem instance;

    public GridLayout gridLayout;
    public Tilemap mainTilemap;
    public Tilemap tempTilemap;

    private static Dictionary<TileType, TileBase> tileBases = new Dictionary<TileType, TileBase>();

    private Building temp; //새 건물을 지을 때마다 변경됨
    private Vector3 prevPos; //이전 위치 저장
    private BoundsInt prevArea;

    public enum TileType { Empty, White, Green, Red }

    #region Unity Methods (유니티 기본 내장 함수)

    private void Awake()
    {
        instance = this; 
    }

    private void Start()
    {
        string tilePath = @"Tiles\";
        tileBases.Add(TileType.Empty, null);
        tileBases.Add(TileType.White, Resources.Load<TileBase>(tilePath + "white"));
        tileBases.Add(TileType.Green, Resources.Load<TileBase>(tilePath + "green"));
        tileBases.Add(TileType.Red, Resources.Load<TileBase>(tilePath + "red"));
    }

    private void Update()
    {
        // 건물이 없으면 아무것도 하지 않음
        if (!temp)
        {
            return;
        }

        // 누르는게 감지되면
        if (Input.GetMouseButtonDown(0))
        {
            // UI에 없는지 확인한 다음 
            if (EventSystem.current.IsPointerOverGameObject(0))
            {
                return;
            }

            // 건물이 배치되지 않았는지 확인
            if (!temp.Placed)
            {
                // 마우스 위치를 얻어 월드 포인트로 변환
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3Int cellPos = gridLayout.LocalToCell(touchPos);

                // 셀 위치를 가져오고 이전 위치와 다르면 일부 이동 수행 가능
                if (prevPos != cellPos)
                {
                    // 확인 후 건물 위치를 새 위치로 설정하고
                    // 오프셋 추가하여 건물 스프라이트가 그리드 셀 중앙에 오도록 함
                    temp.transform.localPosition = gridLayout.CellToLocalInterpolated(cellPos
                        + new Vector3(.5f, .5f, 0f));
                    prevPos = cellPos; // 이전 위치 재설정 
                }
            }
        }
    }

    #endregion

    #region Tilemap Management (타일맵에서 타일을 가져오고 설정하는데 사용)

    private static TileBase[] GetTilesBlock(BoundsInt area, Tilemap tilemap)
    {
        TileBase[] array = new TileBase[area.size.x * area.size.y * area.size.z];
        int counter = 0;

        foreach(var v in area.allPositionsWithin)
        {
            Vector3Int pos = new Vector3Int(v.x, v.y, 0);
            array[counter] = tilemap.GetTile(pos);
            counter++;
        }

        return array;
    }

    private static void SetTilesBlock(BoundsInt area, TileType type,Tilemap tilemap)
    {
        int size = area.size.x * area.size.y * area.size.z;
        TileBase[] tileArray = new TileBase[size];
        FillTiles(tileArray, type);
        tilemap.SetTilesBlock(area, tileArray);
    }

    /// <summary>
    /// 영역에 따라 배열을 생성하여 타일을 채움
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="type"></param>
    private static void FillTiles(TileBase[] arr, TileType type)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = tileBases[type];
        }
    }

    #endregion

    #region Building Placemet (건물 배치 담당)

    /// <summary>
    /// 새 건물을 인스턴스하는 함수
    /// </summary>
    /// <param name="building"></param>
    public void InitializeWithBuilding(GameObject building)
    {
        temp = Instantiate(building, Vector3.zero, Quaternion.identity).GetComponent<Building>();
        FollowBuilding();
    }

    /// <summary>
    /// 이전 영억 지우는 함수
    /// </summary>
    private void ClearArea()
    {
        TileBase[] toClear = new TileBase[prevArea.size.x * prevArea.size.y * prevArea.size.z];
        FillTiles(toClear, TileType.Empty);
        tempTilemap.SetTilesBlock(prevArea, toClear);
    }

    /// <summary>
    /// 
    /// </summary>
    private void FollowBuilding()
    {
        ClearArea();

        temp.area.position = gridLayout.WorldToCell(temp.gameObject.transform.position);
        BoundsInt buildingArea = temp.area;

        TileBase[] baseArray = GetTilesBlock(buildingArea, mainTilemap); //메인 타일맵에서 타일 배열을 얻음

        int size = baseArray.Length;
        TileBase[] tileArray = new TileBase[size]; //타일 배열 만들기

        for (int i = 0; i < baseArray.Length; i++) //배치 가능한지 알아보기
        {
            if (baseArray[i] == tileBases[TileType.White])
            {
                tileArray[i] = tileBases[TileType.Green];
            }
            else
            {
                FillTiles(tileArray, TileType.Red);
                break;
            }
        } 

        //임시 타일맵에 타일을 설정하고 이전 영역 다시 할당
        tempTilemap.SetTilesBlock(buildingArea, tileArray);
        prevArea = buildingArea;
    }

    #endregion
}
