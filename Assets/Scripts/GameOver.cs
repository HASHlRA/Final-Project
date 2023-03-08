using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameoverMenu;

    [SerializeField] private GameObject healthBar;

    private PlayerHealth playerHealth;

    [SerializeField]private GameObject barraVida;

    private AudioSource audiosource;

    [SerializeField] private AudioClip GameOverAudio;


    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        playerHealth.PlayerDeath += EnableMenu;
        audiosource = GetComponent<AudioSource>();
    }

    private void EnableMenu(object sender, EventArgs e)
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
    }

    public void MainMenu(string name1)
    {
        SceneManager.LoadScene(name1);
        gameoverMenu.SetActive(false);
        healthBar.SetActive(true);
        barraVida.SetActive(true);
    }
}
