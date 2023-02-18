using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class CameraUpDown : MonoBehaviour
{
    public float amplitude;
    public float frequency;
    private float currentY;
    private float startY;

    private FirstPersonController theFPC;
    // Start is called before the first frame update
    void Start()
    {
        theFPC = FindObjectOfType<FirstPersonController>();
        startY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (theFPC._speed > 0)
        {
            if (theFPC._speed <= 4)
            {
                amplitude = 0.08f;
                frequency = 6f;
                MovingUpandDown();
            }
            else
            {
                amplitude = 0.1f;
                frequency = 9f;
                MovingUpandDown();
            }
        }
    }

    private void MovingUpandDown()
    {
        //moving up and down
        currentY = startY + Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(transform.position.x, currentY, transform.position.z);
    }
}
