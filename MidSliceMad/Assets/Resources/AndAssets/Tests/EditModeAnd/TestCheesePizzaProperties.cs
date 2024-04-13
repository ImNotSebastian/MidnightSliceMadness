using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestCheesePizzaProperties
{
    [Test]
    public void TestCheesePizzaPropertiesAreCorrect()
    {
        var cheesePizza = new CheesePizza();

        // Check values
        Assert.AreEqual(1, cheesePizza.GetPizzaType());
        Assert.AreEqual("AndAssets/Prefabs/CheesePizzaPrefab", cheesePizza.GetPrefabAssetPath());
        Assert.AreEqual(60f, cheesePizza.GetPizzaDeliveryTime());
        Assert.AreEqual(10, cheesePizza.GetScoreUponDelivery());
        Assert.AreEqual(5, cheesePizza.GetScorePenalty());
    }
}
