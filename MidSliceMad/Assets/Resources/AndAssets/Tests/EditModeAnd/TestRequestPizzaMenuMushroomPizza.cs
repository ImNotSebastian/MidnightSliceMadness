using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestRequestPizzaMenuMushroomPizza
{
    [Test]
    public void TestMushroomPizzaIsOrderedAndPickedUp()
    {
        var requestPizzaMenu = new RequestPizzaMenu();
        var player = new Player();
        requestPizzaMenu.player = player;
        requestPizzaMenu.mushroomPizzaObject = new MushroomPizza();
        requestPizzaMenu.requestPizzaMenuUI = new GameObject("RequestPizzaMenuUI");

        requestPizzaMenu.OnMushroomPizzaClicked();

        // Check values
        Assert.AreEqual(3, player.GetPizzaOrderNumber());
        Assert.IsTrue(player.GetPlayerHasPizza());
        Assert.IsFalse(requestPizzaMenu.requestPizzaMenuUI.activeSelf);
        Assert.AreEqual(1f, Time.timeScale);
    }
}
