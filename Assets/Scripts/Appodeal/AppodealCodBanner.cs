using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

public class AppodealCodBanner : MonoBehaviour, IRewardedVideoAdListener, IPermissionGrantedListener
{
    public static AppodealCodBanner inst;
    void Awake()
    {
        if(inst == null)
        {
            inst = this;
        }

        Appodeal.requestAndroidMPermissions(this);
    }

    public void writeExternalStorageResponse(int result) 
    { 
        if(result == 0) {
            Debug.Log("WRITE_EXTERNAL_STORAGE permission granted"); 
        } else {
            Debug.Log("WRITE_EXTERNAL_STORAGE permission grant refused"); 
        }
    }

    public void accessCoarseLocationResponse(int result) 
    { 
        if(result == 0) {
            Debug.Log("ACCESS_COARSE_LOCATION permission granted"); 
        } else {
            Debug.Log("ACCESS_COARSE_LOCATION permission grant refused"); 
        }
    }   

    void Start()
    {
        string appKey = "b1b070270e0a11ac0951dd346cf282f6c473eb6c58c274a9";
        Appodeal.disableLocationPermissionCheck();
        Appodeal.setTesting(true);
        Appodeal.initialize(appKey, Appodeal.BANNER | Appodeal.INTERSTITIAL | Appodeal.REWARDED_VIDEO);
        Appodeal.setRewardedVideoCallbacks(this);
    }

    public void ShowBanner()
    {
        if(Appodeal.isLoaded(Appodeal.BANNER))
        {
            Appodeal.show(Appodeal.BANNER);
        }
        //Debug.Log("Show Banner");
    }

    public void HideBanner()
    {
        Appodeal.hide(Appodeal.BANNER);
        //Debug.Log("Hide Banner");
    }

    public void ShowBannerBottom()
    {
        if(Appodeal.isLoaded(Appodeal.BANNER_BOTTOM))
        {
            Appodeal.show(Appodeal.BANNER_BOTTOM);
        }
        //Debug.Log("Show Banner Bottom!!");
    }

    public void HideBannerBottom()
    {
        Appodeal.hide(Appodeal.BANNER_BOTTOM);
        //Debug.Log("Hide Banner Bottom!!");
    }

    public void ShowInter()
    {
        if(Appodeal.isLoaded(Appodeal.INTERSTITIAL))
        {
            Appodeal.show(Appodeal.INTERSTITIAL);
        }
    }

    public void ShowRewarded()
    {
        if(Appodeal.isLoaded(Appodeal.REWARDED_VIDEO))
        {
            Appodeal.show(Appodeal.REWARDED_VIDEO);
        }
    }

    public void onRewardedVideoLoaded(bool b)
    {

    }

    public void onRewardedVideoFailedToLoad()
    {

    }

    public void onRewardedVideoShown()
    {

    }

    public void onRewardedVideoClosed(bool b)
    {

    }

    public void onRewardedVideoFinished(double quant, string nome)
    {
        GAMEMANAGER.inst.RecompensaAd();
    }

    //NEW FEATURES
    public void onRewardedVideoExpired()
    {

    }

    public void onRewardedVideoClicked()
    {

    }

    public void onRewardedVideoShowFailed()
    {
        
    }
}
