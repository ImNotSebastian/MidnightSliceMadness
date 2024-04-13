/*
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestRequestPizzaMenuInitialization
{
    [Test]
    public void TestRequestPizzaMenuIsInitializedCorrectly()
    {
        var requestPizzaMenu = new RequestPizzaMenu();
        requestPizzaMenu.player = new Player();
        requestPizzaMenu.requestPizzaMenuUI = new GameObject("RequestPizzaMenuUI");

        requestPizzaMenu.Initialize();

        // Check values
        Assert.IsNotNull(requestPizzaMenu.crudePizzaObject);
        Assert.IsNotNull(requestPizzaMenu.cheesePizzaObject);
        Assert.IsNotNull(requestPizzaMenu.onionPizzaObject);
        Assert.IsNotNull(requestPizzaMenu.mushroomPizzaObject);
        Assert.IsFalse(requestPizzaMenu.requestPizzaMenuUI.activeSelf);
    }
}
//*/