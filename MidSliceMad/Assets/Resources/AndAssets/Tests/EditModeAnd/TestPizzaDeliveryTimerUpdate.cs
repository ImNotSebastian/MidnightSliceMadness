using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;

public class TestPizzaDeliveryTimerUpdate
{
    [Test]
    public void TestPizzaDeliveryTimerUpdatesCorrectly()
    {
        var gameManager = new GameManager();
        gameManager.timeLeftText = new TextMeshProUGUI();
        gameManager._gameState.TimeLeft = 30f;
        gameManager._gameState.PizzaDeliveryOngoing = true;

        gameManager.UpdatePizzaDeliveryTimer();

        // Check values
        Assert.Less(gameManager._gameState.TimeLeft, 30f);
        Assert.IsTrue(gameManager.timeLeftText.text.StartsWith("Pizza Delivery Time Left:"));
    }
}
