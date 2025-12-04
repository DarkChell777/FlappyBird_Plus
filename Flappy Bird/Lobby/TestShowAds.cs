using UnityEngine;
using UnityEngine.Advertisements;

public class TestShowAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private AdsTypes _adsType;
    public bool StartAds;

    private string androidAdID_Interstitial = "Interstitial_Android";
    private string iOSAdID_Interstitial = "Interstitial_iOS";
    private string androidAdID_Banner = "Banner_Android";
    private string iOSAdID_Banner = "Banner_iOS";
    private string androidAdID_Rewarded = "Rewarded_Android";
    private string iOSAdID_Rewarded = "Rewarded_iOS";
    private string adID;

    private void Awake()
    {
        SetAdID();
    }

    private void SetAdID()
    {
        switch (_adsType)
        {
            case AdsTypes.Interstitial:
                adID = (Application.platform == RuntimePlatform.IPhonePlayer) ? iOSAdID_Interstitial : androidAdID_Interstitial;
                break;
            case AdsTypes.Banner:
                adID = (Application.platform == RuntimePlatform.IPhonePlayer) ? iOSAdID_Banner : androidAdID_Banner;
                break;
            case AdsTypes.Rewarded:
                adID = (Application.platform == RuntimePlatform.IPhonePlayer) ? iOSAdID_Rewarded : androidAdID_Rewarded;
                break;
        }
    }

    private void FixedUpdate()
    {
        if (StartAds) 
        {
            ShowAd();
            StartAds = false;
        }
    }

    public void ShowAd()
    {
        Advertisement.Load(adID, this);
        Advertisement.Show(adID, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Реклама загружена: " + placementId);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Ошибка загрузки рекламы: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Ошибка показа рекламы: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("Старт показа реклама: " + placementId);
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("клик по рекламе: " + placementId);
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("Юнити завершил показ рекламы.");
    }
}

public enum AdsTypes
{
    Banner,
    Interstitial,
    Rewarded
}
