using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
public class AdMob : MonoBehaviour
{
    // Start is called before the first frame update
    private BannerView bannerView;
    void Start()
    {
         string appId = "ca-app-pub-6879030910136960~6104741794";
         MobileAds.Initialize(appId);
         this.RequestBanner();
    }

    private void RequestBanner()
    {
        string adUnitId = "ca-app-pub-6879030910136960/2185678089";
        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);
    }
  
}
