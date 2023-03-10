using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetinggsButton : MonoBehaviour
{
    [SerializeField] private GameObject SettingsPanel;
    [SerializeField] private GameObject ConfirmationLobby;
    
    public void OpenSettings()
    {
        SettingsPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseSettings()
    {
        SettingsPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ConfirmationToLobby()
    {
        ConfirmationLobby.SetActive(true);
    }

    public void CloseConfirmation()
    {
        ConfirmationLobby.SetActive(false);
    }
}
