using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance; // 싱글톤
    // 금액 표시할 때 사용
    public static Dictionary<CurrencyType, Sprite> currencySprites = new Dictionary<CurrencyType, Sprite>();

    [SerializeField] private List<Sprite> sprites;

    // 상점 UI 애니메이션화
    private RectTransform rt;
    private RectTransform prt;
    private bool opened;

    [SerializeField] private GameObject itemPrefab;
    // 모든 품목을 저장하고 상점을 채우는 용도의 딕셔너리
    private Dictionary<ObjectType, List<ShopItem>> shopItems = new Dictionary<ObjectType, List<ShopItem>>(5);

    // 탭 그룹에 대한 필드
    //[SerializeField] public TabGroup shopTabs;

    private void Awake()
    {
        instance = this; // 현재 필드 초기화
        rt = GetComponent<RectTransform>();
        prt = transform.parent.GetComponent<RectTransform>();

        EventManager.Instance.AddListener<LevelChangedGameEvent>(OnLevelChanged);
    }

    private void Start()
    {
        currencySprites.Add(CurrencyType.Coins, sprites[0]);
        currencySprites.Add(CurrencyType.Crystals, sprites[1]);

        Load();
        Initialize();
    }

    /// <summary>
    /// 상점의 모든 목록을 로드함
    /// </summary>
    private void Load()
    {
        ShopItem[] items = Resources.LoadAll<ShopItem>("Shop");

        // 딕셔너리에 아이템 추가
        shopItems.Add(ObjectType.Floor, new List<ShopItem>());
        shopItems.Add(ObjectType.Bridge, new List<ShopItem>());
        shopItems.Add(ObjectType.Constructure, new List<ShopItem>());

        foreach (var item in items)
        {
            shopItems[item.type].Add(item);
        }
    }

    /// <summary>
    /// 상점 초기화 함수
    /// </summary>
    private void Initialize()
    {
        for(int i = 0; i < shopItems.Keys.Count; i++)
        {
            foreach (var item in shopItems[(ObjectType)i])
            {
                // todo initialize items here
            }
        }
    }

    /// <summary>
    /// 새로운 레벨 도달 시 새 아이템 해금
    /// </summary>
    /// <param name="info"></param>
    private void OnLevelChanged(LevelChangedGameEvent info)
    {
        for(int i=0;i<shopItems.Keys.Count; i++)
        {
            ObjectType key = shopItems.Keys.ToArray()[i];
            for(int j = 0; j < shopItems[key].Count; j++)
            {
                ShopItem item = shopItems[key][j];

                if (item.level == info.newLevel)
                {
                    // todo unlock item 
                }
            }
        }
    }
}
