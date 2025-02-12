using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    private AdsInitializer adsInitializer;
   [SerializeField] private BannerAds bannerAds;
    
    public static AdsManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        StartCoroutine(InitializeAdsAndShowBanner());
    }

    private IEnumerator InitializeAdsAndShowBanner()
    {
        if (!Advertisement.isInitialized || !Advertisement.isSupported)
        {
            Debug.Log("Waiting for Unity Ads to initialize...");
            yield return new WaitUntil(() => Advertisement.isInitialized);
        }
        
        bannerAds.LoadBannerAd();
        bannerAds.ShowBannerAd();
    }

   
    
    
}




