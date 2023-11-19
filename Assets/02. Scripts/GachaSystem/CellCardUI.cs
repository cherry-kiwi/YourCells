using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellCardUI : MonoBehaviour
{
    public Image cardImage;
    public Text cardName;

    public void CardSetting(CellCard cellCard)
    {
        cardImage.sprite = cellCard.cellImage;
        cardName.text = cellCard.cellName;
    }
}
