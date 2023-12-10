using System.Collections;
using System.Collections.Generic;
using UltimateClean;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public void MoveToScene_MainLobbyScene()
    {
        if (GameManager.instance.isTutorial)
        {
            TutorialManager.instance.index++;
        }

        SceneManager.LoadScene("02. MainLobbyScene");
    }

    public void MiniGameScene_Eulerian_Trail()
    {
        SceneManager.LoadScene("02. MiniGameScene_Eulerian Trail");
    }

    public void MiniGameScene_Factory()
    {
        SceneManager.LoadScene("02. MiniGameScene_Factory");
    }

    public void MiniGameScene_Millstone()
    {
        SceneManager.LoadScene("02. MiniGameScene_Millstone");
    }
}