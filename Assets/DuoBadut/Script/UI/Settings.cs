using SimpleInputNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    //camera sensitivity
    [SerializeField] private Touchpad theTouchpad;
    [SerializeField] private Slider sensiSlider;
    [SerializeField] private float maxSensi;
    private float currentSensi = 1f;

    //sfx & music volume
    [SerializeField] private AudioSource sfxAudio, musicAudio1, musicAudio2;
    public float currentSFXVolume = 1f;
    public float currentMusicVolume = 1f;
    private float volumeMaxValue = 1f;
    [SerializeField] private Slider SFXSlider, musicSlider;

    [SerializeField] private GameObject grassGarden, treeGarden, bushGarden;
    // Start is called before the first frame update
    void Start()
    {
        sensiSlider.maxValue = maxSensi;
        sensiSlider.value = currentSensi;

        SFXSlider.maxValue = volumeMaxValue;
        musicSlider.maxValue = volumeMaxValue;

        SFXSlider.value = currentSFXVolume;
        musicSlider.value = currentMusicVolume;
    }

    // Update is called once per frame
    void Update()
    {
        currentSensi = sensiSlider.value;
        theTouchpad.sensitivity = currentSensi;

        currentSFXVolume = SFXSlider.value;
        currentMusicVolume = musicSlider.value;

        sfxAudio.volume = currentSFXVolume;

        musicAudio1.volume = currentMusicVolume;
        musicAudio2.volume = currentMusicVolume;
    }

    public void SetGraphics(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        Debug.Log("quality index = " + qualityIndex);
        if (qualityIndex == 3)
        {
            grassGarden.SetActive(true);
            treeGarden.SetActive(true);
            bushGarden.SetActive(true);
        }
        else
        {
            grassGarden.SetActive(false);
            treeGarden.SetActive(false);
            bushGarden.SetActive(false);
        }
    }

    public void SaveSettings()
    {
        //currentSensi = sensiSlider.value;
        //theTouchpad.sensitivity = currentSensi;

        //currentSFXVolume = SFXSlider.value;
        //currentMusicVolume = musicSlider.value;

        //sfxAudio.volume = currentSFXVolume;

        //musicAudio1.volume = currentMusicVolume;
        //musicAudio2.volume = currentMusicVolume;
    }
}
