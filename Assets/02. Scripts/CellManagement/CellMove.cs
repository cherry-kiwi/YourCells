using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellMove : MonoBehaviour
{
    public int m;
    void Update()
    {
        transform.GetComponent<SpriteRenderer>().sortingOrder =
                    3000 + (int)(m * 10 / Camera.main.orthographicSize) + (int)(Camera.main.WorldToScreenPoint(this.transform.position).y * -1);
    }
}
