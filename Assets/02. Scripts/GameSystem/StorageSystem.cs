using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class StorageSystem : MonoBehaviour/*, IBeginDragHandler, IDragHandler, IEndDragHandler*/
{
    public static StorageSystem instance;

    public List<GameObject> myBuildings;

    private void Awake()
    {
        instance = this;
    }

    public void StorageDisplay()
    {
        for(int i = 0; i < myBuildings.Count; i++)
        {
            Instantiate(instance.myBuildings[i]);
        }
    }

    //public void OnBeginDrag(PointerEventData eventData)
    //{

    //}

    //public void OnDrag(PointerEventData data)
    //{

    //}

    //public void OnEndDrag(PointerEventData eventData)
    //{

    //}
}

public enum BuildingType
{
    Floor,
    Building,
    Bridge
}