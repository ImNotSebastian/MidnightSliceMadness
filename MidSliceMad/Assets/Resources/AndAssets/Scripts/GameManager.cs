/*
Name: Andrew Plum
Role: Team Lead 4 -- Project Manager
Project: Midnight Slice Madness
This file contains the definition for the GameManager Class
This class is used for the Score and Pizza Delivery Timer
It inherits from MonoBehaviour
This class is part of a Singleton and Private Class Data pattern
*/

///*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameState _gameState;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeLeftText;
    public Player _player;

    public static GameManager instance { get; private set; } // GameManager instance object can be get publicly but set privately

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;
    }

    private void Start()
    {
        _gameState = new GameState();
        UpdateScoreText();
        DisplayScoreText();
        _player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        GameManager.instance.UpdatePizzaDeliveryTimer();
    }

    public void IncreaseScore(int scoreReward)
    {
        _gameState.Score += scoreReward;
        UpdateScoreText();
    }

    public void DecreaseScore(int scorePenalty)
    {
        _gameState.Score -= scorePenalty;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + _gameState.Score.ToString();
    }

    public void DisplayScoreText()
    {
        //Debug.Log(scoreText.text);
    }

    public void StartPizzaDeliveryTimer(float pizzaDeliveryTimeLimit)
    {
        _gameState.StartPizzaDeliveryTimer(pizzaDeliveryTimeLimit);
    }

    public void TurnOffPizzaDeliveryTimer()
    {
        _gameState.TurnOffPizzaDeliveryTimer();
    }

    public void UpdatePizzaDeliveryTimer()
    {
        _gameState.UpdatePizzaDeliveryTimer(Time.deltaTime);

        if (_gameState.TimeLeft <= 0)
        {
            timeLeftText.text = "Pizza Delivery Time Left: *";
        }
        else
        {
            timeLeftText.text = "Pizza Delivery Time Left: " + Mathf.Round(_gameState.TimeLeft).ToString();
        }

        if (_gameState.PizzaDeliveryOngoing == false)
        {
            _player.PizzaDeliveryTimerRanOut();
        }
    }
}
//*/
