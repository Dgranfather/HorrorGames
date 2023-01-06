using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDrop : MonoBehaviour
{
    [SerializeField] private Transform playerCamTransform;
    [SerializeField] private Transform grabpointTransform;
    [SerializeField] private LayerMask GrabableObj;

    private Grabable theGrabable;

    public void PickupAndDrop()
    {
        if(theGrabable == null)
        {
            float rayDistance = 2f;
            if(Physics.Raycast(playerCamTransform.position, playerCamTransform.forward, out RaycastHit rayHit, rayDistance, GrabableObj))
            {
                if(rayHit.transform.TryGetComponent(out theGrabable))
                {
                    theGrabable.Grab(grabpointTransform);
                }
            }
        }
        else
        {
            theGrabable.Drop();
            theGrabable = null;
        }
    }

}
