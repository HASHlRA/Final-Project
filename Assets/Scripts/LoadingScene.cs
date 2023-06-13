using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LoadingScene : MonoBehaviour
{

    public GameObject LoadingScreen;
    //[SerializeField] private Slider loadingSlider;

    public void LoadScene(int sceneId)
    {

        LoadingScreen.SetActive(true);
       
        StartCoroutine(LoadSceneAsync(sceneId));
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {
        //FindObjectOfType<UISpriteAnimation>().Func_PlayAnimUI();

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);

            //loadingSlider.value = progressValue;

            yield return null;
        }

    }
}
