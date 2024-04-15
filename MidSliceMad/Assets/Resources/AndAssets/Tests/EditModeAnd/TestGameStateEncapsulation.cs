using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestGameStateEncapsulation
{
    [Test]
    public void TestGameStatePropertiesAndMethods()
    {
        var gameState = new GameState();

        gameState.Score = 10;
        gameState.TimeLeft = 60f;
        gameState.IsGameOver = false;
        gameState.PizzaDeliveryOngoing = true;
        gameState.StartPizzaDeliveryTimer(60f);
        gameState.TurnOffPizzaDeliveryTimer();
        gameState.UpdatePizzaDeliveryTimer(10f);

        // Check values
        Assert.AreEqual(10, gameState.Score);
        Assert.AreEqual(0f, gameState.TimeLeft);
        Assert.IsFalse(gameState.IsGameOver);
        Assert.IsFalse(gameState.PizzaDeliveryOngoing);
        Assert.AreEqual(0f, gameState.TimeLeft);
        Assert.IsFalse(gameState.PizzaDeliveryOngoing);
    }
}
