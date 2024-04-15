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
        var gameManager = GameManager.instance;
        gameManager.timeLeftText = new TextMeshProUGUI();
        var pizzaDeliveryTimeLimit = 60f;

        gameManager.StartPizzaDeliveryTimer(pizzaDeliveryTimeLimit);
        gameManager.UpdatePizzaDeliveryTimer();

        // Check values
        Assert.AreEqual(pizzaDeliveryTimeLimit, gameManager._gameState.TimeLeft, 1f);
        Assert.IsTrue(gameManager._gameState.PizzaDeliveryOngoing);
        Assert.AreEqual("Pizza Delivery Time Left: 60", gameManager.timeLeftText.text);
    }
}
