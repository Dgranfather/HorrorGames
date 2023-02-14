using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPos1 : MonoBehaviour
{
    [SerializeField] private CraftingTable theCraftingTable;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "GrabableObj")
    //    {

    //    }
    //}

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Grabable")
        {
            theCraftingTable.idItem1 = 0;
            theCraftingTable.theGrabable = null;
        }
    }
}
