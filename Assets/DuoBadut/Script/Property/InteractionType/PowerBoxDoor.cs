using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerBoxDoor : MonoBehaviour, IInteractable
{
    public Interact theInteract;
    [SerializeField] private int requiredItemID;
    private SoundsManager soundsManager;

    [SerializeField] private GameObject requiredNotif;
    [SerializeField] private TextMeshProUGUI requiredNotifTxt;
    // Start is called before the first frame update
    void Start()
    {
        soundsManager = FindObjectOfType<SoundsManager>();
    }

    public void interact()
    {
        if (theInteract.itemID == requiredItemID)
        {
            StartCoroutine(openingCase());
        }
        else
        {
            StartCoroutine(NeedItemNotif());
        }
    }

    IEnumerator openingCase()
    {
        soundsManager.PlaySfx(2);
        yield return new WaitForSeconds(.5f);
        gameObject.SetActive(false);
    }

    IEnumerator NeedItemNotif()
    {
        requiredNotifTxt.text = "You need <color=yellow>Ritual Box Key</color> to open this";
        requiredNotif.SetActive(true);
        yield return new WaitForSeconds(2f);
        requiredNotif.SetActive(false);
    }
}
