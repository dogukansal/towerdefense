using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;
public class HomeHealAdManager : MonoBehaviour
{
    private RewardedAd rewardedAd;
    public GameObject attentionscreen;
    public Text attentiontext;

    public Text healthbartext;
    public Slider slider;
    void Start()
    {
        string adUnitId;
#if UNITY_ANDROID
        adUnitId = ""; //buraya kendi reklam kodu yazýlacak
#elif UNITY_IPHONE
            adUnitId = "ca-app-pub-/";
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
        string adUnitId = "ca-app-pub-/";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-/";
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
        if ( DataManager.Instance.whichlevel >= 0 && DataManager.Instance.whichlevel <= 2)
        {


            DataManager.Instance.homeheal += 800;
            DataManager.Instance.usedhomeheal += 800;
            attentionscreen.SetActive(true);
            attentiontext.GetComponent<Text>().text = "800 heal added.";

        }
        else if ( DataManager.Instance.whichlevel >= 3 && DataManager.Instance.whichlevel <= 4)
        {

            DataManager.Instance.homeheal += 800;
            DataManager.Instance.usedhomeheal += 800;
            attentionscreen.SetActive(true);
            attentiontext.GetComponent<Text>().text = "800 heal added.";

        }
        else if ( DataManager.Instance.whichlevel >= 5 && DataManager.Instance.whichlevel <= 7)
        {

            DataManager.Instance.homeheal += 2000; //800
            DataManager.Instance.usedhomeheal += 2000;
            attentionscreen.SetActive(true);
            attentiontext.GetComponent<Text>().text = "2000 heal added.";

        }
        else if ( DataManager.Instance.whichlevel >= 8 && DataManager.Instance.whichlevel <= 10)
        {

            DataManager.Instance.homeheal += 4000; //3k
            DataManager.Instance.usedhomeheal += 4000;
            attentionscreen.SetActive(true);
            attentiontext.GetComponent<Text>().text = "4000 heal added.";

        }
        else if ( DataManager.Instance.whichlevel >= 11 && DataManager.Instance.whichlevel <= 14)
        {

            DataManager.Instance.homeheal += 12000;
            DataManager.Instance.usedhomeheal += 12000;
            attentionscreen.SetActive(true);
            attentiontext.GetComponent<Text>().text = "12000 heal added.";

        }
        else if ( DataManager.Instance.whichlevel >= 15 && DataManager.Instance.whichlevel <= 19)
        {

            DataManager.Instance.homeheal += 20000;
            DataManager.Instance.usedhomeheal += 20000;
            attentionscreen.SetActive(true);
            attentiontext.GetComponent<Text>().text = "20000 heal added.";

        }

        if (DataManager.Instance.homeheal > DataManager.Instance.maxhomeheal)
        {
            DataManager.Instance.homeheal = DataManager.Instance.maxhomeheal;
        }
        DataManager.Instance.SaveData();
        slider.value = DataManager.Instance.homeheal;
        healthbartext.GetComponent<Text>().text = DataManager.Instance.homeheal + " / " + DataManager.Instance.maxhomeheal;
        Time.timeScale = 0;

    }

    public void WatchTheAd()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }
}
