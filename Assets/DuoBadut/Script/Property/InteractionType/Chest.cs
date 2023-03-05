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
    private Collider theCollider;

    private Enemy theEnemy;
    public int chestNumber;
    // Start is called before the first frame update
    void Start()
    {
        soundsManager = FindObjectOfType<SoundsManager>();
        animator = GetComponent<Animator>();
        theCollider = GetComponent<Collider>();
        theEnemy = FindObjectOfType<Enemy>();
    }

    public void interact()
    {
        if (theInteract.itemID == requiredItemID)
        {
            animator.SetBool("isOpen", true);
            soundsManager.PlaySfx(6);
            theCollider.enabled = false;
            if(isTrap == true)
            {
                if (chestNumber == 1)
                {
                    theEnemy.warpOnChest();
                }
                else if(chestNumber == 3)
                {
                    theEnemy.warpOnChest2();
                }
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
