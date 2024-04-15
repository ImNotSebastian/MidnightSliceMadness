using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;

public class TestPizzaDeliveryTimerEnd
{
    [Test]
    public void TestPizzaDeliveryTimerEndsCorrectly()
    {
        //var gameManager = new GameManager();
        var gameManager = GameManager.instance;
        gameManager.timeLeftText = new TextMeshProUGUI();
        var player = new Player();
        gameManager._player = player;
        gameManager._gameState.TimeLeft = 0f;
        gameManager._gameState.PizzaDeliveryOngoing = true;

        gameManager.UpdatePizzaDeliveryTimer();

        // Check values
        Assert.IsFalse(gameManager._gameState.PizzaDeliveryOngoing);
        Assert.AreEqual("Pizza Delivery Time Left: *", gameManager.timeLeftText.text);
        Assert.IsFalse(player.GetPizzaDeliveryTimerRanOutCalled());
    }
}
