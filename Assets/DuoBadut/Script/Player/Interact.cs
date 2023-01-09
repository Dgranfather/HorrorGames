using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    
    [SerializeField] private Transform playerCamTransform;
    [SerializeField] private Transform grabpointTransform;
    [SerializeField] private LayerMask GrabableObj;
    [SerializeField] private float rayDistance;
    [SerializeField] private GameObject interactSign;
    [SerializeField] private GameObject grabSign;
    [SerializeField] private GameObject interactBtn;
    [SerializeField] private LayerMask InteractObj;

    private Grabable theGrabable;
    private Interactable theInteractable;
    private IInteractable _iinteractable;
    private int IDhandItem;

    private void Start()
    {
        PlayerPrefs.SetInt("IDhandItem", 0);
    }

    private void Update()
    {
        interactionRay();
    }

    void interactionRay()
    {
        if (Physics.Raycast(playerCamTransform.position, playerCamTransform.forward, rayDistance, GrabableObj))
        {
            grabSign.SetActive(true);
        }
        else
        {
            grabSign.SetActive(false);
        }

        if (Physics.Raycast(playerCamTransform.position, playerCamTransform.forward, rayDistance, InteractObj))
        {
            interactSign.SetActive(true);
            interactBtn.SetActive(true);
        }
        else
        {
            interactSign.SetActive(false);
            interactBtn.SetActive(false);
        }
    }

    public void PickupAndDrop()
    {
        if (theGrabable == null)
        {
            if (Physics.Raycast(playerCamTransform.position, playerCamTransform.forward, out RaycastHit rayHit, rayDistance, GrabableObj))
            {
                if (rayHit.transform.TryGetComponent(out theGrabable))
                {
                    theGrabable.Grab(grabpointTransform);
                }
            }
        }
        else
        {
            theGrabable.Drop();
            theGrabable = null;
        }
    }

    public void DoInteraction()
    {
        if (Physics.Raycast(playerCamTransform.position, playerCamTransform.forward, out RaycastHit rayHit, rayDistance, InteractObj))
        {
            if (rayHit.transform.TryGetComponent(out _iinteractable))
            {
                _iinteractable.interact();
            }
        }
    }

}
