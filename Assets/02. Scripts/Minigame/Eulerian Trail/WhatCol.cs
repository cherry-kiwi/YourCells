using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhatCol : MonoBehaviour
{

    private int collisionCount = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        collisionCount++;
        Debug.Log("Triggers count: " + collisionCount);
    }
}
