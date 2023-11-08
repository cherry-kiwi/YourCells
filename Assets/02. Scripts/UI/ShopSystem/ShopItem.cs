using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObjects/Shop Item")]

public class ShopItem : ScriptableObject
{
    public string name = "Default"; // 물건의 이름
    public string description = "Description"; // 물건 설명
    public int level; // 플레이어의 레벨
    public int price; // 물건의 가격 
    public CurrencyType currency; // 재화의 종류 (코인인지, 보석인지, 스태미나...;;인지)
    public ObjectType type; // 물건의 종류 (바닥인지, 건물인지, 다리인지)
    public Sprite Icon; // 물건의 아이콘
    public GameObject prefab; // 물건의 프리팹
}

/// <summary>
/// 상점에서 판매되는 물건 종류들
/// </summary>
public enum ObjectType
{
    Floor,
    Constructure,
    Bridge
}