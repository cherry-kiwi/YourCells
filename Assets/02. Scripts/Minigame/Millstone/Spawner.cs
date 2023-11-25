using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Spawner : MonoBehaviour
{
    public GameObject prefab_FM;
    public GameObject prefab_BM;
    public GameObject FM_Range;

    public float spd_Fatman;
    public float spd_Bomb;

    float ttime = 0;

    public float FirstSpawn_Time = 5;

    public float Bomb_Spawn_Time = 0;

    float FatMan_Spawn_Time = 0; // 출출이 타이머
    int FatMan_is_Coming = 0; // 출출이 연출 시작시간

    bool BombSpawn_Stop = false;

    int All_SpawnPoint;
    int[] Bomb_SpawnPoint = {0,1,3,4};


    void Start()
    { 
        All_SpawnPoint = transform.childCount;
        

        Bomb_Spawn_Time = FirstSpawn_Time;
        FatMan_is_Coming = Random.Range(10, 15);

    }

    private void Update()
    {
        if (GameStart.GamePlaying)
        {
            ttime += Time.deltaTime;
            FatMan_Spawn_Time += Time.deltaTime;
        }

        if(ttime >= Bomb_Spawn_Time && BombSpawn_Stop == false) //Bomb Spawn
        {
            Bomb_Spawn();
        }

        if(FatMan_Spawn_Time >= FatMan_is_Coming )
        {
            FatMan_Coming();
            FatMan_Spawn_Time = 0;
            BombSpawn_Stop = true;
        }

    }


    private void Bomb_Spawn()
    {
        GameObject II = Instantiate(prefab_BM, transform.GetChild(Bomb_SpawnPoint[Random.Range(0, 4)]));

        ttime = 0;
        Bomb_Spawn_Time = Random.Range(1, 2);
    }


    private void FatMan_Coming()
    {
        Debug.Log("출출이 오는중");

        Invoke(nameof(FatMan_Spawn), 2);
    }

    private void FatMan_Spawn()
    {
        GameObject II = Instantiate(prefab_FM, transform.GetChild(2));
        FM_Range.SetActive(true);
        FM_Range.GetComponent<FatMan_Slide_Range>().FatMan_obs = II.transform;
        FatMan_Spawn_Time = 0;
        FatMan_is_Coming = Random.Range(10, 15);
        Invoke(nameof(Bomb_reSqawn), 6f);
    }

    private void Bomb_reSqawn()
    {
        BombSpawn_Stop = false;
    }



}
