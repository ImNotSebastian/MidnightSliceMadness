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
        var gameManager = new GameManager();
        gameManager.scoreText = new TextMeshProUGUI();

        gameManager.IncreaseScore(10);

        // Check values
        Assert.AreEqual(10, gameManager._gameState.Score);
        Assert.AreEqual("Score: 10", gameManager.scoreText.text);
    }

    [Test]
    public void TestScoreDecrease()
    {
        // Arrange
        var gameManager = new GameManager();
        gameManager.scoreText = new TextMeshProUGUI();
        gameManager._gameState.Score = 20;

        // Act
        gameManager.DecreaseScore(5);

        // Assert
        Assert.AreEqual(15, gameManager._gameState.Score);
        Assert.AreEqual("Score: 15", gameManager.scoreText.text);
    }
}