using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestPlayerPizzaOrderNumberRange
{
    [Test]
    public void TestPlayerPizzaOrderNumberIsWithinValidRange()
    {
        var player = new Player();

        // Check values
        player.SetPlayerPizzaOrderNumber(0);
        Assert.AreEqual(0, player.GetPizzaOrderNumber());

        player.SetPlayerPizzaOrderNumber(1);
        Assert.AreEqual(1, player.GetPizzaOrderNumber());

        player.SetPlayerPizzaOrderNumber(2);
        Assert.AreEqual(2, player.GetPizzaOrderNumber());

        player.SetPlayerPizzaOrderNumber(3);
        Assert.AreEqual(3, player.GetPizzaOrderNumber());

        player.SetPlayerPizzaOrderNumber(4);
        Assert.AreEqual(0, player.GetPizzaOrderNumber());
    }
}
