using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using BounceHitman.Misc;

public class AdManager : SingletonMonoBehaviour<AdManager>, IUnityAdsListener
{
#if UNITY_ANDROID
    private static readonly string storeID = "3905051";
#elif UNITY_IOS
    private static readonly string storeID = "3905050";
#endif

    private static readonly string videoID = "video";
    private static readonly string rewardedID = "rewardedVideo";
    private static readonly string bannerID = "banner";

    private event Action adSuccess;
    private event Action adSkipped;
    private event Action adFailed;

#if UNITY_EDITOR
    private static bool testMode = true;
#else
    private static bool testMode = false;
#endif

    protected override void Awake()
    {
        base.Awake();
        if (Instance == this)
        {
            DontDestroyOnLoad(gameObject);
            Advertisement.AddListener(this);
            Advertisement.Initialize(storeID, testMode);
        }
    }

    public static void ShowStandardAd()
    {
        if (Advertisement.IsReady(videoID))
        {
            Advertisement.Show(videoID);
        }
    }

    public static void ShowBanner()
    {
        Instance.StartCoroutine(ShowBannerWhenReady());
    }

    public static void HideBanner()
    {
        Advertisement.Banner.Hide();
    }

    public static void ShowRewardedAdd(Action success, Action skipped, Action failed)
    {
        Instance.adSuccess = success;
        Instance.adSkipped = skipped;
        Instance.adFailed = failed;
        if (Advertisement.IsReady(rewardedID))
        {
            Advertisement.Show(rewardedID);
        }
    }

    private static IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady(bannerID))
        {
            yield return new WaitForSeconds(0.5f);
        }

        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(bannerID);
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == rewardedID)
        {
            switch (showResult)
            {
                case ShowResult.Finished:
                    adSuccess?.Invoke();
                    break;
                case ShowResult.Skipped:
                    adSkipped?.Invoke();
                    break;
                case ShowResult.Failed:
                    adFailed?.Invoke();
                    break;
            }
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {

    }

    public void OnUnityAdsReady(string placementId)
    {

    }

    public void OnUnityAdsDidError(string message)
    {

    }
}
