using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPos2 : MonoBehaviour
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
        if (other.tag == "GrabableObj")
        {
            theCraftingTable.idItem2 = 0;
            theCraftingTable._grabable = null;
        }
    }
}
