using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WoodenBarrier : MonoBehaviour, IInteractable
{
    public Interact theInteract;
    [SerializeField] private int requiredItemID;
    [SerializeField] private GameObject requiredNotif;
    [SerializeField] private TextMeshProUGUI requiredNotifTxt;

    private SoundsManager soundsManager;

    public void interact()
    {
        if (theInteract.itemID == requiredItemID)
        {
            gameObject.SetActive(false);
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
}
