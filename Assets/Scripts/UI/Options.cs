using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private AudioMixer audioMixerSFX;
    public void FullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }

    public void Delete()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Main_Menu");
    }

    public void ChangeVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void ChangeVolumeSFX(float volume)
    {
        audioMixerSFX.SetFloat("Volume", volume);
    }
}
