using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab_FM;
    public GameObject prefab_BM;

    public float spd_Fatman;
    public float spd_Bomb;

    float ttime = 0;

    public float FirstSpawn_Time = 5;
    public float Spawn_Time = 0;

    int FirstSpawn_Kind = 0; // 1 = 출출이 , 2 = 폭탄
    int All_SpawnPoint;
    int[] Bomb_SpawnPoint = {0,1,5,6};


    void Start()
    {
        FirstSpawn_Kind = Random.Range(1, 3);
        All_SpawnPoint = transform.childCount;
        Debug.Log(All_SpawnPoint);
        Spawn_Time = FirstSpawn_Time;
    }

    private void Update()
    {
        if (GameStart.GamePlaying)
        {
            ttime += Time.deltaTime;
        }

        if(ttime >=Spawn_Time)
        {
            if (FirstSpawn_Kind == 1)
            {
                GameObject II = Instantiate(prefab_FM,transform.GetChild(Random.Range(0,All_SpawnPoint)));

            }else if (FirstSpawn_Kind == 2) 
            {
                GameObject II = Instantiate(prefab_BM, transform.GetChild(Bomb_SpawnPoint[Random.Range(0,4)]));

            }
            ttime = 0;
            Spawn_Time = Random.Range(1, 2);
            FirstSpawn_Kind = Random.Range(1, 3);
        }

    }

}
