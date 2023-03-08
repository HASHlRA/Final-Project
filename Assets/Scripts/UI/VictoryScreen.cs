using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
    public string sceneName;

    public string sceneName1;

    private AudioSource audiosource;

    [SerializeField] private AudioClip VictoryAudio;

    public void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.PlayOneShot(VictoryAudio);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName1);
    }

    public void Exit()
    {
        SceneManager.LoadScene(sceneName);
    }

}
