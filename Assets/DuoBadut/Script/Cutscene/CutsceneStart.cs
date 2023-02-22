using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

//[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(SignalReceiver))]
public class CutsceneStart : Interactable
{
    [SerializeField] private GameObject _cutsceneToPlay;
    public override void Active()
    {
        base.Active();
        _cutsceneToPlay.SetActive(true);
        PlayerControler.Instance.CutsceneCamera.SetActive(true);
        //PlayerControler.Instance.CutscenePlayerCamera.SetActive(true);
        //PlayerControler.Instance.FirstPersonCamera.SetActive(false);
    }

    
   public override void Deactive()
    {
        base.Deactive();
        _cutsceneToPlay.SetActive(false);
        PlayerControler.Instance.CutsceneCamera.SetActive(false);
        //PlayerControler.Instance.CutscenePlayerCamera.SetActive(false);
        //PlayerControler.Instance.FirstPersonCamera.SetActive(true);
    }
}
