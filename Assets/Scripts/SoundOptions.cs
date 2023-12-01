using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundOptions : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider masterSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    void Start()
    {
        if(PlayerPrefs.GetInt("Default Volume Changed") == 0)
        {
            masterSlider.value = -20;
            musicSlider.value = -20;
            sfxSlider.value = -20;
            PlayerPrefs.SetInt("Default Volume Changed",1);
        }
        else {
            masterSlider.value = PlayerPrefs.GetFloat("Master");
            musicSlider.value = PlayerPrefs.GetFloat("Music");
            sfxSlider.value = PlayerPrefs.GetFloat("SFX");
        }
    }

    void SetVolume(string name, Slider slider)
    {
        PlayerPrefs.SetFloat(name,slider.value);
        mixer.SetFloat(name, slider.value);
    }

    public void SetMasterVolume()
    {
        SetVolume("Master", masterSlider);
    }

    public void SetMusicVolume()
    {
        SetVolume("Music", musicSlider);
    }

    public void SetSFXVolume()
    {
        SetVolume("SFX", sfxSlider);
    }
}
