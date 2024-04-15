using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestPlayerPizzaDeliveryTimerRunOut
{
    [Test]
    public void TestPlayerPizzaDeliveryTimerRunsOut()
    {
        var player = new Player();
        var gameManager = GameManager.instance;
        gameManager._player = player;
        player.SetPizzaGameObject(new GameObject("PizzaObject"));
        player.SetCurrentPizzaObject(new CrudePizza());
        player.SetPlayerHasPizza(true);
        player.SetPizzaDeliveryTimerRanOutCalled(false);

        player.PizzaDeliveryTimerRanOut();

        // Check values
        Assert.IsNull(player.GetPizzaGameObject());
        Assert.IsFalse(player.GetPlayerHasPizza());
        Assert.AreEqual(5, gameManager._gameState.Score);
        Assert.AreEqual("Score: 5", gameManager.scoreText.text);
        Assert.IsTrue(player.GetPizzaDeliveryTimerRanOutCalled());
    }
}
