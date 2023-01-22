using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBoxPanel : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject powerPanel;
    [SerializeField] private int requiredItemID;
    public Interact theInteract;

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
        }
    }
}
