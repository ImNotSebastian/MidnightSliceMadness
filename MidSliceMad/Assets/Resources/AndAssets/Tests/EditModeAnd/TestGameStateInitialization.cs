using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestGameStateInitialization
{
    [Test]
    public void TestGameStateInitialValues()
    {
        var gameManager = new GameManager();
        gameManager._gameState = new GameState();

        var gameState = gameManager._gameState;

        // Check values
        Assert.AreEqual(0, gameState.Score);
        Assert.AreEqual(0f, gameState.TimeLeft);
        Assert.IsFalse(gameState.IsGameOver);
        Assert.IsFalse(gameState.PizzaDeliveryOngoing);
    }
}
