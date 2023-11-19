using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CellManager : MonoBehaviour
{
    public static CellManager instance;

    public List<CellCard> myCells;

    private void Awake()
    {
        instance = this;
    }
}
