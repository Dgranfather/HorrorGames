using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitualCircle : MonoBehaviour
{
    [SerializeField] private GameObject demonSignEff;
    [SerializeField] private PowerBoxPanel powerBoxPanel1, powerBoxPanel2, powerBoxPanel3,
        powerBoxPanel4, powerBoxPanel5, powerBoxPanel6;
    private int panelCount = 0;

    // Update is called once per frame
    void Update()
    {
        panelCount = powerBoxPanel1.PanelOn + powerBoxPanel2.PanelOn + powerBoxPanel3.PanelOn + powerBoxPanel4.PanelOn + powerBoxPanel5.PanelOn + powerBoxPanel6.PanelOn;

        if(panelCount == 6)
        {
            demonSignEff.SetActive(true);
            gameObject.tag = "RitualActive";
        }
    }
}
