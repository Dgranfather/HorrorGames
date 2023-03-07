using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayGame : MonoBehaviour
{

    public GameObject loadingLayer;
    public Slider slider;
    public TextMeshProUGUI progressText;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    IEnumerator GameLoader(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingLayer.SetActive(true);

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

    public void PlayGameNew(int sceneIndex)
    {
        StartCoroutine(GameLoader(sceneIndex));
    }
}
