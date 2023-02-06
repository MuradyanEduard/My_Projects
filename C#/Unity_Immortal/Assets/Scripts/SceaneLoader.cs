using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class SceaneLoader : MonoBehaviour
{
    public Slider loadingSlider;
    float timeLine = 0;
    bool cond = true;
    private void Start()
    {
        this.timeLine = 0;
        this.cond = true;
        Time.timeScale = 1;
    }
    private void Update()
    {
        timeLine += Time.deltaTime;
        if (timeLine > 1f && cond)
        {
            cond = false;
            StartCoroutine(LoadSceneAsynchronously(1));
        }

    }

    IEnumerator LoadSceneAsynchronously(int levelIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);
        while (!operation.isDone)
        {
            loadingSlider.value = operation.progress;
            yield return null;
        }

    }
}
