using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;
public class RocketAd : MonoBehaviour
{
    private RewardedAd rewardedAd;
    public GameObject attentionscreen;
    public Text attentiontext;

    public GameObject[] rocketquantityminipicture;
    public Button rocketbutton;
    public Button rocketADbutton;
    void Start()
    {
        string adUnitId;
#if UNITY_ANDROID
        adUnitId = "ca-app-pub-6469014985923539/9478893443"; //buraya kendi reklam kodu yazýlacak
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
        if (DataManager.Instance.whichlevel >= 6 && DataManager.Instance.rocketquantity <=3 )
        {
            DataManager.Instance.rocketquantity++;
            attentionscreen.SetActive(true);
            attentiontext.GetComponent<Text>().text = "Rocket is added.";
        }
        else
        {
            attentionscreen.SetActive(true);
            attentiontext.GetComponent<Text>().text = "Something went wrong.";
        }
        DataManager.Instance.SaveData();
        Time.timeScale = 0;
        rocketquantitycounter();
    }

    void rocketquantitycounter()
    {
        
        if (DataManager.Instance.rocketquantity == 0)
        {
            for (int i = 0; i <= 3; i++)
            {
                rocketquantityminipicture[i].SetActive(true);
            }
        }
        else if (DataManager.Instance.rocketquantity == 1)
        {
            quantitycut(rocketquantityminipicture, DataManager.Instance.rocketquantity - 1);
            for (int i = 1; i <= 3; i++)
            {
                rocketquantityminipicture[i].SetActive(true);
            }

        }
        else if (DataManager.Instance.rocketquantity == 2)
        {
            quantitycut(rocketquantityminipicture, DataManager.Instance.rocketquantity - 1);
            for (int i = 2; i <= 3; i++)
            {
                rocketquantityminipicture[i].SetActive(true);
            }

        }
        else if (DataManager.Instance.rocketquantity == 3)
        {
            quantitycut(rocketquantityminipicture, DataManager.Instance.rocketquantity - 1);
            rocketquantityminipicture[3].SetActive(true);

        }
        else if (DataManager.Instance.rocketquantity == 4)
        {
            quantitycut(rocketquantityminipicture, DataManager.Instance.rocketquantity - 1);
            rocketbutton.interactable = false;
            rocketADbutton.interactable = false;
        }
    }

    void quantitycut(GameObject[] obje, int howmany)
    {
        for (int i = 0; i <= howmany; i++)
        {
            obje[i].SetActive(false);
        }
    }
    public void WatchTheAd()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }
}
