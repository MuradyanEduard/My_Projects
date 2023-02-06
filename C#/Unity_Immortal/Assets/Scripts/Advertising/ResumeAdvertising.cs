using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeAdvertising : MonoBehaviour
{
    private RewardedAd rewardedAd;
    public GameObject wind;
    public GameObject player;
    public GameObject gameOverUI;
    public GameObject gameLiveUI;

    public void ResumeGame()
    {
        MobileAds.Initialize(initStatus => { });

        RequestRewardedVideo();

        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }
    }

    public void RequestRewardedVideo()
    {
        string adUnitId;
#if UNITY_ANDROID
        adUnitId = "ca-app-pub-2362543225491864/6046902201";
#elif UNITY_IPHONE
            adUnitId = "ca-app-pub-2362543225491864/6046902201";
#else
            adUnitId = "unexpected_platform";
#endif

        this.rewardedAd = new RewardedAd(adUnitId);

        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             );
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        Time.timeScale = 1;
        wind.SetActive(true);
        player.GetComponent<PlayerLogic>().health = 6;
        player.GetComponent<PlayerLogic>().healthSlider.value = 6;
        gameOverUI.SetActive(false);
        gameLiveUI.SetActive(true);
        this.gameObject.SetActive(false);
    }

}
