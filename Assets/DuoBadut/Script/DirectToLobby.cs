using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DirectToLobby : MonoBehaviour
{
    public GameObject loadingLayer;
    public Slider slider;
    public TextMeshProUGUI progressText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameLoader(0));
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
}
