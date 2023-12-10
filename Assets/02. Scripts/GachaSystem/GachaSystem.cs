using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaSystem : MonoBehaviour
{
    public static GachaSystem instance;

    public List<CellCard> allCells;
    public List<CellCard> myResults;
    //public List<CellCard> interSection = new List<CellCard>();

    public int totalWeight = 0; // 세포 가중치 총 합 (100) (가중치 = 각 세포마다 몇 %인지)

    public Transform gachaResultPanel;
    public GameObject cellCardPrefab;

    public GameObject CellP;
    public GameObject[] Cells;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        for (int i = 0; i < allCells.Count; i++)
        {
            totalWeight += allCells[i].weight; // 가중치 구해줌
        }
    }

    public void ResetMyCellPanel()
    {
        for(int i = 0; i < myResults.Count; i++)
        {
            myResults.Remove(myResults[i]);
        }

        myResults = new List<CellCard>();

        for (int i = 0; i < gachaResultPanel.transform.childCount; i++)
        {
            Destroy(gachaResultPanel.transform.GetChild(i).gameObject);
        }

        ButtonManager.instance.Inactive_GachaResultPanel(); // 고쳐야됨 ㅆㅃ
        //NullReferenceException: SerializedObject of SerializedProperty has been Disposed. <- 이 오류 ㅅㅂ

    }

    public void Result()
    {
        if (MoneySystem.instance.zem >= ButtonManager.instance.myCost * 30)
        {
            ButtonManager.instance.Active_GachaResultPanel();
            ButtonManager.instance.Inactive_GachaPopupPanel();

            List<string> cellsName = new List<string>();

            for (int j = 0; j < CellManager.instance.myCells.Count; j++)
            {
                cellsName.Add(CellManager.instance.myCells[j].cellName);
            }

            for (int i = 0; i < ButtonManager.instance.myCost; i++)
            {
                myResults.Add(RandomCard());

                int R = Random.Range(0, 2);

                if(R == 0)
                {
                    Instantiate(Cells[0], new Vector3(0, -2.3f, 0), Quaternion.identity, CellP.transform);
                }   
                else
                {
                    Instantiate(Cells[1], new Vector3(0, -2.3f, 0), Quaternion.identity, CellP.transform);
                }

                if (cellsName.Contains(myResults[i].cellName))
                {
                    CellCardUI cellCardUI = Instantiate(cellCardPrefab, gachaResultPanel).GetComponent<CellCardUI>();
                    cellCardUI.CardSetting(myResults[i]);

                    for (int k = 0; k < CellManager.instance.myCells.Count; k++)
                    {
                        if (myResults[i].cellName == CellManager.instance.myCells[k].cellName)
                        {
                            CellManager.instance.myCells[k].cellData.primeEnergy += 1;
                        }
                    }
                    Debug.Log("중복 세포 뽑기 결과: " + myResults[i].cellName);
                }
                else
                {
                    cellsName.Add(myResults[i].cellName);
                    CellManager.instance.myCells.Add(myResults[i]);
                    CellCardUI cellCardUI = Instantiate(cellCardPrefab, gachaResultPanel).GetComponent<CellCardUI>();
                    cellCardUI.CardSetting(myResults[i]);
                    Debug.Log("세포 뽑기 결과: " + myResults[i].cellName);
                }
            }

            MoneySystem.instance.zem -= ButtonManager.instance.myCost * 30;
        }
        else
        {
            AndroidToast.I.ShowToastMessage("보석이 모자랍니다!");
        }
    }

    public CellCard RandomCard()
    {
        int weight = 0;
        int selectNum = 0;

        selectNum = Mathf.RoundToInt(totalWeight * Random.Range(0.0f, 1.0f));

        for(int i = 0; i < allCells.Count; i++)
        {
            weight += allCells[i].weight;
            if (selectNum <= weight)
            {
                CellCard temp = new CellCard(allCells[i]);
                return temp;
            }
        }

        return null;
    }
}
