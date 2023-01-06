using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabable : MonoBehaviour
{
    private Rigidbody rb;
    private Transform grabpoint;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Grab(Transform grabpointTransform)
    {
        grabpoint = grabpointTransform;
        rb.useGravity = false;
    }

    public void Drop()
    {
        grabpoint = null;
        rb.useGravity = true;
    }

    private void FixedUpdate()
    {
        if(grabpoint != null)
        {
            float lerpSpeed = 10f;
            Vector3 newPos = Vector3.Lerp(transform.position, grabpoint.position, Time.deltaTime * lerpSpeed);
            rb.MovePosition(newPos);
        }
    }

}
