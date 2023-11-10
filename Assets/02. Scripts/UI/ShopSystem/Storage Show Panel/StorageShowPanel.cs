using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Structure", menuName = "Scriptable Object/Storage")]

public class StorageShowPanel : ScriptableObject
{
    public new string name;
    public int price;
    public ObjectType type;
    public GameObject prefab;

}
