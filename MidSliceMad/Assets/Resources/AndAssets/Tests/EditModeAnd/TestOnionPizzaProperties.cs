using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestOnionPizzaProperties
{
    [Test]
    public void TestOnionPizzaPropertiesAreCorrect()
    {
        var onionPizza = new OnionPizza();

        // Check values
        Assert.AreEqual(2, onionPizza.GetPizzaType());
        Assert.AreEqual("AndAssets/Prefabs/OnionPizzaPrefab", onionPizza.GetPrefabAssetPath());
        Assert.AreEqual(30f, onionPizza.GetPizzaDeliveryTime());
        Assert.AreEqual(20, onionPizza.GetScoreUponDelivery());
        Assert.AreEqual(10, onionPizza.GetScorePenalty());
    }
}
