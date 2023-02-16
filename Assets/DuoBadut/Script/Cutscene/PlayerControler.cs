using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public static PlayerControler Instance;
    public GameObject FirstPersonCamera;
    public GameObject CutsceneCamera;
    public GameObject CutscenePlayerCamera;

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
