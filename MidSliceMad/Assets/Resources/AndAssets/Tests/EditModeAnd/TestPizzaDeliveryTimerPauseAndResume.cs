using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestPizzaDeliveryTimerPauseAndResume
{
    [Test]
    public void TestPizzaDeliveryTimerPausesAndResumesWithRequestMenu()
    {
        var requestPizzaMenu = new RequestPizzaMenu();
        requestPizzaMenu.requestPizzaMenuUI = new GameObject("RequestPizzaMenuUI");

        requestPizzaMenu.ShowRequestPizzaMenu();

        // Check values
        Assert.AreEqual(0f, Time.timeScale);

        requestPizzaMenu.OnExitClicked();

        // Check values
        Assert.AreEqual(1f, Time.timeScale);
    }
}
