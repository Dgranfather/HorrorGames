using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressBar : MonoBehaviour
{
    public Image fill;
    public Slider slider;
    public Gradient gradient;
    [SerializeField] private TextMeshProUGUI interactionNameTxt;

    public void SetMaxValue(float maxValue)
    {
        slider.maxValue = maxValue;
        //slider.value = maxValue;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetValue(float value)
    {
        slider.value = value;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetInteractionName(string name)
    {
        interactionNameTxt.text = name;
    }
}
