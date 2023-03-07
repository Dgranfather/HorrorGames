using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        PlayerPrefs.SetInt("buff1", 0);
        PlayerPrefs.SetInt("buff2", 0);
        PlayerPrefs.SetInt("buff3", 0);
        //DontDestroyOnLoad(gameObject);
    }

    public void BuffClick(int buffID)
    {
        if(buffID == 1)
        {
            PlayerPrefs.SetInt("buff1", 1);
        }
        else if(buffID == 2)
        {
            PlayerPrefs.SetInt("buff2", 1);
        }
        else if(buffID == 3)
        {
            PlayerPrefs.SetInt("buff3", 1);
        }
    }

    public void NonactiveBtn(GameObject watchadsBtn)
    {
        watchadsBtn.SetActive(false);
    }

    public void BuffActive(GameObject activeImg)
    {
        activeImg.SetActive(true);
    }
}
