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

    //// 모든 화폐들을 저장할 딕셔너리
    //private static Dictionary<CurrencyType, int> currencyAmounts = new Dictionary<CurrencyType, int>();

    //// 위 텍스트에 대한 딕셔너리
    //private Dictionary<CurrencyType, Text> currencyTexts = new Dictionary<CurrencyType, Text>();

    //// UI 부분
    //[SerializeField]
    //private List<GameObject> texts;

    //private void Awake()
    //{
    //    // 두 딕셔너리 초기화
    //    for (int i = 0; i < texts.Count; i++)
    //    {
    //        currencyAmounts.Add((CurrencyType)i, 0);
    //        currencyTexts.Add((CurrencyType)i, texts[i].transform.GetChild(0).GetComponent<Text>());
    //    }
    //}

}

// 코인, 크리스탈, 스테미나 세 가지 화폐 타입
public enum CurrencyType { Coins, /* TODO: Crystals, Stamina*/ }