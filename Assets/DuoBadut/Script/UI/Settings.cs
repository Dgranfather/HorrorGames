using SimpleInputNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

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

    [SerializeField] private GameObject terrainGarden, groundGarden, globalVolume, localVolume;

    //laoding scene
    public GameObject loadingLayer;
    public Slider slider;
    public TextMeshProUGUI progressText;
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

        if (qualityIndex == 0 || qualityIndex == 2)
        {
            terrainGarden.SetActive(true);
            groundGarden.SetActive(false);
            globalVolume.SetActive(true);
            localVolume.SetActive(true);

        }
        else
        {
            groundGarden.SetActive(true);
            terrainGarden.SetActive(false);
            globalVolume.SetActive(false);
            localVolume.SetActive(false);
        }
    }

    IEnumerator GameLoader(int sceneIndex)
    {
        loadingLayer.SetActive(true);
        yield return null;

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progressValue;
            progressText.text = progressValue * 100f + "%";

            yield return null;
        }

        if (operation.isDone)
        {
            loadingLayer.SetActive(false);
        }
    }

    public void ExitGameOver(int sceneIndex)
    {
        StartCoroutine(GameLoader(sceneIndex));
    }

    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(GameLoader(sceneIndex));
    }
}
