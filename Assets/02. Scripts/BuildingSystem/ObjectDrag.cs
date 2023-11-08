using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDrag : MonoBehaviour
{
    private Vector3 startPos; // 초기 위치
    private float deltaX, deltaY;

    void Start()
    {
        startPos = Input.mousePosition;
        startPos = Camera.main.ScreenToWorldPoint(startPos);

        // 시작 위치에서 현재 개체 위치를 뺌
        deltaX = startPos.x - transform.position.x;
        deltaY = startPos.y - transform.position.y;
    }

    void Update()
    {
        // 마우스 위치를 가져와 세계 좌표로 변환
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 pos = new Vector3(mousePos.x - deltaX, mousePos.y - deltaY);

        Vector3Int cellPos = BuildingSystem.instance.gridLayout.WorldToCell(pos);
        transform.position = BuildingSystem.instance.gridLayout.CellToLocalInterpolated(cellPos); // 보간된 셀 위치를 로컬 위치 공간으로 변환
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<PlacableObject>().CheckPlacement();
            Destroy(this);
        }
    }
}
