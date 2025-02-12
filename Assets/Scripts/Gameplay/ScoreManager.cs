using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
   private int score;

   [SerializeField] private TextMeshProUGUI scoreText;
   
   void Start()
   {
      score = 0;
      UpdateScoreText();
   }
   
   public void AddScore()
   {
      score++;
      UpdateScoreText();
   }

   private void UpdateScoreText()
   {
      scoreText.text = "Score: " + score.ToString();
   }
}
