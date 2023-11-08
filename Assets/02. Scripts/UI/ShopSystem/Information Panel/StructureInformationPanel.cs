using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Structure", menuName = "Scriptable Object/Information")]

public class StructureInformationPanel : ScriptableObject
{
    //public StructureInfoArray[] TestInt;
    public new string name;
    public string description;
    public int price;

    public Sprite image;
    
    public void Print()
    {
        Debug.Log("건물 이름: " + name + " / 건물 설명: " + description + " / 건물 비용: " + price);
    }
}
