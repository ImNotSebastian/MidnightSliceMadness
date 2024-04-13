using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestRequestPizzaMenuOnionPizza
{
    [Test]
    public void TestOnionPizzaIsOrderedAndPickedUp()
    {
        var requestPizzaMenu = new RequestPizzaMenu();
        var player = new Player();
        requestPizzaMenu.player = player;
        requestPizzaMenu.onionPizzaObject = new OnionPizza();
        requestPizzaMenu.requestPizzaMenuUI = new GameObject("RequestPizzaMenuUI");

        requestPizzaMenu.OnOnionPizzaClicked();

        // Check values
        Assert.AreEqual(2, player.GetPizzaOrderNumber());
        Assert.IsTrue(player.GetPlayerHasPizza());
        Assert.IsFalse(requestPizzaMenu.requestPizzaMenuUI.activeSelf);
        Assert.AreEqual(1f, Time.timeScale);
    }
}
