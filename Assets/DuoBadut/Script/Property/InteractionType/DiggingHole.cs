using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiggingHole : MonoBehaviour, IInteractable
{
    public Interact theInteract;
    [SerializeField] private int requiredItemID;

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
            Destroy(gameObject, 1f);
        }
        else
        {
            Debug.Log("You need this item : " + requiredItemID);
        }
    }
}
