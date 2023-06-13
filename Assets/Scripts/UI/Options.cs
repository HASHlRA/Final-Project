using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private AudioMixer audioMixerSFX;
    public void FullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
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
