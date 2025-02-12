using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissZone : MonoBehaviour
{
  [SerializeField]  private InterstitialAd interstitialAd;
  
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Obj"))  // Assuming the player has the "Player" tag
    {
      Debug.Log("Miss");
      interstitialAd.LoadInterstitialAd();
      interstitialAd.ShowInterstitialAd();
      
    }
  }
    
    
}
