using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem instance; // 싱글톤 형식

    public GridLayout gridLayout;
    public Tilemap mainTilemap;
    public Tilemap tempTilemap;
    public Vector3 offset = new Vector3(.9f, .9f, 0f);
    //public TileBase takenTile;

    public List<GameObject> myInstalledBuildings;

    [SerializeField] TileBase whiteTile;
    [SerializeField] TileBase greenTile;
    [SerializeField] TileBase redTile;

    private static Dictionary<TileType, TileBase> tileBases = new Dictionary<TileType, TileBase>();

    public Building temp;
    private Vector3 prevPos;
    private BoundsInt prevArea;

    #region Unity Methods

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        tileBases.Add(TileType.Empty, null);
        tileBases.Add(TileType.White, whiteTile);
        tileBases.Add(TileType.Green, greenTile);
        tileBases.Add(TileType.Red, redTile);

        prevPos = new Vector3(1, 1, 0);
    }

    private void Update()
    {
        // 건물 이동
        if (!temp)
        {
            return;
        }
        else
        {
            temp.gameObject.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(EventSystem.current.IsPointerOverGameObject(0))
            {
                return;
            }

            if (!temp.Placed)
            {
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3Int cellPos = gridLayout.LocalToCell(touchPos);

                if (prevPos != cellPos)
                {
                    temp.transform.localPosition = gridLayout.CellToLocalInterpolated(cellPos + offset);
                    prevPos = cellPos;
                    FollowBuilding();
                }
            }
        }
        //// 스페이스 버튼 눌러 배치
        //else if (Input.GetMouseButtonDown(1))
        //{
        //    if (temp.CanBePlaced())
        //    {
        //        temp.Place();
        //    }
        //}
        //// Esc 버튼 눌러 배치 취소
        //else if (Input.GetMouseButtonDown(2))
        //{
        //    ClearArea();
        //    Destroy(temp.gameObject);
        //}
    }

    #endregion

    public void placeBuilding()
    {
        if (temp.CanBePlaced())
        {
            temp.Place();
        }
    }
    public void cancleBuilding()
    {
        ClearArea();
        Destroy(temp.gameObject);
    }

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
        TileBase[] array = new TileBase[area.size.x * area.size.y * area.size.z];
        int counter = 0;

        // BoundsInt(area) 내의 모든 위치를 탐색함
        foreach (var v in area.allPositionsWithin)
        {
            // 위치를 가져와 pos에 저장
            Vector3Int pos = new Vector3Int(v.x, v.y, 0);
            // 특정 위치의 타일맵에서 얻은 타일로 배열 초기화
            // GetTile() 함수: 셀 좌표를 이용해 타일이 있는지 없는지 판단하거나 타일을 얻을 수 있음
            array[counter] = tilemap.GetTile(pos); 
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
    private static void SetTilesBlock(BoundsInt area, TileType type, Tilemap tilemap)
    {
        TileBase[] tileArray = new TileBase[area.size.x * area.size.y * area.size.z];
        FillTiles(tileArray, type);
        // 타일로 채우기
        tilemap.SetTilesBlock(area, tileArray);
    }

    /// <summary>
    /// 타일 채우는 함수
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="tileBase"></param>
    private static void FillTiles(TileBase[] arr, TileType type)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = tileBases[type];
        }
    }
    #endregion

    #region Building Placement (건물 배치)

    /// <summary>
    /// 
    /// </summary>
    /// <param name="building"></param>
    /// <param name="pos"></param>
    public void InitializeBuilding(GameObject building)
    {
        temp = Instantiate(building, prevPos + offset, Quaternion.identity).GetComponent<Building>();
        FollowBuilding();
        myInstalledBuildings.Add(temp.gameObject);
    }

    /// <summary>
    /// BoundsInt 영역 매개변수와 타일맵을 삭제하는 함수
    /// </summary>
    /// <param name="area"></param>
    /// <param name="tilemap"></param>
    private void ClearArea()
    {
        TileBase[] toClear = new TileBase[prevArea.size.x * prevArea.size.y * prevArea.size.z];
        FillTiles(toClear, TileType.Empty);
        tempTilemap.SetTilesBlock(prevArea, toClear);
    }

    /// <summary>
    /// 상태에 따라 타일의 색깔을 표시해주는 함수
    /// </summary>
    private void FollowBuilding()
    {
        ClearArea();

        temp.area.position = gridLayout.WorldToCell(temp.gameObject.transform.position);
        BoundsInt buildingArea = temp.area;

        TileBase[] baseArray = GetTilesBlock(buildingArea, mainTilemap);

        int size = baseArray.Length;
        TileBase[] tileArray = new TileBase[size];

        for (int i = 0; i < baseArray.Length; i++)
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

        tempTilemap.SetTilesBlock(buildingArea, tileArray);
        prevArea = buildingArea;
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
            if (b != tileBases[TileType.White])
            {
                // 해당 지역 사용 불가
                Debug.Log("여긴 배치 불가 구역임");
                return false;
            }
        }

        // 해당 지역 사용 가능
        return true;
    }

    public void TakeArea(BoundsInt area)
    {
        SetTilesBlock(area, TileType.Empty, tempTilemap);
        SetTilesBlock(area, TileType.Green, mainTilemap);
    }

    #endregion
}

public enum TileType
{
    Empty,
    White,
    Green,
    Red
}