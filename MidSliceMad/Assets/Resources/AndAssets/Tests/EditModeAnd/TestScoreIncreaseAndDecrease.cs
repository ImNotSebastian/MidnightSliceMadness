using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;

public class TestScoreIncreaseAndDecrease
{
    [Test]
    public void TestScoreIncreaseAndUpdate()
    {
        var gameManager = GameManager.instance;
        gameManager._gameState.Score = 0;

        gameManager.IncreaseScore(10);

        // Check values
        Assert.AreEqual(10, gameManager._gameState.Score);
        Assert.AreEqual("Score: 10", gameManager.scoreText.text);
    }

    [Test]
    public void TestScoreDecrease()
    {
        var gameManager = GameManager.instance;
        gameManager._gameState.Score = 20;

        gameManager.DecreaseScore(5);

        // Check values
        Assert.AreEqual(15, gameManager._gameState.Score);
        Assert.AreEqual("Score: 15", gameManager.scoreText.text);
    }
}