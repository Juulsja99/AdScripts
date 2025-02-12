using UnityEngine;
using UnityEngine.Advertisements;
 
public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
   [SerializeField] private string androidGameId;
   [SerializeField] private string iosGameId;
   [SerializeField] private bool isTesting;

   private string gameId;
   
   private void Awake()
   {
      if (Application.platform == RuntimePlatform.IPhonePlayer)
         gameId = iosGameId;
      else
         gameId = androidGameId;

      if (!Advertisement.isInitialized && Advertisement.isSupported)
      {
         Advertisement.Initialize(gameId, isTesting, this);
      }
   }


   public void OnInitializationComplete()
   {
      Debug.Log("Unity Ads Initialization Complete.");
   }

   public void OnInitializationFailed(UnityAdsInitializationError error, string message)
   {
      throw new System.NotImplementedException();
   }
}