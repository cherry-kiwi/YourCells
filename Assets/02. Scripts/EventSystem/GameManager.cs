using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 싱글톤

    public GameObject canvas;

    private void Awake()
    {
        instance = this; // 초기화
    }

    /// <summary>
    /// XP 얻는 함수
    /// </summary>
    /// <param name="amount"></param>
    public void GetXP(int amount)
    {
        XPAddedGameEvent info = new XPAddedGameEvent(amount);
        EventManager.Instance.QueueEvent(info);
    }

    /// <summary>
    /// 코인 얻는 함수
    /// </summary>
    /// <param name="amount"></param>
    public void GetCoins(int amount)
    {
        CurrencyChangeGameEvent info = new CurrencyChangeGameEvent(amount, CurrencyType.Coins);
        EventManager.Instance.QueueEvent(info);
    }
}