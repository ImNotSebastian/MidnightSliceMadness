using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestGameManagerInstance
{
    [Test]
    public void TestGameManagerInstanceIsAccessible()
    {
        Assert.IsNotNull(GameManager.instance);

        var gameManager = GameManager.instance;

        // Check values
        Assert.IsNotNull(gameManager);
        Assert.AreEqual(gameManager, GameManager.instance);
    }
}
