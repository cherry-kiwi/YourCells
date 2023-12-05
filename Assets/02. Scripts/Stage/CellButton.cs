using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.UI;

public class CellButton : MonoBehaviour
{
    public CellData cellData;
    public Image cellImg;

    public GameObject cellSelectPanel;

    private void Start()
    {
        cellSelectPanel = GameObject.Find("CellSelcet Panel");
    }

    private void Update()
    {
        cellImg.sprite = cellData.image;
    }

    public void CellSelec()
    {
        cellSelectPanel.SetActive(false);
        StageCtrl.instance.SelectCell = cellData;
        StageCtrl.instance.Cellimg.sprite = StageCtrl.instance.SelectCell.image;
        StageCtrl.instance.Cellinfor.text = StageCtrl.instance.SelectCell.description;
    }
}
