/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;

   private int score = 0;
   public Text scoreText;

   private void Awake()
   {
      if (Instance == null)
         Instance = this;
      else
         Destroy(gameObject);
   }

   private void Start()
   {
      UpdateScoreText();
   }

   public void IncreaseScore()
   {
      score++;
      UpdateScoreText();
   }

   private void UpdateScoreText()
   {
      scoreText.text = "Score: " + score.ToString();
   }
}
*/
