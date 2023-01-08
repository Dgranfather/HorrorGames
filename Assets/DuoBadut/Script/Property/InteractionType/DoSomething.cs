using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoSomething : MonoBehaviour, IInteractable
{
    public void interact()
    {
        Debug.Log("Do Something Success");
    }
}
