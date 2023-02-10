using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolls : MonoBehaviour
{
    [SerializeField] private GameObject blessedDoll, cursedDoll;
    public bool isBlessed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isBlessed)
        {
            blessedDoll.SetActive(true);
            cursedDoll.SetActive(false);
        }
        else
        {
            blessedDoll.SetActive(false);
            cursedDoll.SetActive(true);
        }
    }
}
