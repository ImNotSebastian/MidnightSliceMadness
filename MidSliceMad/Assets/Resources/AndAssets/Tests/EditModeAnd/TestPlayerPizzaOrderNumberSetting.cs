///*
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestPlayerPizzaOrderNumberSetting
{
    [Test]
    public void TestPlayerPizzaOrderNumberIsSet()
    {
        var player = new Player();

        player.SetPlayerPizzaOrderNumber(2);

        // Check values
        Assert.AreEqual(2, player.GetPizzaOrderNumber());
    }
}
//*/