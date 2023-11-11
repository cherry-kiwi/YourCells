using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StructureInformationDisplay : MonoBehaviour
{
    public StructureInformationPanel structureInformationPanel;
    public List<StructureInformationPanel> structureSlots = new List<StructureInformationPanel>();

    public Text nameText; // 嫄대Ъ???대쫫
    public Text descriptionText; // 嫄대Ъ???ㅻ챸

    public Image structureImage; // 嫄대Ъ???대?吏

    public Text priceText; // 嫄대Ъ??媛寃?

    /// <summary>
    /// Description Panel??嫄대Ъ???몃? ?뺣낫瑜??쒖떆?댁쨲
    /// </summary>
    void Update()
    {
        nameText.text = structureInformationPanel.name; // 嫄대Ъ???대쫫
        descriptionText.text = structureInformationPanel.description; // 嫄대Ъ???ㅻ챸

        structureImage.sprite = structureInformationPanel.image; // 嫄대Ъ???대?吏

        priceText.text = structureInformationPanel.price.ToString(); // 嫄대Ъ??媛寃?
    }
}
