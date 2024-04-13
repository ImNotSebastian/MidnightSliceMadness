using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestCrudePizzaProperties
{
    [Test]
    public void TestCrudePizzaDefaultProperties()
    {
        var crudePizza = new CrudePizza();

        // Check values
        Assert.AreEqual(0, crudePizza.GetPizzaType());
        Assert.AreEqual("AndAssets/Prefabs/CrudePizzaPrefab", crudePizza.GetPrefabAssetPath());
        Assert.AreEqual(100f, crudePizza.GetPizzaDeliveryTime());
        Assert.AreEqual(10, crudePizza.GetScoreUponDelivery());
        Assert.AreEqual(5, crudePizza.GetScorePenalty());
    }
}
