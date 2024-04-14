using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestRequestPizzaMenuShow
{
    [Test]
    public void TestRequestPizzaMenuIsShown()
    {
        var requestPizzaMenu = new RequestPizzaMenu();
        requestPizzaMenu.requestPizzaMenuUI = new GameObject("RequestPizzaMenuUI");

        requestPizzaMenu.ShowRequestPizzaMenu();

        // Check values
        Assert.IsTrue(requestPizzaMenu.requestPizzaMenuUI.activeSelf);
        Assert.AreEqual(0f, Time.timeScale);
    }
}
