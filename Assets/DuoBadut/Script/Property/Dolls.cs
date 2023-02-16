using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dolls : MonoBehaviour
{
    [SerializeField] private GameObject blessedDoll, cursedDoll;
    public bool isBlessed;
    private Grabable theGrabable;
    private Transform grabpoint;
    private Rigidbody rb;
    public bool onGrab = false;
    // Start is called before the first frame update
    void Start()
    {
        theGrabable = GetComponent<Grabable>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isBlessed)
        {
            blessedDoll.SetActive(true);
            cursedDoll.SetActive(false);
            theGrabable.itemID = 4;
        }
        else
        {
            blessedDoll.SetActive(false);
            cursedDoll.SetActive(true);
            theGrabable.itemID = 3;
        }
        
        if(theGrabable.onGrab)
        {
            onGrab = true;
        }
        else
        {
            onGrab = false;
        }
    }

    private void FixedUpdate()
    {
        if (grabpoint != null)
        {
            float lerpSpeed = 10f;
            Vector3 newPos = Vector3.Lerp(transform.position, grabpoint.position, Time.deltaTime * lerpSpeed);
            rb.MovePosition(grabpoint.position);
        }
    }

    public void Grab(Transform grabpointTransform)
    {
        rb.useGravity = false;
        grabpoint = grabpointTransform;
        gameObject.tag = "Untagged";
    }

    public void Drop()
    {
        transform.SetParent(null);
        rb.useGravity = true;
        grabpoint = null;
        gameObject.tag = "Grabable";
    }
}
