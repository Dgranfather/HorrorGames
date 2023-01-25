using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChargingFlashlight : MonoBehaviour, IInteractable
{
    [SerializeField] private int requiredItemID;
    private Interact theInteract;
    [SerializeField] private FlashlightIntensity theFlashlightIntensity;
    private bool onInteraction = false;
    private FirstPersonController theFpsController;
    [SerializeField] private string interactionName;
    [SerializeField] private SetInteractionName theSetInteractionName;
    [SerializeField] private GameObject interactionNameUI;
    // Start is called before the first frame update
    void Start()
    {
        theInteract = FindObjectOfType<Interact>();
        theFpsController = FindObjectOfType<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onInteraction)
        {
            if (theFpsController._speed == 0)
            {
                theFlashlightIntensity.Charging();
            }
            else
            {
                onInteraction = false;
                interactionNameUI.SetActive(false);
            }
        }
    }

    public void interact()
    {
        if (theInteract.itemID == requiredItemID)
        {
            onInteraction = true;
            interactionNameUI.SetActive(true);
            theSetInteractionName.SetName(interactionName);
        }
    }
}
