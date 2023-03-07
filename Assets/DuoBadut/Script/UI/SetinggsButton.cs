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
    }

    public void CloseSettings()
    {
        SettingsPanel.SetActive(false);
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
