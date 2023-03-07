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

    public void EasyGhost()
    {
        ghostID = theChoosingGhost.ghostID;

        if (ghostID == 0)
        {
            StartCoroutine(GameLoader(1));
        }
        else
        {
            if(isActive == false)
            {
                StartCoroutine(NotifActive());
            }
        }
    }

    public void MediumGhost()
    {
        ghostID = theChoosingGhost.ghostID;

        if (ghostID == 0)
        {
            StartCoroutine(GameLoader(0));
        }
        else
        {
            if (isActive == false)
            {
                StartCoroutine(NotifActive());
            }
        }
    }

    public void ExtremeGhost()
    {
        ghostID = theChoosingGhost.ghostID;

        if (ghostID == 0)
        {
            StartCoroutine(GameLoader(0));
        }
        else
        {
            if (isActive == false)
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
