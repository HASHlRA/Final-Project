using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameoverMenu;

    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        playerHealth.PlayerDeath += EnableMenu;
    }

    private void EnableMenu(object sender, EventArgs e)
    {
        gameoverMenu.SetActive(true);
    }

    public void Restart(string name)
    {
        SceneManager.LoadScene(name);
        gameoverMenu.SetActive(false);
    }

    public void MainMenu(string name1)
    {
        SceneManager.LoadScene(name1);
        gameoverMenu.SetActive(false);
    }
}
