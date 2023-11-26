using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BounceAnim : MonoBehaviour
{
    float time = 0;
    public float _size = 5;
    public float _upSizeTime = 0.2f;

    [SerializeField] Main_ScoreSystem ScoreSys; 
   

    // Start is called before the first frame update
    void Start()
    {
        ScoreSys.Com_bo += BounceStart;
    }

    private void BounceStart()
    {
        StartCoroutine(BounceText());
    }

    private IEnumerator BounceText()
    {
        time = 0;
        while (true)
        {
            if (time <= _upSizeTime)
            {
                transform.localScale = Vector3.one * (1 + _size * time);
            }
            else if (time <= _upSizeTime * 2)
            {
                transform.localScale = Vector3.one * (2 * _size * _upSizeTime + 1 - time * _size);
            }
            else
            {
                transform.localScale = Vector3.one;
                break;
            }
            time += Time.deltaTime;
            yield return null;
        }
    }


    

}