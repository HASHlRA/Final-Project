using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] public float life;
    //public string uuid;
    //private HealthBar healthBar;

    private void Start()
    {
        //healthBar.StartHealthBar(life);
        Time.timeScale = 1f;
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //healthBar.StartHealthBar(life);
        //FindObjectOfType<PlayerMovement>().nextUuid = uuid;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
