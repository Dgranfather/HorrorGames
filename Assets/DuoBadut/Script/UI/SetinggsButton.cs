using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetinggsButton : MonoBehaviour
{
    [SerializeField] private GameObject SettingsPanel;
    
    public void OpenSettings()
    {
        SettingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        SettingsPanel.SetActive(false);
    }
}
