using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Story : MonoBehaviour
{
    public Text textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public float delayBeforeStart = 1f;
    public float delayStart = 7.35f;

    //public GameObject loadingLayer;
    // public Slider slider;
    //public Text progressText;


    //public Animator transition;
    //public float transisitionTime = 1f;

    //public GameObject continueButton;

    private bool isNext = false;
    void Start()
    {
        StartCoroutine(StartDelay());
        //StartCoroutine(Type());

    }

    void Update()
    {
        if (textDisplay.text != sentences[index])
        {
            
            //NextSentences();
            //continueButton.SetActive(false);
        }
        else if (textDisplay.text == sentences[index])
        {

            //continueButton.SetActive(true);
            if(!isNext)
            StartCoroutine(Wait());
            //NextSentences();
           
            
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    IEnumerator Wait()
    {
        isNext = true;
        yield return new WaitForSeconds(delayBeforeStart);
        NextSentences();
        isNext = false;
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(delayStart);
        StartCoroutine(Type());
    }

    public void NextSentences()
    {
        
        //continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            //StartCoroutine(Wait());
            //LoadingLevel();
            //continueButton.SetActive(false);
        }
    }


    //public void LoadingLevel()
    //{
    //    StartCoroutine(loadingScene(1));
    //}

    //IEnumerator LoadLevel(int levelIndex)
    //{
    //    transition.SetTrigger("Start");
    //    yield return new WaitForSeconds(transisitionTime);
    //    SceneManager.LoadScene(levelIndex);
    //}

    //IEnumerator loadingScene(int sceneIndex)
    //{
    //    AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

    //    loadingLayer.SetActive(true);

    //    while (!operation.isDone)
    //    {
    //        float progressValue = Mathf.Clamp01(operation.progress / 0.9f);

    //        slider.value = progressValue;
    //        progressText.text = progressValue * 100f + "%";

    //        yield return null;
    //    }

    //    if (operation.isDone)
    //    {
    //        loadingLayer.SetActive(false);
    //    }
    //}
}
