using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class LockedDoor : MonoBehaviour, IInteractable
{
    private Animator openandclose1;
    private bool open;
    [SerializeField] private int requiredItemID;
    public Interact theInteract;
    private bool isLocked = true;
    [SerializeField] Transform doorHandle;
    public AudioSource unlockSfx;
    public AudioSource dooropenSfx;
    public AudioSource doorcloseSfx;

    void Start()
    {
        open = false;
        openandclose1 = GetComponent<Animator>();
    }

    public void interact()
    {
        if (isLocked == false)
        {
            if (open == false)
            {
                StartCoroutine(opening());
            }
            else
            {
                if (open == true)
                {
                    StartCoroutine(closing());
                }
            }
        }
        else
        {
            if (theInteract.itemID == requiredItemID)
            {
                isLocked = false;
                unlockSfx.Play();
                doorHandle.Rotate(0, 0, 90);

                //if want to destroy the required item
                //Destroy(theInteract.theGrabable.gameObject);
                //theInteract.setHandNull();
            }
            else
            {
                Debug.Log("You need this item : " + requiredItemID);
            }
        }

        
    }

    IEnumerator opening()
    {
        //print("you are opening the door");
        openandclose1.Play("Opening 1");
        dooropenSfx.Play();
        open = true;
        yield return new WaitForSeconds(.5f);
    }

    IEnumerator closing()
    {
        //print("you are closing the door");
        openandclose1.Play("Closing 1");
        doorcloseSfx.Play();
        open = false;
        yield return new WaitForSeconds(.5f);
    }
}
