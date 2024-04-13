using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestPlayerPizzaPickup
{
    [Test]
    public void TestPlayerPicksUpPizza()
    {
        var player = new Player();
        var gameManager = new GameManager();
        gameManager._player = player;

        player.GenerateAndPlayerPicksUpPizza();

        // Check values
        Assert.IsNotNull(player.GetPizzaGameObject());
        Assert.IsTrue(player.GetPlayerHasPizza());
        Assert.IsNotNull(player.GetInventory());
        Assert.AreEqual(player.GetPizzaGameObject().transform.parent, player.GetInventory().transform);
    }
}
