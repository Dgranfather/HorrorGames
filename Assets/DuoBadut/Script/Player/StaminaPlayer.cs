using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaPlayer : MonoBehaviour
{
    public float currentStamina;
    private float maxStamina = 100f;

    public Slider staminaBar;
    public float dValue;
    public float iValue;

    private FirstPersonController theFPC;
    // Start is called before the first frame update
    void Start()
    {
        theFPC = FindObjectOfType<FirstPersonController>();

        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentStamina >= 0 && theFPC._speed > theFPC.MoveSpeed)
        {
            DecreaseEnergy();
        }
        else
        {
            if(currentStamina <= maxStamina)
            IncreaseEnergy();
        }

        staminaBar.value = currentStamina;
    }

    public void DecreaseEnergy()
    {
        if(currentStamina != 0)
        {
            currentStamina -= dValue * Time.deltaTime;
        }
    }

    public void IncreaseEnergy()
    {
        currentStamina += iValue * Time.deltaTime;
    }
}
