using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveCellInfoPanel : MonoBehaviour
{
    public GameObject cellInfoPanel;
    public GameObject CellListPopUp;

    public Text CellName;
    public Image CellImage;
    public Text CellHP;
    public Text CellPower;
    public Text CellDescription;
    public Slider CellPrimeEnergy;

    private void Start()
    {
        CellListPopUp = GameObject.Find("Cell List PopUp");
    }

    public void Active_CellInfoPanel()
    {
        cellInfoPanel.SetActive(true);

        cellInfoPanel.transform.SetParent(CellListPopUp.transform);
        cellInfoPanel.transform.localScale = new Vector3(1, 1, 1);
        cellInfoPanel.transform.position = Camera.main.WorldToScreenPoint(new Vector3(0,0,0) + Camera.main.transform.position);

        for (int i = 0; i < CellManager.instance.myCells.Count; i++)
        {
            if (gameObject.GetComponent<Image>().sprite == CellManager.instance.myCells[i].cellImage)
            {
                CellName.text = CellManager.instance.myCells[i].cellData.name;
                CellImage.sprite = CellManager.instance.myCells[i].cellData.image;
                CellHP.text = CellManager.instance.myCells[i].cellData.hP.ToString();
                CellPower.text = CellManager.instance.myCells[i].cellData.power.ToString();
                CellDescription.text = CellManager.instance.myCells[i].cellData.description;
                CellPrimeEnergy.value = CellManager.instance.myCells[i].cellData.primeEnergy / 100f;
            }
        }
    }
    public void Inactive_CellInfoPanel()
    {
        cellInfoPanel.SetActive(false);
    }
}
