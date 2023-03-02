using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerAds : MonoBehaviour
{
    private AdsManager theAdsManager;

    // Start is called before the first frame update
    void Start()
    {
        theAdsManager = GetComponent<AdsManager>();

        if (PlayerPrefs.GetInt("removeAds") == 0)
        {
            theAdsManager.RequestBanner();
            theAdsManager.ShowAdBanner();
        }
    }
}
