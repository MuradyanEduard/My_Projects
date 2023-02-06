using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void OnMainMenuClick()
    {
        SceneManager.LoadScene("Loading");
    }

    private void Update()
    {
        Debug.Log(PlayerPrefs.GetFloat("AdvTime", 0));
        if (PlayerPrefs.GetFloat("AdvTime", 0) > 900)
        {
            PlayerPrefs.SetFloat("AdvTime", 0);
            RequestInterstitial();

            if (this.interstitial.IsLoaded())
            {
                this.interstitial.Show();
            }
        }
    }


    private InterstitialAd interstitial;
    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-2362543225491864/8864637231";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-2362543225491864/8864637231";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }
}
