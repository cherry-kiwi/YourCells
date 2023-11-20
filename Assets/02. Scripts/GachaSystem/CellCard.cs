using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CellCard
{
    public string cellName;
    public Sprite cellImage;
    public int weight;
    public CellData cellData;

    public CellCard(CellCard cellCard)
    {
        this.cellName = cellCard.cellName;
        this.cellImage = cellCard.cellImage;
        this.weight = cellCard.weight;
        this.cellData = cellCard.cellData;
    }
}