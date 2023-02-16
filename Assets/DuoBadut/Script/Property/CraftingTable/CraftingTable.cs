using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CraftingTable : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform itemPos1, itemPos2, outputPos;
    public int idItem1 = 0, idItem2 = 0;

    public Grabable theGrabable, _grabable;
    public GameObject[] craftingOutput;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Grabable")
        {
            if (theGrabable == null)
            {
                if(other.TryGetComponent(out theGrabable))
                {
                    theGrabable.transform.position = itemPos1.position;
                    idItem1 = theGrabable.itemID;
                }
            }
            else if(theGrabable != null && _grabable == null)
            {
                if (other.TryGetComponent(out _grabable))
                {
                    _grabable.transform.position = itemPos2.position;
                    idItem2 = _grabable.itemID;
                }
            }
        }
    }

    public void interact()
    {
        if(idItem1 == 3 && idItem2 == 14 || idItem1 == 14 && idItem2 == 3)
        {
            //blessed doll
            //Debug.Log("destroy required items");
            Destroy(theGrabable.gameObject);
            Destroy(_grabable.gameObject);
            idItem1 = 0;
            theGrabable = null;
            idItem2 = 0;
            _grabable = null;
            
            //just this one that need to change if any other item added for crafting
            Instantiate(craftingOutput[0], outputPos.position, outputPos.rotation);
        }
        else if (idItem1 == 8 && idItem2 == 9 || idItem1 == 9 && idItem2 == 8)
        {
            //crowbar
            //Debug.Log("destroy required items");
            Destroy(theGrabable.gameObject);
            Destroy(_grabable.gameObject);
            idItem1 = 0;
            theGrabable = null;
            idItem2 = 0;
            _grabable = null;

            Instantiate(craftingOutput[1], outputPos.position, outputPos.rotation);
        }
        else if (idItem1 == 11 && idItem2 == 12 || idItem1 == 12 && idItem2 == 11)
        {
            //spade
            //Debug.Log("destroy required items");
            Destroy(theGrabable.gameObject);
            Destroy(_grabable.gameObject);
            idItem1 = 0;
            theGrabable = null;
            idItem2 = 0;
            _grabable = null;

            Instantiate(craftingOutput[2], outputPos.position, outputPos.rotation);
        }
        else if(idItem1 == 0 && idItem2 == 0)
        {
            StartCoroutine(NeedItemNotif());
        }
        else
        {
            StartCoroutine(WrongCombination());
        }
    }

    IEnumerator NeedItemNotif()
    {
        requiredNotifTxt.text = "Put the necessary items above the table";
        requiredNotif.SetActive(true);
        yield return new WaitForSeconds(2f);
        requiredNotif.SetActive(false);
    }

    IEnumerator WrongCombination()
    {
        requiredNotifTxt.text = "Wrong item combination";
        requiredNotif.SetActive(true);
        yield return new WaitForSeconds(2f);
        requiredNotif.SetActive(false);
    }
}
