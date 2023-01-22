using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiggingHole : MonoBehaviour, IInteractable
{
    public Interact theInteract;
    [SerializeField] private int requiredItemID;
    private SoundsManager soundsManager;
    private ProgressBar theProgressBar;
    [SerializeField] private float maxValue;
    private float currentValue = 0;
    private bool onInteraction = false;
    public GameObject progressBar;
    private FirstPersonController theFpsController;
    [SerializeField] private string interactionName;

    // Start is called before the first frame update
    void Start()
    {
        soundsManager = FindObjectOfType<SoundsManager>();
        theFpsController = FindObjectOfType<FirstPersonController>();
        currentValue = 0;
    }

    // Update is called once per frame
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
                else if(currentValue >= maxValue)
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
        if (theInteract.itemID == requiredItemID)
        {
            if (onInteraction == false)
            {
                progressBar.SetActive(true);
                theProgressBar = FindObjectOfType<ProgressBar>();
                theProgressBar.SetMaxValue(maxValue);
                theProgressBar.SetInteractionName(interactionName);
                soundsManager.PlaySfx(3);
                onInteraction = true;
            }
            else
            {
                Debug.Log("On Interaction");
            }
        }
        else
        {
            Debug.Log("You need this item : " + requiredItemID);
        }
    }
}
