using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] public float life;

    private HealthBar healthBar;

    private void Start()
    {
        healthBar.StartHealthBar(life);
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        healthBar.StartHealthBar(life);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
