using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookExorcism : MonoBehaviour
{
    [SerializeField] private GameObject bookPanel;

    public void OpenBookPanel()
    {
        bookPanel.SetActive(true);
    }

    public void ClosBookPanel()
    {
        bookPanel.SetActive(false);
    }
}
