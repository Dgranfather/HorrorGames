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

    //flashlight to enemy
    [SerializeField] private Transform playerCamTransform;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float rayDistance;
    private Enemy theEnemy;
    private float currentHitTime = 0f;
    [SerializeField] private float rayDuration;

    private bool isActive = false;
    [SerializeField] private GameObject onImg, offImg;

    private void Start()
    {
        if(PlayerPrefs.GetInt("buff1") == 1)
        {
            maxBatery += 50f;
            PlayerPrefs.SetInt("buff1", 0);
        }

        flashlightSlider.maxValue = maxIntensity;
        flashlightSlider.value = 0;

        currentBatery = maxBatery;

        baterySlider.maxValue = maxBatery;
        baterySlider.value = currentBatery;
        fill.color = gradient.Evaluate(1f);

        theEnemy = FindObjectOfType<Enemy>();
    }

    private void Update()
    {
        flashlight.intensity = flashlightSlider.value;

        if(flashlight.intensity > 0)
        {
            if(currentBatery > 0)
            {
                isActive = true;
                onImg.SetActive(true);
                offImg.SetActive(false);
                currentBatery -= dValue * Time.deltaTime;
                baterySlider.value = currentBatery;
                fill.color = gradient.Evaluate(baterySlider.normalizedValue);

                //flashlight reduce enemy speed
                if (Physics.Raycast(playerCamTransform.position, playerCamTransform.forward, out RaycastHit rayHit, rayDistance, enemyLayer))
                {
                    if (rayHit.collider.gameObject.tag == "Enemy")
                    {
                        if (theEnemy.cursing == false)
                        {
                            if (theEnemy.onDazzled == false)
                            {
                                currentHitTime -= Time.deltaTime;
                                if(currentHitTime <= 0)
                                {
                                    StartCoroutine(theEnemy.Dazzled());
                                    currentHitTime = rayDuration;
                                }
                            }
                            else
                            {
                                currentHitTime = rayDuration;
                            }
                        }
                    }
                    else
                    {
                        currentHitTime = rayDuration;
                    }
                }
                else
                {
                    currentHitTime = rayDuration;
                }
            }
            else
            {
                flashlight.intensity = 0;
                currentHitTime = rayDuration;
            }
        }
        else
        {
            currentHitTime = rayDuration;
            isActive = false;
            offImg.SetActive(true);
            onImg.SetActive(false);
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(playerCamTransform.position, playerCamTransform.forward * rayDistance);
    }

    public void OnOff()
    {
        if (isActive == false)
        {
            flashlightSlider.value = maxIntensity / 2;
            onImg.SetActive(true);
            offImg.SetActive(false);
        }
        else if (isActive == true)
        {
            flashlightSlider.value = 0;
            offImg.SetActive(true);
            onImg.SetActive(false);
        }
    }
}
