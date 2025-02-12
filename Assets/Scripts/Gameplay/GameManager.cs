using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameoverUI;
  
    
    public static GameManager Instance { get; private set;  }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void ContinueGame()
    {
        Debug.Log("Player continues after watching an ad!");
        Time.timeScale = 1f;
    }
    
    private void EndGame()
    {
        Debug.Log("End");
        gameoverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    
}
