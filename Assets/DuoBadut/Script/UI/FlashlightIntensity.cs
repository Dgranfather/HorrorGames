using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashlightIntensity : MonoBehaviour
{
    //intensity settings
    [SerializeField] private Slider flashlightSlider;
    [SerializeField] private Light flashlight;
    [SerializeField] private float maxIntensity;

    //battery settings
    [SerializeField] private Slider baterySlider;
    [SerializeField] private float dValue, iValue;
    [SerializeField] private float maxBatery;
    private float currentBatery;
    [SerializeField] private Image fill;
    [SerializeField] private Gradient gradient;
    private void Start()
    {
        flashlightSlider.maxValue = maxIntensity;
        flashlightSlider.value = 0;

        currentBatery = maxBatery;

        baterySlider.maxValue = maxBatery;
        baterySlider.value = currentBatery;
        fill.color = gradient.Evaluate(1f);
    }

    private void Update()
    {
        flashlight.intensity = flashlightSlider.value;

        if(flashlight.intensity > 0)
        {
            if(currentBatery > 0)
            {
                currentBatery -= dValue * Time.deltaTime;
                baterySlider.value = currentBatery;
                fill.color = gradient.Evaluate(baterySlider.normalizedValue);
            }
            else
            {
                flashlight.intensity = 0;
            }
        }
    }

    public void Charging()
    {
        if (currentBatery < maxBatery)
        {
            currentBatery += iValue * Time.deltaTime;
            baterySlider.value = currentBatery;
            fill.color = gradient.Evaluate(baterySlider.normalizedValue);
        }
    }

}
