using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    private SoundsManager soundsManager;

    [SerializeField] private GameObject requiredNotif;
    [SerializeField] private TextMeshProUGUI requiredNotifTxt;

    void Start()
    {
        open = false;
        openandclose1 = GetComponent<Animator>();
        soundsManager = FindObjectOfType<SoundsManager>();
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
                soundsManager.PlaySfx(2);
                doorHandle.Rotate(0, 0, 90);

                //if want to destroy the required item
                //Destroy(theInteract.theGrabable.gameObject);
                //theInteract.setHandNull();
            }
            else
            {
                StartCoroutine(NeedItemNotif());
            }
        }

        
    }

    IEnumerator opening()
    {
        //print("you are opening the door");
        openandclose1.Play("Opening 1");
        soundsManager.PlaySfx(0);
        open = true;
        yield return new WaitForSeconds(.5f);
    }

    IEnumerator closing()
    {
        //print("you are closing the door");
        openandclose1.Play("Closing 1");
        soundsManager.PlaySfx(1);
        open = false;
        yield return new WaitForSeconds(.5f);
    }

    IEnumerator NeedItemNotif()
    {
        requiredNotifTxt.text = "You need <color=yellow>Ruang Pribadi Key</color> to open this";
        requiredNotif.SetActive(true);
        yield return new WaitForSeconds(2f);
        requiredNotif.SetActive(false);
    }
}
