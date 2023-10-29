using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CurrencySystem : MonoBehaviour
{
    // 모든 화폐들을 저장할 딕셔너리
    private static Dictionary<CurrencyType, int> currencyAmounts = new Dictionary<CurrencyType, int>();

    // UI 부분
    [SerializeField]
    private List<GameObject> texts;

    // 위 텍스트에 대한 딕셔너리
    private Dictionary<CurrencyType, TextMeshProUGUI> currencyTexts = new Dictionary<CurrencyType, TextMeshProUGUI>();

    private void Awake()
    {
        // 두 딕셔너리 초기화
        for (int i = 0; i < texts.Count; i++)
        {
            currencyAmounts.Add((CurrencyType)i, 0);
            currencyTexts.Add((CurrencyType)i, texts[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>());
        }
    }

    private void Start()
    {
        // 돈 부족 팝업 창 띄우기
        EventManager.Instance.AddListener<CurrencyChangeGameEvent>(OnCurrencyChange);
        EventManager.Instance.AddListener<NotEnoughCurrencyGameEvent>(OnNotEnough);
    }

    // CurrencyChangeGameEvent, NotEnoughCurrencyGameEvent에서 이벤트 수신
    private void OnCurrencyChange(CurrencyChangeGameEvent info)
    {
        // 통화 저장
        currencyAmounts[info.currencyType] += info.amount;
        currencyTexts[info.currencyType].text=currencyAmounts[info.currencyType].ToString();
    }

    // 돈 부족 시 Debug.Log, 창은 Start 함수에서 띄움
    private void OnNotEnough(NotEnoughCurrencyGameEvent info)
    {
        Debug.Log($"{info.currencyType}이 {info.amount}만큼 부족합니다!!");
    }
}

// 코인, 크리스탈 두 가지 화폐 타입
public enum CurrencyType { Coins, Crystals }