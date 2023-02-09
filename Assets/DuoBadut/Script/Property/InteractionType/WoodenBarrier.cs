using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using StarterAssets;
using UnityEngine.UIElements;

public class WoodenBarrier : MonoBehaviour, IInteractable
{
    public Interact theInteract;
    [SerializeField] private int requiredItemID;
    [SerializeField] private GameObject requiredNotif;
    [SerializeField] private TextMeshProUGUI requiredNotifTxt;
    private bool onInteraction = false;
    private ProgressBar theProgressBar;
    [SerializeField] private float maxValue;
    private float currentValue = 0;
    public GameObject progressBar;
    private FirstPersonController theFpsController;
    [SerializeField] private string interactionName;

    private SoundsManager soundsManager;

    void Start()
    {
        soundsManager = FindObjectOfType<SoundsManager>();
        theFpsController = FindObjectOfType<FirstPersonController>();
        currentValue = 0;
    }

    void Update()
    {
        if (onInteraction)
        {
            if (theFpsController._speed == 0)
            {
                if (currentValue < maxValue)
                {
                    theProgressBar.SetValue(currentValue);
                    currentValue += Time.deltaTime;
                }
                else if (currentValue >= maxValue)
                {
                    onInteraction = false;
                    progressBar.SetActive(false);
                    Destroy(gameObject);
                }
            }
            else
            {
                onInteraction = false;
                currentValue = 0;
                progressBar.SetActive(false);
                soundsManager.StopSfx();
            }
        }
    }

    public void interact()
    {
        //if (theInteract.itemID == requiredItemID)
        //{
        //    if (onInteraction == false)
        //    {
        //        StartCoroutine(RemovingPlanks());
        //    }
        //}
        //else
        //{
        //    StartCoroutine(NeedItemNotif());
        //}

        if (theInteract.itemID == requiredItemID)
        {
            if (onInteraction == false)
            {
                progressBar.SetActive(true);
                theProgressBar = FindObjectOfType<ProgressBar>();
                theProgressBar.SetMaxValue(maxValue);
                theProgressBar.SetInteractionName(interactionName);
                soundsManager.PlaySfx(5);
                onInteraction = true;
            }
            else
            {
                Debug.Log("On Interaction");
            }
        }
        else
        {
            StartCoroutine(NeedItemNotif());
        }
    }
    IEnumerator NeedItemNotif()
    {
        requiredNotifTxt.text = "You need <color=yellow>Crowbar</color> to destroy it";
        requiredNotif.SetActive(true);
        yield return new WaitForSeconds(2f);
        requiredNotif.SetActive(false);
    }

    IEnumerator RemovingPlanks()
    {
        onInteraction = true;
        soundsManager.PlaySfx(5);
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
        onInteraction = false;
    }
}
