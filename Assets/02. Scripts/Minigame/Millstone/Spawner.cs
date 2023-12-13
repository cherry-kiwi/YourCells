using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab_FM;
    public GameObject prefab_BM;
    public GameObject FM_Range;
    public GameObject Millstone_obj;
    [SerializeField] private GameObject FootShadow;
    [SerializeField] private Background_Fatman back_moving;
    [SerializeField] private Main_ScoreSystem _ScoreSystem;

    private float FatmanStart_x; 
    private float FatmanStart_y;

    private BoxCollider2D millstone_Collider;

    public float spd_Fatman;
    public float spd_Bomb;

    float ttime = 0;

    public float FirstSpawn_Time = 5;

    public float Bomb_Spawn_Time = 0;

    float FatMan_Spawn_Time = 0; // 출출이 타이머
    int FatMan_is_Coming = 0; // 출출이 연출 시작시간

    private GameObject II;

    bool BombSpawn_Stop = false;

    int All_SpawnPoint;
    int[] Bomb_SpawnPoint = {0,1,3,4};



    void Start()
    { 
        All_SpawnPoint = transform.childCount;
        
        Bomb_Spawn_Time = FirstSpawn_Time;
        FatMan_is_Coming = Random.Range(6, 11);

        FatmanStart_x = FootShadow.transform.localScale.x;
        FatmanStart_y = FootShadow.transform.lossyScale.y;

        millstone_Collider= Millstone_obj.GetComponent<BoxCollider2D>();
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
        II = Instantiate(prefab_BM, transform.GetChild(Bomb_SpawnPoint[Random.Range(0, 4)]));

        ttime = 0;
        Bomb_Spawn_Time = Random.Range(1, 2);
    }


    private void FatMan_Coming()
    {
        Debug.Log("출출이 오는중");

        back_moving.GimicStart();
        Invoke(nameof(FatMan_Spawn), 5.5f);

        
        StartCoroutine(FatMan_direc());
    }

    private void FatMan_Spawn()
    {
        prefab_FM.SetActive(true);
        FM_Range.SetActive(true);
        _ScoreSystem.FatManPattern = true;
        //millstone_Collider.enabled = false;
        FM_Range.GetComponent<FatMan_Slide_Range>().Swipe = 0;
        FatMan_Spawn_Time = 0;
        FatMan_is_Coming = Random.Range(10, 15);
        Invoke(nameof(Bomb_reSqawn), 6f);
    }

    private IEnumerator FatMan_direc()
    {
        
        yield return new WaitForSeconds(5);
        FootShadow.SetActive(true);
        Color cc = FootShadow.GetComponent<SpriteRenderer>().color;  //
        Color ccc = Millstone_obj.GetComponent<SpriteRenderer>().color;
        while (true)
        {
            cc.a += 0.038f * Time.deltaTime;
            ccc.r -= 0.038f * Time.deltaTime;
            ccc.g -= 0.038f * Time.deltaTime;
            ccc.b -= 0.038f * Time.deltaTime;

            FootShadow.GetComponent<SpriteRenderer>().color = cc;
            Millstone_obj.GetComponent<SpriteRenderer>().color = ccc;


            if (prefab_FM.activeSelf == false)
            {
                FootShadow.transform.localScale = new Vector2(FootShadow.transform.localScale.x + 0.003f, FootShadow.transform.localScale.y + 0.003f);
            }
            else if (prefab_FM.activeSelf == true)
            {
                float k = Vector2.Distance(transform.GetChild(2).position, prefab_FM.transform.position);
                
                FootShadow.transform.localScale = new Vector2(FootShadow.transform.localScale.x + (k * 0.003f), FootShadow.transform.localScale.y + (k * 0.0008f));
            }
            yield return null;

        }
    }

    public void Fatman_reset()
    {
        StopAllCoroutines();
        FootShadow.SetActive(false);
        prefab_FM.transform.position = prefab_FM.transform.parent.position;

        FootShadow.transform.localScale = new Vector2(2.5f, 0.5f);

        Color cc = FootShadow.GetComponent<SpriteRenderer>().color;
        cc.a = 0.3f;
        FootShadow.GetComponent<SpriteRenderer>().color = cc;
        //

        Color ccc = Millstone_obj.GetComponent<SpriteRenderer>().color;
        ccc.r =1;
        ccc.g =1;
        ccc.b =1;
        Millstone_obj.GetComponent<SpriteRenderer>().color = ccc;
        //
        back_moving.GimicEnd();
    }

    private void Bomb_reSqawn()
    {
        BombSpawn_Stop = false;
    }



}
