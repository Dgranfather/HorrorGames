using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBoxDoor : MonoBehaviour, IInteractable
{
    public Interact theInteract;
    [SerializeField] private int requiredItemID;
    private SoundsManager soundsManager;

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
            Debug.Log("You need this item : " + requiredItemID);
        }
    }

    IEnumerator openingCase()
    {
        soundsManager.PlaySfx(2);
        yield return new WaitForSeconds(.5f);
        gameObject.SetActive(false);
    }
}
