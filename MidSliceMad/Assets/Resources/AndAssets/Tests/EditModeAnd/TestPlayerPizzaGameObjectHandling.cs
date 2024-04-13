using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestPlayerPizzaGameObjectHandling
{
    [Test]
    public void TestPlayerPizzaGameObjectAndInventoryHandling()
    {
        var player = new Player();
        player.SetPizzaGameObject(new GameObject("PizzaObject"));

        var pizzaGameObject = player.GetPizzaGameObject();
        var inventory = player.GetInventory();

        // Check values
        Assert.AreEqual(player.GetPizzaGameObject(), pizzaGameObject);
        Assert.IsNotNull(inventory);
    }
}
