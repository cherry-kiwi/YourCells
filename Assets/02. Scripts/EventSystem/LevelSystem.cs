using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    private int nowXP;
    private int userLevel;
    private int xpToNext;

    [SerializeField] private GameObject levelPanel; // 레벨 정보가 포함된 UI 패널 게임 오브젝트
    [SerializeField] private GameObject levelWindowPrefab;

    // 개인정보 창에 표시될 필드들
    private Slider xpSlider;
    private TextMeshProUGUI xpText;
    private TextMeshProUGUI lvlText;
    private Image starImage; //?? 일단 튜토리얼 따라하기

    private static bool initialized;
    private static Dictionary<int, int> xpToNextLevel = new Dictionary<int, int>(); //xp 저장하는 딕셔너리
    private static Dictionary<int, int[]> lvlReward = new Dictionary<int, int[]>(); //특정 레벨 도달 시 보상 저장하는 딕셔너리

    //private void Awake()
    //{
    //    xpSlider = levelPanel.GetComponent<Slider>();
    //    xpText = levelPanel.transform.Find("XP text").GetComponent<TextMeshProUGUI>();
    //    starImage = levelPanel.transform.Find("Star").GetComponent<Image>();
    //    lvlText = starImage.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

    //    if (!initialized)
    //    {
    //        Initialize();
    //    }

    //    //xpToNextLevel.TryGetValue(level)
    //}

    private static void Initialize()
    {
        try
        {
            string path = "levelsXP";

            TextAsset textAsset = Resources.Load<TextAsset>(path);
            string[] lines = textAsset.text.Split('\n');

            xpToNextLevel = new Dictionary<int, int>(lines.Length - 1);

            for (int i = 1; i < lines.Length - 1; i++)
            {
                string[] columns = lines[i].Split(',');

                int lvl = -1;
                int xp = -1;
                int curr1 = -1;
                int curr2 = -1;

                int.TryParse(columns[0], out lvl);
                int.TryParse(columns[1], out xp);
                int.TryParse(columns[2], out curr1);
                int.TryParse(columns[3], out curr2);

                if (lvl >= 0 && xp > 0)
                {
                    if (!xpToNextLevel.ContainsKey(lvl))
                    {
                        xpToNextLevel.Add(lvl, xp);
                        lvlReward.Add(lvl, new[] { curr1, curr2 });
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }

        initialized = true;
    }

    private void Start()
    {
        EventManager.Instance.AddListener<XPAddedGameEvent>(OnXPAdded);
        EventManager.Instance.AddListener<LevelChangedGameEvent>(OnLevelChanged);

        UpdateUI();
    }

    private void UpdateUI()
    {
        //float fill = (float)nowXP / xpToNext;
        //xpSlider.value = fill;
        //xpText.text = nowXP + "/" + xpToNext;
    }

    /// <summary>
    /// XP 증가시 유저레벨 업데이트
    /// </summary>
    /// <param name="info"></param>
    private void OnXPAdded(XPAddedGameEvent info)
    {
        nowXP += info.amount;

        UpdateUI();

        if (nowXP >= xpToNext)
        {
            userLevel++;
            LevelChangedGameEvent levelChange = new LevelChangedGameEvent(userLevel);
            EventManager.Instance.QueueEvent(levelChange);
        }
    }

    /// <summary>
    /// 현재 XP 재설정
    /// </summary>
    /// <param name="info"></param>
    private void OnLevelChanged(LevelChangedGameEvent info)
    {
        nowXP -= xpToNext;
        xpToNext = xpToNextLevel[info.newLevel];
        lvlText.text = (info.newLevel + 1).ToString();
        UpdateUI();

        // 새 레발 창 인스턴스화
        GameObject window = Instantiate(levelWindowPrefab, GameManager.instance.canvas.transform);

        window.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(delegate
        {
            Destroy(window);
        });

        CurrencyChangeGameEvent currencyInfo = new CurrencyChangeGameEvent(lvlReward[info.newLevel][0], CurrencyType.Coins);
        EventManager.Instance.QueueEvent(currencyInfo);

        currencyInfo = new CurrencyChangeGameEvent(lvlReward[info.newLevel][1], CurrencyType.Crystals);
        EventManager.Instance.QueueEvent(currencyInfo);
    }
}
