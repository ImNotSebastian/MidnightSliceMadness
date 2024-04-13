using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestRequestPizzaMenuCheesePizza
{
    [Test]
    public void TestCheesePizzaIsOrderedAndPickedUp()
    {
        var requestPizzaMenu = new RequestPizzaMenu();
        var player = new Player();
        requestPizzaMenu.player = player;
        requestPizzaMenu.cheesePizzaObject = new CheesePizza();
        requestPizzaMenu.requestPizzaMenuUI = new GameObject("RequestPizzaMenuUI");

        requestPizzaMenu.OnCheesePizzaClicked();

        // Check values
        Assert.AreEqual(1, player.GetPizzaOrderNumber());
        Assert.IsTrue(player.GetPlayerHasPizza());
        Assert.IsFalse(requestPizzaMenu.requestPizzaMenuUI.activeSelf);
        Assert.AreEqual(1f, Time.timeScale);
    }
}
