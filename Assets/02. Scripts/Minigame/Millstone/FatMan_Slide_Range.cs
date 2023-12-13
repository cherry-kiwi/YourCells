
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatMan_Slide_Range : MonoBehaviour
{
    public Transform FatMan_obs;
    private Obstacle obs_scr;
    public int Swipe = 0;

    [SerializeField] private Main_ScoreSystem _ScoreSystem;
    [SerializeField] private BoxCollider2D Mill_Collider;
    [SerializeField] private ParticleSystem[] HitEft;

 

    public void Slide_Succes()
    {
        int k = Random.Range(0, 4);
        obs_scr = FatMan_obs.GetComponent<Obstacle>();
        obs_scr.FatMan_obs_Click();
        Swipe++;
        HitEft[k].Play();

        if (Swipe > 25)
        {
            gameObject.SetActive(false);
            //Mill_Collider.enabled = true;
            FatMan_obs.gameObject.SetActive(false);
            FatMan_obs.root.GetComponent<Spawner>().Fatman_reset();
            Swipe= 0;
            _ScoreSystem.FatManPattern = false;
        }
    }
}
