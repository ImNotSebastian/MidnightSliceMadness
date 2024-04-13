using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestMushroomPizzaProperties
{
    [Test]
    public void TestMushroomPizzaPropertiesAreCorrect()
    {
        var mushroomPizza = new MushroomPizza();

        // Check values
        Assert.AreEqual(3, mushroomPizza.GetPizzaType());
        Assert.AreEqual("AndAssets/Prefabs/MushroomPizzaPrefab", mushroomPizza.GetPrefabAssetPath());
        Assert.AreEqual(15f, mushroomPizza.GetPizzaDeliveryTime());
        Assert.AreEqual(30, mushroomPizza.GetScoreUponDelivery());
        Assert.AreEqual(20, mushroomPizza.GetScorePenalty());
    }
}
