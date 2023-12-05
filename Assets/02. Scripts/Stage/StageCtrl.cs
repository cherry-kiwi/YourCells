using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageCtrl : MonoBehaviour
{
    public static StageCtrl instance;

    public GameObject CellSelectPanel;
    public GameObject CellButton;
    public List<GameObject> CellList;

    public int gameNum;
    public int goalScore;

    [Header("세포 선택")]

    public CellData SelectCell;
    public Image Cellimg;
    public Text Cellinfor;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SelectCell = CellManager.instance.myCells[0].cellData;

        Cellimg.sprite = SelectCell.image;
        Cellinfor.text = SelectCell.description;
    }

    public void SetCell()
    {
        for (int i = 0; i < CellManager.instance.myCells.Count; i++)
        {
            //프리팹 생성
            CellList.Add(Instantiate(CellButton, CellSelectPanel.transform));

            CellList[i].GetComponent<CellButton>().cellData = CellManager.instance.myCells[i].cellData;
        }
    }

    public void ResetCell()
    {
        for (int i = 0; i < CellList.Count; i++)
        {
            //프리팹 제거
            Destroy(CellList[i]);
        }
            CellList.Clear();
    }

    //public void CellSelec(CellData nowCell)
    //{
    //    SelectCell = nowCell;
    //    Cellimg.sprite = SelectCell.image;
    //    Cellinfor.text = SelectCell.description;
    //}

    public void MiniGameStart()
    {
        if (gameNum == 0) 
        {
            SceneManager.LoadScene("02. MiniGameScene_Millstone");
        }
        else if (gameNum == 1) 
        {
            SceneManager.LoadScene("02. MiniGameScene_Factory");
        }
    }
}
