using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class InventoryTests
{
   [UnityTest]
   public IEnumerator TestPizzaSpawnPosition()
   {
      //Debug.Log("Test");
      yield return EditorSceneManager.LoadSceneAsyncInPlayMode("Assets/Scenes/TutorialLevel.unity", new LoadSceneParameters(LoadSceneMode.Single));

      //Player player = new GameObject().AddComponent<Player>();
      Player player = GameObject.FindObjectOfType<Player>();
      //Debug.Log("Player");

      // Create an Inventory GameObject for testing
      //new GameObject("Inventory");
      //Debug.Log("Inventory");

      /*
      // Create a mock camera object for testing
      GameObject mockCamera = new GameObject("MockCamera");
      Camera mockCameraComponent = mockCamera.AddComponent<Camera>();
      mockCameraComponent = Camera.main;
      //*/

      player.Start();
      //Debug.Log("Start");
      // Instantiate the pizza prefab
      player.GenerateAndPlayerPicksUpPizza();
      //Debug.Log("Generate and player picks up pizza");
      // Assert that the calculated spawn position matches the expected vector

      Vector3 pizzaPosition = player.GetPizzaObject().transform.position;
      Vector3 cameraPosition = Camera.main.transform.position;
      Vector3 playerSystem = GameObject.Find("PlayerSystem").transform.position;
      Vector3 offsetFromCamera = pizzaPosition - cameraPosition - playerSystem; // Calculate the offset vector from the camera to the pizza object
      //Debug.Log("Pizza position:" + pizzaPosition);
      //Debug.Log("Camera position:" + cameraPosition);
      //Debug.Log("Player system position:" + playerSystem);
      //Debug.Log("Inventory offset from camera:" + offsetFromCamera);
      Assert.AreEqual(new Vector3(7f, -4.25f, 9f), offsetFromCamera);
   }
}