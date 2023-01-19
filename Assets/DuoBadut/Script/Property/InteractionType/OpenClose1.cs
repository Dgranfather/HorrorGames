using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpenClose1 : MonoBehaviour, IInteractable
{
    private Animator openandclose1;
    private bool open;

    private SoundsManager soundsManager;

    void Start()
    {
        open = false;
        openandclose1 = GetComponent<Animator>();
        soundsManager = FindObjectOfType<SoundsManager>();
    }

    public void interact()
    {
        if (open == false)
        {
            StartCoroutine(opening());
        }
        else
        {
            if (open == true)
            {
                StartCoroutine(closing());
            }
        }
    }

    IEnumerator opening()
    {
        //print("you are opening the door");
        openandclose1.Play("Opening 1");
        soundsManager.PlaySfx(0);
        open = true;
        yield return new WaitForSeconds(.5f);
    }

    IEnumerator closing()
    {
        //print("you are closing the door");
        openandclose1.Play("Closing 1");
        soundsManager.PlaySfx(1);
        open = false;
        yield return new WaitForSeconds(.5f);
    }
}
