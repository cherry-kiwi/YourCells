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


    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obs")
        {
            Destroy(collision.gameObject);
            fatMan_Slide.SetActive(false);
            ScoreSystem._Time -= 10;
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


}
