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

    private int ghostID;
    [SerializeField] private ChoosingGhost theChoosingGhost;
    [SerializeField] private GameObject notif;
    private bool isActive = false;

    private void Start()
    {
        isActive = false;
        ghostID = 0;
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

    public void PlayNewGame(int levelIndex)
    {
        ghostID = theChoosingGhost.ghostID;

        if (ghostID == 0)
        {
            StartCoroutine(GameLoader(levelIndex));
        }
        else
        {
            if(isActive == false)
            {
                StartCoroutine(NotifActive());
            }
        }
    }

    IEnumerator NotifActive()
    {
        isActive = true;
        notif.SetActive(true);
        yield return new WaitForSeconds(2f);
        notif.SetActive(false);
        isActive = false;
    }
}
