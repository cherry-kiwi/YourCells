using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public void MoveToScene_MainLobbyScene()
    {
        SceneManager.LoadScene("02. MainLobbyScene");
    }
}