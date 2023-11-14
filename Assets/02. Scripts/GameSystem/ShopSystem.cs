using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
    public static ShopSystem instance;

    public List<StructureSlotPanel> itemList;

    private void Awake()
    {
        instance = this;
    }

}

// 코인, 크리스탈, 스테미나 세 가지 화폐 타입
public enum CurrencyType { Coins, /* TODO: Crystals, Stamina*/ }