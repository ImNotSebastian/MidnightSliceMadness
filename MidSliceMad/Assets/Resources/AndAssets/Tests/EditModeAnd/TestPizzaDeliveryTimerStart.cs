using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;

public class TestPizzaDeliveryTimerStart
{
    [Test]
    public void TestPizzaDeliveryTimerStartsCorrectly()
    {
        var gameManager = new GameManager();
        gameManager.timeLeftText = new TextMeshProUGUI();
        var pizzaDeliveryTimeLimit = 60f;

        gameManager.StartPizzaDeliveryTimer(pizzaDeliveryTimeLimit);

        // Check values
        Assert.AreEqual(pizzaDeliveryTimeLimit, gameManager._gameState.TimeLeft);
        Assert.IsTrue(gameManager._gameState.PizzaDeliveryOngoing);
        Assert.AreEqual("Pizza Delivery Time Left: 60", gameManager.timeLeftText.text);
    }
}
