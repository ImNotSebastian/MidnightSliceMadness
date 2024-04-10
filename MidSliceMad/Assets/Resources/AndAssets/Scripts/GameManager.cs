///*
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
    //[SerializeField] private float timeLimit = -1f;
    private float timeLeft;
    private bool isGameOver;
    private Player player;

    public float PizzaDeliveryTimeLeft
    {
        get { return timeLeft; }
    }

    // Begining of singleton pattern

    public static GameManager instance { get; private set; } // gameManager instance object can be get publicly but set privately

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
        timeLeft = 0;
        isGameOver = false;
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        //CountdownTime();
        GameManager.instance.UpdatePizzaDeliveryTimer();
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

    /*
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
    //*/

    public void StartPizzaDeliveryTimer(float pizzaDeliveryTimeLimit)
    {
        //timeLeft = timeLimit;
        timeLeft = pizzaDeliveryTimeLimit;
        isGameOver = false;
    }

    public void UpdatePizzaDeliveryTimer()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timeLeftText.text = "Pizza Delivery Time Left: " + Mathf.Round(timeLeft).ToString();
        }
        else
        {
            if (isGameOver != true)
            {
                //Debug.Log("Pizza Delivery Time Ran Out");
                //isGameOver = true; // end game if desired
                player.PizzaDeliveryTimerRanOut();
            }
        }

        // Check if the timer is not running and update the text accordingly
        if (timeLeft <= 0)
        {
            timeLeftText.text = "Pizza Delivery Time Left: *";
        }
    }
}
//*/
