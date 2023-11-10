using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Structure", menuName = "Scriptable Object/Slot")]

public class StructureSlotPanel : ScriptableObject
{
    public new string name;
    public int price;
    public Sprite image;
    public ObjectType type;
    public GameObject itemPrefab;

    public void Print()
    {
        Debug.Log("건물 이름: " + name + " / 건물 비용: " + price);
    }
}

/// <summary>
/// 상점 판매 물품 종류
/// </summary>
//public enum ItemType
//{
//    Tile,
//    Building,
//    Bridge,
//    // TODO: 추후 추가 예정
//}
