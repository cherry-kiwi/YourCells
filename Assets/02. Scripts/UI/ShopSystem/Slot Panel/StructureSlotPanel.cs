using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Structure", menuName = "Scriptable Object/Slot")]

public class StructureSlotPanel : ScriptableObject
{
    public new string name;
    public int price;
    public Sprite image;

    public void Print()
    {
        Debug.Log("건물 이름: " + name + " / 건물 비용: " + price);
    }
}
