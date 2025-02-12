using UnityEngine;
using UnityEngine.Advertisements;


public class BannerAds : MonoBehaviour
{
    [SerializeField] private string androidAdUnitId;
    [SerializeField] private string iosAdUnitId;

    private string adUnitId;


    private void Awake()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
            adUnitId = iosAdUnitId;
        else
            adUnitId = androidAdUnitId;
        
        
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        
        if (Advertisement.isInitialized && Advertisement.isSupported)
        {
            LoadBannerAd();
        }
    }

    public void LoadBannerAd()
    {
        if (Advertisement.Banner.isLoaded) return;
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = BannerLoaded,
            errorCallback = BannerLoadedError
        };
        
        Advertisement.Banner.Load(adUnitId, options);
    }

    public void ShowBannerAd()
    {
        if (Advertisement.Banner.isLoaded)
        {
            BannerOptions options = new BannerOptions
            {
                showCallback = BannerShown,
                clickCallback = BannerClicked,
                hideCallback = BannerHidden
            };

            Advertisement.Banner.Show(adUnitId, options);

            
        }
        else
        {
            Debug.LogWarning("Banner ad not loaded yet. Loading now...");
            LoadBannerAd();
        }
    }

    public void HideBannerAd()
    {
        Advertisement.Banner.Hide();
    }
    
    

    private void BannerHidden() { }

    private void BannerClicked() { }

    private void BannerShown() { }

    private void BannerLoadedError(string message) { }

    private void BannerLoaded() { }
}
