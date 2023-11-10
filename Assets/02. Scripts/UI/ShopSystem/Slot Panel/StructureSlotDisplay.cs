using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StructureSlotDisplay : MonoBehaviour
{
    public StructureSlotPanel structureSlotPanel;
    public static StructureSlotDisplay structureSlotDisplay;

    public Text nameText; // 건물의 이름
    public Text priceText; // 건물의 가격
    public Image structureImage; // 건물의 이미지
    public GameObject prefab; // 건물의 프리팹

    /// <summary>
    /// Description Panel에 건물의 세부 정보를 표시해줌
    /// </summary>
    public void Start()
    {
        nameText.text = structureSlotPanel.name; // 건물의 이름
        structureImage.sprite = structureSlotPanel.image; // 건물의 이미지
        priceText.text = structureSlotPanel.price.ToString(); // 건물의 가격
    }
}
