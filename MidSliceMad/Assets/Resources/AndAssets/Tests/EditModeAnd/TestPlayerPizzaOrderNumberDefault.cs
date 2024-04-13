using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestPlayerPizzaOrderNumberDefault
{
    [Test]
    public void TestPlayerPizzaOrderNumberIsDefaultedToZero()
    {
        var player = new Player();

        // Check values
        Assert.AreEqual(0, player.GetPizzaOrderNumber());
    }
}
