/*
This is the old version of the game manager where the 
game timer is counting down from the start of the game until
it runs out in which case the game is over.
I am keeping this script in case we ever want to use the old implementation.
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
