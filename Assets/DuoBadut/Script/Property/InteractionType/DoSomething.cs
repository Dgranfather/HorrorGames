using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoSomething : MonoBehaviour, IInteractable
{
    public Interact theInteract;
    public void interact()
    {
        if (theInteract.itemID == 1)
        {
            Debug.Log("Do Something Success");
            //Destroy(gameObject);
        }
        else
        {
            Debug.Log("You need item 1");
        }
    }
}
