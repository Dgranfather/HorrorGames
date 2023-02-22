using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

[RequireComponent(typeof(SignalReceiver))]
public class CutSceneTrigger : Interactable
{
    [SerializeField] private GameObject _cutsceneToPlay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("trigger cut scene");
            Active();
        }
    }

    public override void Active()
    {
        base.Active();
        _cutsceneToPlay.SetActive(true);
        PlayerControler.Instance.CutsceneCamera.SetActive(true);
        //PlayerControler.Instance.CutscenePlayerCamera.SetActive(true);
        PlayerControler.Instance.FirstPersonCamera.SetActive(false);
    }
}
