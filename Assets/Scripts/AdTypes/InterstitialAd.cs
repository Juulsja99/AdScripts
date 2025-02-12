using System;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class InterstitialAd : MonoBehaviour , IUnityAdsLoadListener , IUnityAdsShowListener
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
      LoadInterstitialAd();  
      Debug.Log("Interstitial ad loaded.");
   }


   public void LoadInterstitialAd()
   {
     
      Advertisement.Load(adUnitId, this);
   }

   public void ShowInterstitialAd()
   {
      Advertisement.Show(adUnitId, this);
      LoadInterstitialAd();
      Time.timeScale = 0f;
   }
   
   
   public void OnUnityAdsAdLoaded(string placementId)
   {
      if (placementId == adUnitId)
      {
         Debug.Log("Interstitial ad successfully loaded.");
      }
   }

   public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
   {
      Debug.LogError($"Interstitial ad failed to load: {message}");
   }

   public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
   {
      Debug.LogError($"Interstitial ad failed to show: {message}");
   }

   public void OnUnityAdsShowStart(string placementId)
   {
      Debug.Log("Interstitial ad started.");
   }

   public void OnUnityAdsShowClick(string placementId)
   {
      Debug.Log("Interstitial ad clicked.");
   }

   public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
   {
      if (placementId == adUnitId)
      {
         if (showCompletionState == UnityAdsShowCompletionState.COMPLETED)
         {
            Debug.Log("Interstitial ad watched successfully.");
         }
         else
         {
            Debug.Log("Interstitial ad skipped.");
         }
         
         RestartGame();
      }
   }
   
   private void RestartGame()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      Time.timeScale = 1f;
      Debug.Log("Game restarted.");
   }
}
