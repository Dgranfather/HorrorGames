using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerOpenClose : MonoBehaviour, IInteractable
{
    private Animator pull_01;
    private bool open;
    private SoundsManager soundsManager;

    void Start()
    {
        open = false;
        pull_01 = GetComponent<Animator>();
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
        pull_01.Play("openpull_01");
        soundsManager.PlaySfx(0);
        open = true;
        yield return new WaitForSeconds(.5f);
    }

    IEnumerator closing()
    {
        //print("you are closing the door");
        pull_01.Play("closepush_01");
        soundsManager.PlaySfx(1);
        open = false;
        yield return new WaitForSeconds(.5f);
    }
}
