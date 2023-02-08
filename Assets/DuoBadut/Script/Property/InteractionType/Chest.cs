using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    public Interact theInteract;
    [SerializeField] private int requiredItemID;
    [SerializeField] private GameObject requiredNotif;
    [SerializeField] private TextMeshProUGUI requiredNotifTxt;

    private SoundsManager soundsManager;
    private Animator animator;

    [SerializeField] private bool isTrap;
    [SerializeField] private GameObject ghost;

    private Collider theCollider;
    [SerializeField] private Transform ghostPos;
    // Start is called before the first frame update
    void Start()
    {
        soundsManager = FindObjectOfType<SoundsManager>();
        animator = GetComponent<Animator>();
        theCollider = GetComponent<Collider>();
    }

    public void interact()
    {
        if (theInteract.itemID == requiredItemID)
        {
            animator.SetBool("isOpen", true);
            theCollider.enabled = false;
            if(isTrap == true)
            {
                ghost.transform.position = ghostPos.position;
                ghost.transform.rotation = Quaternion.identity;
            }
        }
        else
        {
            StartCoroutine(NeedItemNotif());
        }
    }

    IEnumerator NeedItemNotif()
    {
        requiredNotifTxt.text = "You need <color=yellow>Chest Key</color> to open it";
        requiredNotif.SetActive(true);
        yield return new WaitForSeconds(2f);
        requiredNotif.SetActive(false);
    }
}
