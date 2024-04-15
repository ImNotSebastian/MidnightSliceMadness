using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestPizzaDeliveryTimerPersistence
{
    [Test]
    public void TestPizzaDeliveryTimerPersistsAcrossPizzaOrders()
    {
        var player = new Player();
        //player.SetCurrentPizzaObject(new CrudePizza());
        CrudePizza cheesePizza = new CheesePizza(); // Cheese Pizza time should currently be 60f
        GameManager.instance._gameState.TimeLeft = 30f;
        GameManager.instance._gameState.PizzaDeliveryOngoing = true;

        player.SetPlayerPizzaOrderNumber(1);
        player.GenerateAndPlayerPicksUpPizza();

        // Check values
        Assert.AreEqual(cheesePizza.GetPizzaDeliveryTime(), GameManager.instance._gameState.TimeLeft);
        Assert.IsTrue(GameManager.instance._gameState.PizzaDeliveryOngoing);
    }
}
