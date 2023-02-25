using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookExorcism : MonoBehaviour
{
    [SerializeField] private GameObject bookPanel;
    [SerializeField] private AutoFlip theAutoFlip;

    public void OpenBookPanel()
    {
        bookPanel.SetActive(true);
    }

    public void ClosBookPanel()
    {
        if (theAutoFlip.isFlipping == false)
        {
            bookPanel.SetActive(false);
        }
    }
}
