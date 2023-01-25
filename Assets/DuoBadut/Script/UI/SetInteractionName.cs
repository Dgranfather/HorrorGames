using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetInteractionName : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI interactionNameTxt;

    public void SetName(string name)
    {
        interactionNameTxt.text = name;
    }
}
