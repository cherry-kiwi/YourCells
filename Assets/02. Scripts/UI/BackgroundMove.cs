using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    void Update()
    {
        transform.position = Vector3.zero + (Camera.main.ScreenToWorldPoint(Camera.main.transform.position + new Vector3(540, 2060, 20))/2);
    }
}
