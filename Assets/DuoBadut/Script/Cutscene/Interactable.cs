using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] private CanvasGroup _interactableUI;
    private bool _playerSign;

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            _interactableUI.gameObject.SetActive(true);
            LeanTween.cancel(_interactableUI.gameObject);
            LeanTween.alphaCanvas(_interactableUI, 1, 1);
            _playerSign = true;
        }
    }

    // Update is called once per frame
   private void Update()
    {
        if(_playerSign && Input.GetKeyUp(KeyCode.E))
        {
            Active();
        }
    }

    public virtual void Active()
    {
        _interactableUI.gameObject.SetActive(false);
    }

    public virtual void Deactive()
    {

    }

    private void OnTriggerExit(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            _playerSign = false;
            LeanTween.alphaCanvas(_interactableUI, 0, 1)
                .setOnComplete(UIHide);
        }
    }

    private void UIHide()
    {

    }
}
