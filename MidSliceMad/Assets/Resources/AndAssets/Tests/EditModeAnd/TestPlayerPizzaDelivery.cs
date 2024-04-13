using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestPlayerPizzaDelivery
{
    [Test]
    public void TestPlayerDeliversPizza()
    {
        var player = new Player();
        var gameManager = new GameManager();
        gameManager._player = player;
        player.SetPizzaGameObject(new GameObject("PizzaObject"));
        player.SetCurrentPizzaObject(new CrudePizza());
         player.SetPlayerHasPizza(true);

        player.DeliverPizza();

        // Check values
        Assert.IsNull(player.GetPizzaGameObject());
        Assert.IsFalse(player.GetPlayerHasPizza());
        Assert.AreEqual(10, gameManager._gameState.Score);
        Assert.AreEqual("Score: 10", gameManager.scoreText.text);
        Assert.AreEqual(0f, gameManager._gameState.TimeLeft);
        Assert.IsFalse(gameManager._gameState.PizzaDeliveryOngoing);
    }
}
