using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestPizzaDeliveryTimerResetOnNewPizza
{
    [Test]
    public void TestPizzaDeliveryTimerResetsWhenNewPizzaIsPickedUp()
    {
        var player = new Player();
        player.SetCurrentPizzaObject(new CrudePizza());
        GameManager.instance._gameState.TimeLeft = 30f;
        GameManager.instance._gameState.PizzaDeliveryOngoing = true;

        player.GenerateAndPlayerPicksUpPizza();

        // Check values
        Assert.AreEqual(player.GetCurrentPizzaObject().GetPizzaDeliveryTime(), GameManager.instance._gameState.TimeLeft);
        Assert.IsTrue(GameManager.instance._gameState.PizzaDeliveryOngoing);
    }
}
