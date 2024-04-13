/*
Name: Andrew Plum
Role: Team Lead 4 -- Project Manager
Project: Midnight Slice Madness
This file contains the definition for the OLD GameManager Class
This class is used for the first of the old versions of the Score and Pizza Delivery Timer
It inherits from MonoBehaviour
This class is part of a Singleton pattern
The Private Class Data pattern was not yet implemented
*/

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeLeftText;
    [SerializeField] private float TimeLimit = 100f;
    private float timeLeft;
    private bool isGameOver;

    // Begining of singleton pattern

    public static GameManager instance { get; private set; } // gameManager instance object can be get oublicly but set privately

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
    }

    // End of singleton pattern

    private void Start()
    {
        UpdateScoreText();
        DisplayScoreText();
        timeLeft = TimeLimit;
        isGameOver = false;
    }

    private void Update()
    {
        CountdownTime();
    }

    public void IncreaseScore(int plusScore)
    {
        score += plusScore;
        UpdateScoreText();
    }

    public void DecreaseScore()
    {
        score--;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void DisplayScoreText()
    {
        Debug.Log(scoreText.text);
    }

    private void CountdownTime()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timeLeftText.text = "Time Left: " + Mathf.Round(timeLeft).ToString();
        }
        else
        {
            if (isGameOver != true)
            {
                Debug.Log("Game Over");
                isGameOver = true;
            }
        }
    }
}
//*/
