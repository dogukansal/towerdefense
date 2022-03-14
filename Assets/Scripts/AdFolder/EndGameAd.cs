using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;

public class EndGameAd : MonoBehaviour
{
    private RewardedAd rewardedAd;
    public GameObject attentionscreen;
    public Text attentiontext;
    public GameObject adbutton;
    void Start()
    {
        string adUnitId;
#if UNITY_ANDROID
        adUnitId = "ca-app-pub-6469014985923539/2144657891"; //buraya kendi reklam kodu yazýlacak
#elif UNITY_IPHONE
            adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
            adUnitId = "unexpected_platform";
#endif
        MobileAds.Initialize(InitializationStatus => { });
        this.rewardedAd = new RewardedAd(adUnitId);



        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad; //reklam çaðýrma baþarýsýz
                                                                          // Called when an ad is shown.

        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow; //gösterilirken hata olmasý
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward; //reklamý erken kapatma
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed; //baþarýlý


        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
    }
    public void CreateAndLoadRewardedAd()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
            string adUnitId = "unexpected_platform";
#endif

        this.rewardedAd = new RewardedAd(adUnitId);

        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
    }
    short dur = 0;
    short dur2 = 0;
    public void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        if (dur != 3)
        {
            this.CreateAndLoadRewardedAd();
            dur++;
        }
        

    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        if (dur2 == 3)
        {
            attentionscreen.SetActive(true);
            attentiontext.GetComponent<Text>().text = "won't load until you return to home screen";
        }
        else
        {
            this.CreateAndLoadRewardedAd();
            attentionscreen.SetActive(true);
            attentiontext.GetComponent<Text>().text = "Ad is failed.";
            dur2++;
        }
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        this.CreateAndLoadRewardedAd();
        
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        if (DataManager.Instance.returnlevel() == 0)
        {
            rewardcut(100);
        }
        else if (DataManager.Instance.returnlevel() == 1)
        {
            rewardcut(400);
        }
        else if (DataManager.Instance.returnlevel() == 2)
        {
            rewardcut(500);
        }
        else if (DataManager.Instance.returnlevel() == 3)
        {
            rewardcut(1000);
        }
        else if (DataManager.Instance.returnlevel() == 4)
        {
            rewardcut(1000);
        }
        else if (DataManager.Instance.returnlevel() == 5)
        {
            rewardcut(4000);
        }
        else if (DataManager.Instance.returnlevel() == 6)
        {
            rewardcut(6000);
        }
        else if (DataManager.Instance.returnlevel() == 7)
        {
            rewardcut(8000);
        }
        else if (DataManager.Instance.returnlevel() == 8)
        {
            rewardcut(10000);
        }
        else if (DataManager.Instance.returnlevel() == 9)
        {
            rewardcut(12500);
        }
        else if (DataManager.Instance.returnlevel() == 10)
        {
            rewardcut(15000);
        }
        else if (DataManager.Instance.returnlevel() == 11)
        {
            rewardcut(25000);
        }
        else if (DataManager.Instance.returnlevel() == 12)
        {
            rewardcut(40000);
        }
        else if (DataManager.Instance.returnlevel() == 13)
        {
            rewardcut(45000);
        }
        else if (DataManager.Instance.returnlevel() == 14)
        {
            rewardcut(50000);
        }
        else if (DataManager.Instance.returnlevel() == 15)
        {
            rewardcut(60000);
        }
        else if (DataManager.Instance.returnlevel() == 16)
        {
            rewardcut(50000);
        }
        else if (DataManager.Instance.returnlevel() == 17)
        {
            rewardcut(70000);
        }
        else if (DataManager.Instance.returnlevel() == 18)
        {
            rewardcut(70000);
        }
        else if (DataManager.Instance.returnlevel() == 19)
        {
            rewardcut(100000);
        }
        adbutton.SetActive(false);
        DataManager.Instance.SaveData();
        Time.timeScale = 0;
    }

    void rewardcut(int money)
    {
        DataManager.Instance.mymoney += money;
        attentionscreen.SetActive(true);
        attentiontext.GetComponent<Text>().text = money + " gold is added.";
    }
    public void WatchTheAd()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }
}
