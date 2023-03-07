using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public bool buff1, buff2, buff3;
    // Start is called before the first frame update

    void Start()
    {
        buff1 = false;
        buff2 = false;
        buff3 = false;
        PlayerPrefs.SetInt("buff1", 0);
        PlayerPrefs.SetInt("buff2", 0);
        PlayerPrefs.SetInt("buff3", 0);
        //DontDestroyOnLoad(gameObject);
    }

    public void BuffClick(int buffID)
    {
        if(buffID == 1)
        {
            buff1 = true;
            PlayerPrefs.SetInt("buff1", 1);
        }
        else if(buffID == 2)
        {
            buff2 = true;
            PlayerPrefs.SetInt("buff2", 1);
        }
        else if(buffID == 3)
        {
            buff3 = true;
            PlayerPrefs.SetInt("buff3", 1);
        }
    }

    public void NonactiveBtn(GameObject watchadsBtn)
    {
        watchadsBtn.SetActive(false);
    }
}
