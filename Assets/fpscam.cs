using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fpscam : MonoBehaviour
{
    // Start is called before the first frame update
    public float mousesensi = 100f;
    public Transform pbody;
    float xrotate = 0f;
    public static bool mulai = true;
  
    void Awake()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        if (mulai)
        {
            //
          
       
           float mousex = SimpleInput.GetAxis("Look X") * mousesensi * Time.deltaTime;
           float mousey = SimpleInput.GetAxis("Look Y") * mousesensi * Time.deltaTime;

            xrotate -= mousey;
            xrotate = Mathf.Clamp(xrotate, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xrotate, 0f, 0f);
            pbody.Rotate(Vector3.up * mousex);

        }
    }

   
}
