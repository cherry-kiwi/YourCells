using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<GameObject> mainUI;
    public List<GameObject> generalModeUI;
    public List<GameObject> editModeUI;

    public bool isEditing = false;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }


    void Update()
    {
        // 편집 모드 On
        if (isEditing)
        {
            // UI 변경
            for (int i = 0; i < generalModeUI.Count; i++)
            {
                mainUI[i].SetActive(false);
                generalModeUI[i].SetActive(false);
            }

            for(int i=0;i< editModeUI.Count; i++)
            {
                editModeUI[i].SetActive(true);
            }

            // 미리보기 모드

        }
        else // UI 변경
        {

            for (int i = 0; i < mainUI.Count; i++)
            {
                mainUI[i].SetActive(true);
            }

            for (int i = 0; i < editModeUI.Count; i++)
            {
                editModeUI[i].SetActive(false);
            }
        }
    }
}
