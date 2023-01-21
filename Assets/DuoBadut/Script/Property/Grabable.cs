using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabable : MonoBehaviour
{
    private Rigidbody rb;
    private Transform grabpoint;
    public int itemID;
    public string nameItem;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Grab(Transform grabpointTransform)
    {
        StartCoroutine(moveitemPos(grabpointTransform));
        rb.useGravity = false;
        rb.detectCollisions = false;
    }

    public void Drop()
    {
        rb.detectCollisions = true;
        transform.SetParent(null);
        grabpoint = null;
        rb.useGravity = true;
    }

    //private void FixedUpdate()
    //{
    //    if (grabpoint != null)
    //    {
    //        float lerpSpeed = 10f;
    //        Vector3 newPos = Vector3.Lerp(transform.position, grabpoint.position, Time.deltaTime * lerpSpeed);
    //        rb.MovePosition(grabpoint.position);
    //    }
    //}

    IEnumerator moveitemPos(Transform grabpointTransform)
    {
        yield return new WaitForSeconds(0.6f);
        transform.SetParent(grabpointTransform);
        transform.localPosition = new Vector3(0f, 0f, 0f);
        transform.localRotation = Quaternion.identity;
        grabpoint = grabpointTransform;
    }
}
