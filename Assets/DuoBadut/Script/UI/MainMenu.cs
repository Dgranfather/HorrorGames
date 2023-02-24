using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject newGamePanel;
    public void PlayBtn()
    {
        newGamePanel.SetActive(true);
    }

    public void CloseNewGame()
    {
        newGamePanel.SetActive(false);
    }

    public void ExitBtn()
    {
        Application.Quit();
    }
}
