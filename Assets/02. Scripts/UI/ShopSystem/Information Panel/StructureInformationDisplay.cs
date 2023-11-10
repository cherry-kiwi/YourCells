using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StructureInformationDisplay : MonoBehaviour
{
    public StructureInformationPanel structureInformationPanel;
    public List<ScriptableObject> structureSlots = new List<ScriptableObject>();

    public Text nameText; // 건물의 이름
    public Text descriptionText; // 건물의 설명

    public Image structureImage; // 건물의 이미지

    public Text priceText; // 건물의 가격

    /// <summary>
    /// Description Panel에 건물의 세부 정보를 표시해줌
    /// </summary>
    void Start()
    {
        nameText.text = structureInformationPanel.name; // 건물의 이름
        descriptionText.text = structureInformationPanel.description; // 건물의 설명

        structureImage.sprite = structureInformationPanel.image; // 건물의 이미지

        priceText.text = structureInformationPanel.price.ToString(); // 건물의 가격
    }
}
