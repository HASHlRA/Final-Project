using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;

    [SerializeField] private GameObject menuPause;

    public string sceneName;

    public string sceneName1;

    private bool gamePaused = false;

    public Transform startpoint;

    private PlayerHealth playerHealth;

    [SerializeField] private HealthBar healthBar;

    private PlayerMovement playerMovement;

    private void Awake()
    {
       
        Time.timeScale = 1f;
    }

    private void Start()
    {
        pauseButton.SetActive(true);
        Restart();
    }


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
        pauseButton.SetActive(true);
        menuPause.SetActive(false);
        Time.timeScale = 1f;
        //SceneManager.LoadScene(sceneName1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        startpoint = GameObject.Find("StartPoint").transform;
        GameObject.Find("Player").transform.position = startpoint.position;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        playerHealth.SetMaxHealth();
        playerMovement.attackCD();

       

    }

    public void Exit()
    {
        gamePaused = true;
        pauseButton.SetActive(false);
        menuPause.SetActive(false);
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }

}
