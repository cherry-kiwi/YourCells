using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    public static DontDestroy instance;

    public GameObject all;
    public GameObject mainCam;

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
        }
        else
        {
            all.gameObject.SetActive(false);
        }
    }
}
