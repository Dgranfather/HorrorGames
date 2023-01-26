using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerBoxPanel : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject powerPanel;
    [SerializeField] private int requiredItemID;
    public Interact theInteract;

    [SerializeField] private GameObject requiredNotif;
    [SerializeField] private TextMeshProUGUI requiredNotifTxt;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void interact()
    {
        if (theInteract.itemID == requiredItemID)
        {
            powerPanel.SetActive(true);
            gameObject.tag = "Untagged";

            //destroying item
            Destroy(theInteract.theGrabable.gameObject);
            theInteract.setHandNull();
        }
        else
        {
            StartCoroutine(NeedItemNotif());
        }
    }

    IEnumerator NeedItemNotif()
    {
        requiredNotifTxt.text = "You need <color=yellow>Power Panel</color> to interact";
        requiredNotif.SetActive(true);
        yield return new WaitForSeconds(2f);
        requiredNotif.SetActive(false);
    }
}
