using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Image imgCd1, imgCd2, imgCd3;
    [SerializeField] private float cdTime;
    private float timer;
    private bool isCd = false;
    public static int buffNo;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("buff1", 0);
        PlayerPrefs.SetInt("buff2", 0);
        PlayerPrefs.SetInt("buff3", 0);

        imgCd1.fillAmount = 0;
        imgCd2.fillAmount = 0;
        imgCd3.fillAmount = 0;
        imgCd1.gameObject.SetActive(false);
        imgCd2.gameObject.SetActive(false);
        imgCd3.gameObject.SetActive(false);

        buffNo = 0;
    }

    public void Update()
    {
        if(isCd)
        {
            ApplyCD();
        }
    }

    public void BuffClick(int buffID)
    {
        if(buffID == 1)
        {
            buffNo = 1;
            //PlayerPrefs.SetInt("buff1", 1);
        }
        else if(buffID == 2)
        {
            buffNo = 2;
            //PlayerPrefs.SetInt("buff2", 1);
        }
        else if(buffID == 3)
        {
            buffNo = 3;
            //PlayerPrefs.SetInt("buff3", 1);
        }

        isCd = true;
        timer = cdTime;
    }

    public void NonactiveBtn(GameObject watchadsBtn)
    {
        watchadsBtn.SetActive(false);
    }

    public void BuffActive(GameObject activeImg)
    {
        activeImg.SetActive(true);
    }

    public void ApplyCD()
    {
        if (isCd == true)
        {
            imgCd1.gameObject.SetActive(true);
            imgCd2.gameObject.SetActive(true);
            imgCd3.gameObject.SetActive(true);
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                isCd = false;

                imgCd1.fillAmount = 0;
                imgCd2.fillAmount = 0;
                imgCd3.fillAmount = 0;
                imgCd1.gameObject.SetActive(false);
                imgCd2.gameObject.SetActive(false);
                imgCd3.gameObject.SetActive(false);
            }
            else
            {
                imgCd1.fillAmount = timer / cdTime;
                imgCd2.fillAmount = timer / cdTime;
                imgCd3.fillAmount = timer / cdTime;
            }
        }
    }
}
