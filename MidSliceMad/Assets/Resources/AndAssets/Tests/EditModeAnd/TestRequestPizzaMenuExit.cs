using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestRequestPizzaMenuExit
{
    [Test]
    public void TestRequestPizzaMenuIsHidden()
    {
        var requestPizzaMenu = new RequestPizzaMenu();
        requestPizzaMenu.requestPizzaMenuUI = new GameObject("RequestPizzaMenuUI");

        requestPizzaMenu.OnExitClicked();

        // Check values
        Assert.IsFalse(requestPizzaMenu.requestPizzaMenuUI.activeSelf);
        Assert.AreEqual(1f, Time.timeScale);
    }
}
