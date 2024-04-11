using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState
{
    private int _score;
    private float _timeLeft;
    private bool _isGameOver;
    private bool _pizzaDeliveryOngoing;

    public int Score
    {
        get { return _score; }
        set { _score = value; }
    }

    public float TimeLeft
    {
        get { return _timeLeft; }
        set { _timeLeft = value; }
    }

    public bool IsGameOver
    {
        get { return _isGameOver; }
        set { _isGameOver = value; }
    }

    public bool PizzaDeliveryOngoing
    {
        get { return _pizzaDeliveryOngoing; }
        set { _pizzaDeliveryOngoing = value; }
    }

    public void StartPizzaDeliveryTimer(float pizzaDeliveryTimeLimit)
    {
        TimeLeft = pizzaDeliveryTimeLimit;
        PizzaDeliveryOngoing = true;
    }

    public void TurnOffPizzaDeliveryTimer()
    {
        TimeLeft = 0;
        PizzaDeliveryOngoing = false;
    }

    public void UpdatePizzaDeliveryTimer(float deltaTime)
    {
        if (TimeLeft > 0)
        {
            TimeLeft -= deltaTime;
        }
        else
        {
            if (PizzaDeliveryOngoing)
            {
                PizzaDeliveryOngoing = false;
            }
        }
    }
}
