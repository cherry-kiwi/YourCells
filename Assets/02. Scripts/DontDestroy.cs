using System.Collections;
using System.Collections.Generic;
using UltimateClean;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    public static DontDestroy instance;

    public GameObject all;
    public GameObject mainCam;


    public GameObject Snd;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == ("02. MainLobbyScene") || SceneManager.GetActiveScene().name == ("01. TitleScene"))
        {
            mainCam.SetActive(true);
        }
        else
        {
            mainCam.SetActive(false);
        }

        if (SceneManager.GetActiveScene().name == ("02. MainLobbyScene"))
        {
            all.gameObject.SetActive(true);

            if (Snd.GetComponent<AudioSource>().clip.name == "미니게임 브금")
            {
                Snd.GetComponent<ButtonBgmSounds>().PlayRobySound();
            }
        }
        else if(SceneManager.GetActiveScene().name == ("02. MiniGameScene_Millstone"))
        {
            if (Snd.GetComponent<AudioSource>().clip.name != "미니게임 브금")
            {
                Snd.GetComponent<ButtonBgmSounds>().PlayMinigameSound();
            }

            all.gameObject.SetActive(false);
        }
        else
        {
            all.gameObject.SetActive(false);
        }
    }
}
