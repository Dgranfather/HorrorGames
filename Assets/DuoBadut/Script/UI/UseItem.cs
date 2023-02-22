using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    [SerializeField] private GameObject useBtn;
    private Interact theInteract;
    private StaminaPlayer theStaminaPlayer;
    // Start is called before the first frame update
    void Start()
    {
        theInteract = FindObjectOfType<Interact>();
        theStaminaPlayer = FindObjectOfType<StaminaPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(theInteract.itemID == 14)
        {
            useBtn.SetActive(true);
        }
        else
        {
            useBtn.SetActive(false);
        }
    }

    public void UsingItem()
    {
        if (theInteract.itemID == 14)
        {
            Destroy(theInteract.theGrabable.gameObject);
            theInteract.setHandNull();

            if(theStaminaPlayer.currentStamina < theStaminaPlayer.maxStamina)
            {
                theStaminaPlayer.currentStamina += theStaminaPlayer.maxStamina / 3.2f;
            }
            
            if(theStaminaPlayer.currentStamina > theStaminaPlayer.maxStamina)
            {
                theStaminaPlayer.currentStamina = theStaminaPlayer.maxStamina;
            }
        }
    }
}
