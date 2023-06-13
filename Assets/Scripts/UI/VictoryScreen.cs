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
        FindObjectOfType<Pause>().Victory();
    }

    public void Restart()
    {
        FindObjectOfType<Pause>().StartScene();
    }

    public void Exit()
    {
        SceneManager.LoadScene(sceneName);
    }

}
