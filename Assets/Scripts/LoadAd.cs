using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class LoadAd : MonoBehaviour {

    //put ur id at inspector
    public string bannerAdUnit, interstialAdUnit;
    BannerView bannerView;
    InterstitialAd interstitial;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        RequestBanner();
        RequestInterstitial();
        bannerView.Show();
    }

    private void RequestBanner()
    {
#if UNITY_EDITOR
                string adUnitId = "unused";
#elif UNITY_ANDROID
                string adUnitId = bannerAdUnit;
#elif UNITY_IPHONE
                string adUnitId = bannerAdUnit;
#else
        string adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);//change banner position (AdPosition.Bottom);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);
    }

    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = interstialAdUnit;
#elif UNITY_IPHONE
        string adUnitId = interstialAdUnit;
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(request);
    }

    public void ShowInters()
    {
        interstitial.Show();
    }
}
