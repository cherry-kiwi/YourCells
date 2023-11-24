using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    public Slider slider;
    public string SceneName;

    private float time;

    void Start()
    {
        StartCoroutine(LoadAsynSceneCoroutine());
    }

    IEnumerator LoadAsynSceneCoroutine()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneName);
        operation.allowSceneActivation = false; // 로딩이 완료되었을 때, 자동으로 다음 씬으로 넘어가지 않고 기다림

        while (!operation.isDone)
        {
            time += Time.deltaTime;
            slider.value = time / 10f;

            if (time > 10f)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}