using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestPlayerSimulatePickUp
{
    [Test]
    public void TestPlayerPicksUpPizzaWhenNoneHeld()
    {
        var player = new Player();
        player.SetPlayerHasPizza(false);

        player.SimulateCollisionWithPickUp();

        // Check values
        Assert.AreEqual(player.GetCurrentPizzaObject().GetPizzaDeliveryTime(), GameManager.instance._gameState.TimeLeft);
        Assert.IsTrue(player.GetPlayerHasPizza());
    }
}
