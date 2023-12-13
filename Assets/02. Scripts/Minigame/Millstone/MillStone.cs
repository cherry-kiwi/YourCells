using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MillStone : MonoBehaviour
{
    [SerializeField] private Sprite[] Millstone_spt;
    private SpriteRenderer _spriteRenderer;

    private int sptNum = 0;

    [SerializeField] private Main_ScoreSystem ScoreSystem;
    [SerializeField] private GameObject fatMan_Slide;
    [SerializeField] private Transform _Cam;
    [SerializeField] private hpBar HPbar;

    [SerializeField] private float ShakeAmount;
    float ShakeTime;
    Vector3 initPos;

    [SerializeField] private ParticleSystem[] BombHit;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        initPos = _Cam.transform.position;
    }

    public void VibeTime(float _time)
    {
        ShakeTime = _time;
    }

    private void Update()
    {
        if(ShakeTime > 0) 
        {
            _Cam.position = Random.insideUnitSphere * ShakeAmount + initPos;
            ShakeTime -= Time.deltaTime;
        }
        else
        {
            ShakeTime= 0;
            _Cam.position = initPos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obs")
        {
            
            collision.gameObject.SetActive(false);
            fatMan_Slide.SetActive(false);

            if (collision.name == "FatMan")
            {
                collision.transform.root.GetComponent<Spawner>().Fatman_reset();
                VibeTime(0.5f);
                ScoreSystem.StartCoroutine(ScoreSystem.StunFunc());
                ScoreSystem.FatManPattern = false;
            }
            else if (collision.name.StartsWith("Bomb"))
            {
                int i = Random.Range(0, 3);
                BombHit[i].transform.position = collision.transform.position;
                BombHit[i].Play();
                VibeTime(0.1f);

            }

            HPbar.umm_didyouHit();
            ScoreSystem.comboInt= 0;
            ScoreSystem.textpUpdate();
        }
    }

    public void BingBingDolaganeun()
    {
        if (sptNum >= 4)
        {
            sptNum = 0;
        }
        _spriteRenderer.sprite = Millstone_spt[sptNum];

        sptNum++;
    }

    public void FailToFatman()
    {
        //collision.transform.root.GetComponent<Spawner>().Fatman_reset();
        VibeTime(0.5f);
        ScoreSystem.StartCoroutine(ScoreSystem.StunFunc());
    }





}
