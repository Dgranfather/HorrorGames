using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HoldingItemName : MonoBehaviour
{
    [SerializeField] private Interact theInteract;
    [SerializeField] private GameObject holdingItemNameTxt;
    [SerializeField] private TextMeshProUGUI itemNameText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(theInteract.isHolding == true)
        {
            holdingItemNameTxt.SetActive(true);
            itemNameText.text = theInteract.theGrabable.nameItem;
        }
        else
        {
            holdingItemNameTxt.SetActive(false);
        }
    }
}
