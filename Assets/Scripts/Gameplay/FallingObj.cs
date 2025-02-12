using UnityEngine;

public class FallingObj : MonoBehaviour
{
    private ScoreManager scoreManager;
    
    private void Start()
    {
        
        if (scoreManager == null)
        {
            scoreManager = FindObjectOfType<ScoreManager>();
        }
        
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            scoreManager.AddScore();
            Destroy(gameObject); 
        }

        if (other.CompareTag("MissZone"))
        {
            Destroy(gameObject);
        }
        
    }
    
}
