using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StorageSystem : MonoBehaviour
{
    public static StorageSystem instance;

    public List<Sprite> myBuildings;
    public List<GameObject> Content;

    private void Awake()
    {
        instance = this;
    }

}

public enum BuildingType
{
    Floor,
    Building,
    Bridge
}