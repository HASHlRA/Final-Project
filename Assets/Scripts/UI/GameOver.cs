using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameoverMenu;

    [SerializeField] private GameObject healthBar;

    [SerializeField] private GameObject pauseButton;

    private PlayerHealth playerHealth;

    [SerializeField]private GameObject barraVida;

    private AudioSource audiosource;

    [SerializeField] private AudioClip GameOverAudio;

    public string sceneName1;

    public Transform startpoint;

    private PlayerMovement playerMovement;

    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        playerHealth.PlayerDeath += EnableMenu;
        audiosource = GetComponent<AudioSource>();
    }

    public void EnableMenu(object sender, EventArgs e)
    {
        gameoverMenu.SetActive(true);
        healthBar.SetActive(false);
        barraVida.SetActive(false);
        audiosource.PlayOneShot(GameOverAudio);
        Time.timeScale = 0f;
    }

    public void Fall()
    {
        gameoverMenu.SetActive(true);
        healthBar.SetActive(false);
        barraVida.SetActive(false);
        audiosource.PlayOneShot(GameOverAudio);
        Time.timeScale = 0f;
    }

    public void Restart(string name)
    {
        
        
        SceneManager.LoadScene(name);
        gameoverMenu.SetActive(false);
        healthBar.SetActive(true);
        barraVida.SetActive(true);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        startpoint = GameObject.Find("StartPoint").transform;
        GameObject.Find("Player").transform.position = startpoint.position;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        playerHealth.SetMaxHealth();
        playerMovement.attackCD();

        StopAllCoroutines();
    }

    public void MainMenu(string name1)
    {
        SceneManager.LoadScene(name1);
        gameoverMenu.SetActive(false);
        healthBar.SetActive(false);
        barraVida.SetActive(false);
        pauseButton.SetActive(false);
    }
}
