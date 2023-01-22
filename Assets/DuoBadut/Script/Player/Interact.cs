using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations.Rigging;

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

    private void Update()
    {
        interactionRay();

        theRig.weight = Mathf.Lerp(theRig.weight, targetWeight, Time.deltaTime * 10f);
    }

    void interactionRay()
    {
        if (Physics.Raycast(playerCamTransform.position, playerCamTransform.forward, out RaycastHit rayHit, rayDistance, GrabableObj))
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
                    if (isHolding == false)
                    {
                        itemID = theGrabable.itemID;
                        isHolding = true;
                        theGrabable.Grab(grabpointTransform);
                        StartCoroutine(Pickingup());
                    }
                }
                else
                {
                    print("something blocking");
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
        if (Physics.Raycast(playerCamTransform.position, playerCamTransform.forward, out RaycastHit rayHit, rayDistance, InteractObj))
        {
            if (rayHit.transform.TryGetComponent(out _iinteractable))
            {
                _iinteractable.interact();
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
