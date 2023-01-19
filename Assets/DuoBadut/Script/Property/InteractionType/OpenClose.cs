using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClose : MonoBehaviour, IInteractable
{
    private Animator openandclose;
    private bool open;

    private SoundsManager soundsManager;

    void Start()
    {
        open = false;
        openandclose = GetComponent<Animator>();
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
        openandclose.Play("Opening");
        soundsManager.PlaySfx(0);
        open = true;
        yield return new WaitForSeconds(.5f);
    }

    IEnumerator closing()
    {
        //print("you are closing the door");
        openandclose.Play("Closing");
        soundsManager.PlaySfx(1);
        open = false;
        yield return new WaitForSeconds(.5f);
    }
}
