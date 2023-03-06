using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;

    [SerializeField] private GameObject menuPause;

    public string sceneName;

    public string sceneName1;

    private bool gamePaused = false;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gamePaused)
            {
                Resume();
            }
            else
            {
                Pausa();
            }
        }
    }
    public void Pausa()
    {
        gamePaused = true;
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        menuPause.SetActive(true);
    }

    public void Resume()
    {
        gamePaused = false;
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
        menuPause.SetActive(false);
    }

    public void Restart()
    {
        gamePaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName1);
    }

    public void Exit()
    {
        SceneManager.LoadScene(sceneName);
    }

}