using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour
{

}

/// <summary>
/// 통화 변경 이벤트: 통화 일부를 얻거나 쓸 때
/// </summary>
public class CurrencyChangeGameEvent : GameEvent
{
    public int amount;
    public CurrencyType currencyType;

    public CurrencyChangeGameEvent(int amout, CurrencyType currencyType)
    {
        this.amount = amout;
        this.currencyType = currencyType;
    }
}

/// <summary>
/// 통화 불충분 이벤트: CurrencySystem 에서 정보를 수신함
/// </summary>
public class NotEnoughCurrencyGameEvent : GameEvent
{
    public int amount;
    public CurrencyType currencyType;

    public NotEnoughCurrencyGameEvent(int amout, CurrencyType currencyType)
    {
        this.amount = amout;
        this.currencyType = currencyType;
    }
}

/// <summary>
/// 통화 충분 이벤트: CurrencySystem 에서 정보를 수신함
/// </summary>
public class EnoughCurrencyGameEvent : GameEvent
{

}

/// <summary>
/// 경험치 얻음 이벤트: LevelSystem 에 정보를 발신함
/// </summary>
public class XPAddedGameEvent : GameEvent
{
    public int amount;

    public XPAddedGameEvent(int amount)
    {
        this.amount = amount;
    }
}

/// <summary>
/// 레벨 변경 이벤트: 새 래벨 도달 시 상점, 생산 아이템 등의 아이템 잠금 해제
/// </summary>
public class LevelChangedGameEvent : GameEvent
{
    public int newLevel;

    public LevelChangedGameEvent(int currentLevel)
    {
        newLevel = currentLevel;
    }
}