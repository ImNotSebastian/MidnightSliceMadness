using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class DestroyPizzaTestsPlayModeAnd
{
   [UnityTest]
   public IEnumerator PizzaPrefabDestroyedWhenDelivered()
   {
      // Arrange
      yield return EditorSceneManager.LoadSceneAsyncInPlayMode("Assets/Scenes/TutorialLevel.unity", new LoadSceneParameters(LoadSceneMode.Single));
      
      //Player player = new GameObject().AddComponent<Player>();
      Player player = GameObject.FindObjectOfType<Player>();
      //player.Start();
      player.GenerateAndPlayerPicksUpPizza();
      //GameObject pizzaObject = player.pizzaObject;


      // Act

      //Debug.Log("GetPlayerHasPizzaBefore" + player.GetPlayerHasPizza()); 

      player.DeliverPizza(); // Deliver the pizza

      //yield return null; // Wait for a frame to allow for destruction

      // Debug

      //Debug.Log("GetPlayerHasPizzaAfter" + player.GetPlayerHasPizza());      

      // Assert

      //Debug.Log("GetPizzaBefore" + player.GetPizzaObject());

      Assert.IsNull(player.GetPizzaGameObject(), "Pizza Prefab should be destroyed");
      
      //Debug.Log("GetPizzaAfter" + player.GetPizzaObject());

      Assert.IsFalse(player.GetPlayerHasPizza(), "playerHasPizza should be false after delivering pizza");
   
      yield return null;
   }
}