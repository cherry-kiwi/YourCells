using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MillStone : MonoBehaviour
{
    [SerializeField] private Main_ScoreSystem ScoreSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Obs")
        {
            Destroy(collision.gameObject);
            ScoreSystem._Time -= 10;
            
        }
    }
}
