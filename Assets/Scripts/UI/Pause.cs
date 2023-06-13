using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;

    [SerializeField] private GameObject menuPause;

    [SerializeField] private GameObject playerHealthbar;

    public string sceneName;

    //public string sceneName1;

    private bool gamePaused = false;

    public Transform startpoint;

    private PlayerHealth playerHealth;

    [SerializeField] private HealthBar healthBar;

    public PlayerMovement playerMovement;



    private void Awake()
    {
        //Time.timeScale = 1f;
    }


    private void Start()
    {
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        startpoint = GameObject.Find("StartPoint").transform;
        GameObject.Find("Player").transform.position = startpoint.position;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        playerHealth.SetMaxHealth();
        playerMovement.attackCD();
        playerHealthbar.SetActive(true);
        Time.timeScale = 1f;

    }

    public void StartScene()
    {
        gamePaused = false;
        pauseButton.SetActive(true);
        menuPause.SetActive(false);
        startpoint = GameObject.Find("StartPoint").transform;
        GameObject.Find("Player").transform.position = startpoint.position;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        playerHealth.SetMaxHealth();
        playerMovement.attackCD();
        playerHealthbar.SetActive(true);
        Time.timeScale = 1f;
    }

    public void Victory()
    {
        gamePaused = true;
        pauseButton.SetActive(false);
        menuPause.SetActive(false);
        playerHealthbar.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Exit()
    {
        gamePaused = true;
        pauseButton.SetActive(false);
        menuPause.SetActive(false);
        playerHealthbar.SetActive(false);
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 0f;
    }

}
