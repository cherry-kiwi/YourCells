using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellSkill : MonoBehaviour
{
    [SerializeField] private Main_ScoreSystem scoreSystem;

    public int E_sung_cell(int k)
    {
        return (int)(k + (k/100 * 6));
    }
    public string E_sung_cell_sInfo()
    {
        return "Bonus Point 6%";
    }
}
