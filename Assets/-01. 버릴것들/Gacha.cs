using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Gacha : MonoBehaviour
{
    public List<int> gachaList = new List<int>()
    { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

    public List<Sprite> cellImage;
    public List<Sprite> myResult;

    public List<GameObject> myResultPrefab;

    public GameObject cellPanel;
    public GameObject gachaResultImagePrefab;

    public void RandomGacha()
    {
        int rand = Random.Range(0, gachaList.Count);
        int result = gachaList[rand];
        
        for (int i = 0; i < ButtonManager.instance.myCost; i++)
        {
            myResult.Add(cellImage[result]);

            Debug.Log(result);

            myResultPrefab.Add(Instantiate(gachaResultImagePrefab, cellPanel.transform.position, Quaternion.identity));


            myResultPrefab[i].transform.parent = cellPanel.transform;
            myResultPrefab[i].GetComponent<Image>().sprite = myResult[i];
        }
    }
}
