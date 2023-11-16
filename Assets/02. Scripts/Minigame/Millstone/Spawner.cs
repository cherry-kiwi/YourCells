using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab_FM;
    public GameObject prefab_BM;


    float tt = 0;
    public float FirstSpawn_Time = 0;
    int FirstSpawn_Kind = 0; // 1 = ÃâÃâÀÌ , 2 = ÆøÅº
    int All_SpawnPoint;

    void Start()
    {
        FirstSpawn_Time = Random.Range(1f,10f);
        FirstSpawn_Kind = Random.Range(1, 3);
        All_SpawnPoint = transform.childCount;
    }

    private void Update()
    {
        tt += Time.deltaTime;

        if(tt>=FirstSpawn_Time)
        {
            if (FirstSpawn_Kind == 1)
            {
                GameObject II = Instantiate(prefab_FM,transform.GetChild(Random.Range(0,All_SpawnPoint+1)));
                
            }//else if (FirstSpawn_Kind == 2) 
            //{
            //    GameObject II = Instantiate(prefab_BM, transform.GetChild(Random.Range(0, All_SpawnPoint + 1)));
                
            //}
            tt = 0;
            FirstSpawn_Time = Random.Range(1, 4);
            FirstSpawn_Kind = Random.Range(1, 3);

        }

    }

}
