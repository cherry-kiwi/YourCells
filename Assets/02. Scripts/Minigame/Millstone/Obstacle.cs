using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    
    public kindd Whatisthis;
    public GameObject Mill_;

    Vector2 To_;

    public enum kindd
    {
        FatMan,
        Bomb
    }

    void Start()
    {
        To_ = Mill_.transform.position;
        if (this.name.StartsWith("FatMan"))
        {
            Whatisthis = kindd.FatMan;
        } 
        else if (this.name.StartsWith("Bomb"))
        {
            Whatisthis= kindd.Bomb;
        }
    }

    private void Update()
    {
        //if (kindd.Bomb == Whatisthis)
        //{
        //    if((transform.position - Mill_.transform.position) )
        //}

        if (kindd.FatMan == Whatisthis)
        {
            transform.position = Vector2.MoveTowards(transform.position, To_, 0.01f);
        }
    }

}
