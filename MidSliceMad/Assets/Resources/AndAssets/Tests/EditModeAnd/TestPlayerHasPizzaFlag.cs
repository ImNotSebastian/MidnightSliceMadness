using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestPlayerHasPizzaFlag
{
    [Test]
    public void TestPlayerPizzaPossessionState()
    {
        var player = new Player();

        player.SetPlayerHasPizza(true);

        // Check values
        Assert.IsTrue(player.GetPlayerHasPizza());

        player.SetPlayerHasPizza(false);
        Assert.IsFalse(player.GetPlayerHasPizza());
    }
}
