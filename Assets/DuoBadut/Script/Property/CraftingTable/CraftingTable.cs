using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingTable : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform itemPos1, itemPos2, outputPos;
    public int idItem1 = 0, idItem2 = 0;

    public Grabable theGrabable, _grabable;
    public GameObject[] craftingOutput;
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
        if (other.tag == "GrabableObj")
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
        if(idItem1 == 1 && idItem2 == 2 || idItem1 == 2 && idItem2 == 1)
        {
            Debug.Log("destroy required items");
            Destroy(theGrabable.gameObject);
            Destroy(_grabable.gameObject);
            idItem1 = 0;
            theGrabable = null;
            idItem2 = 0;
            _grabable = null;
            
            //just this one that need to change if any other item added for crafting
            Instantiate(craftingOutput[0], outputPos.position, outputPos.rotation);
        }
        else
        {
            Debug.Log("wrong combination");
        }
    }
}
