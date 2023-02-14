using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class Interact : MonoBehaviour
{
    
    [SerializeField] private Transform playerCamTransform;
    [SerializeField] private Transform grabpointPowerPanel, grabpointCharger, grabpointDoll, 
    grabpointPowerBoxKey, grabpointCrowbarHead, grabpointCrowbarBack, grabpointCrowbar, 
        grabpointSpadeHead, grabpointSpadeHolder, grabpointSpade, grabpointHolyWater;
    [SerializeField] private LayerMask everythingLayer;
    [SerializeField] private float rayDistance;
    [SerializeField] private GameObject interactSign;
    [SerializeField] private GameObject grabSign;
    [SerializeField] private GameObject interactBtn;
    //[SerializeField] private LayerMask InteractObj;
    public int itemID;

    public Grabable theGrabable;
    private Grabable _grabable;

    private IInteractable _iinteractable;
    private bool isGrabbing = false;
    private bool isHolding = false;

    private Animator anim;
    private Rig theRig;
    private float targetWeight;
    [SerializeField] private TextMeshProUGUI itemName;

    private void Start()
    {
        PlayerPrefs.SetInt("IDhandItem", 0);
        anim = GetComponentInChildren<Animator>();
        theRig = GetComponentInChildren<Rig>();
        targetWeight = 0;
    }

    private void FixedUpdate()
    {
        interactionRay();

        theRig.weight = Mathf.Lerp(theRig.weight, targetWeight, Time.deltaTime * 10f);
    }

    void interactionRay()
    {
        if (Physics.Raycast(playerCamTransform.position, playerCamTransform.forward, out RaycastHit rayHit, rayDistance, everythingLayer))
        {
            if (rayHit.collider.gameObject.tag == "Grabable")
            {
                grabSign.SetActive(true);
                if (rayHit.transform.TryGetComponent(out _grabable))
                {
                    itemName.enabled = true;
                    itemName.text = _grabable.nameItem;
                }
            }
            else
            {
                grabSign.SetActive(false);
                itemName.enabled = false;
            }

            if (rayHit.collider.gameObject.tag == "Interactable")
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
        else
        {
            grabSign.SetActive(false);
            itemName.enabled = false;
            interactSign.SetActive(false);
            interactBtn.SetActive(false);
        }
    }

    public void PickupAndDrop()
    {
        if (theGrabable == null)
        {
            if (Physics.Raycast(playerCamTransform.position, playerCamTransform.forward, out RaycastHit rayHit, rayDistance, everythingLayer))
            {
                if (rayHit.collider.gameObject.tag == "Grabable")
                {
                    if (rayHit.transform.TryGetComponent(out theGrabable))
                    {
                        if (isHolding == false)
                        {
                            itemID = theGrabable.itemID;
                            isHolding = true;

                            if (theGrabable.itemID == 1)
                            {
                                theGrabable.Grab(grabpointPowerPanel);
                            }
                            else if(theGrabable.itemID == 2)
                            {
                                theGrabable.Grab(grabpointCharger);
                            }
                            else if(theGrabable.itemID == 3 || theGrabable.itemID == 4)
                            {
                                theGrabable.Grab(grabpointDoll);
                            }
                            else if (theGrabable.itemID == 5 || theGrabable.itemID == 6 || theGrabable.itemID == 7)
                            {
                                theGrabable.Grab(grabpointPowerBoxKey);
                            }
                            else if (theGrabable.itemID == 8)
                            {
                                theGrabable.Grab(grabpointCrowbarHead);
                            }
                            else if (theGrabable.itemID == 9)
                            {
                                theGrabable.Grab(grabpointCrowbarBack);
                            }
                            else if (theGrabable.itemID == 10)
                            {
                                theGrabable.Grab(grabpointCrowbar);
                            }
                            else if (theGrabable.itemID == 11)
                            {
                                theGrabable.Grab(grabpointSpadeHolder);
                            }
                            else if (theGrabable.itemID == 12)
                            {
                                theGrabable.Grab(grabpointSpadeHead);
                            }
                            else if (theGrabable.itemID == 13)
                            {
                                theGrabable.Grab(grabpointSpade);
                            }
                            else if (theGrabable.itemID == 14)
                            {
                                theGrabable.Grab(grabpointHolyWater);
                            }
                            StartCoroutine(Pickingup());
                        }
                    }
                }
            }
        }
        else if(isHolding == true && isGrabbing == false)
        {
            theGrabable.Drop();
            theGrabable = null;
            targetWeight = 0;
            itemID = 0;
            isHolding = false;  
        }
    }

    public void DoInteraction()
    {
        if (Physics.Raycast(playerCamTransform.position, playerCamTransform.forward, out RaycastHit rayHit, rayDistance, everythingLayer))
        {
            if (rayHit.collider.gameObject.tag == "Interactable")
            {
                if (rayHit.transform.TryGetComponent(out _iinteractable))
                {
                    _iinteractable.interact();
                }
            }
        }
    }

    IEnumerator Pickingup()
    {
        isGrabbing = true;
        anim.Play("pickup");
        yield return new WaitForSeconds(1.2f);
        targetWeight = 1f;
        isGrabbing = false;
    }    

    public void setHandNull()
    {
        theGrabable = null;
        targetWeight = 0;
        itemID = 0;
        isHolding = false;
    }
}
