using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestPlayerPizzaDelivery
{
    [Test]
    public void TestPlayerDeliversPizza()
    {
        var player = new Player();
        var gameManager = GameManager.instance;
        gameManager._player = player;
        
        //player.SetCurrentPizzaObject(new CrudePizza());
        //var spawnPosition = (0f,0f,0f);
        //var pizzaPrefab = Resources.Load(player.currentPizzaObject.GetPrefabAssetPath()) as GameObject;
        // var spawnPizzaCameraOffsetX = 7f;
        // var spawnPizzaCameraOffsetY = -4f;
        // var spawnPizzaCameraOffsetZ = 9f;
        // Vector3 offsetFromCamera = new Vector3(spawnPizzaCameraOffsetX, spawnPizzaCameraOffsetY, spawnPizzaCameraOffsetZ);
        //pizzaGameObject = Instantiate(pizzaPrefab, spawnPosition, Quaternion.identity);
        //player.SetPizzaGameObject(new GameObject("PizzaObject"));
        //player.SetPlayerHasPizza(true);

        player.GenerateAndPlayerPicksUpPizza();

        player.DeliverPizza();

        // Check values
        Assert.IsNull(player.GetPizzaGameObject());
        Assert.IsFalse(player.GetPlayerHasPizza());
        Assert.AreEqual(10, gameManager._gameState.Score);
        Assert.AreEqual("Score: 10", gameManager.scoreText.text);
        Assert.AreEqual(0f, gameManager._gameState.TimeLeft);
        Assert.IsFalse(gameManager._gameState.PizzaDeliveryOngoing);
    }
}
