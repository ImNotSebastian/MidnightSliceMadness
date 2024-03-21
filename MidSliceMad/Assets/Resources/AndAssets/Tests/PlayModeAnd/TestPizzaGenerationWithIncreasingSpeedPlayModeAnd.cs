using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class PizzaGenerationPlayModeTest
{
   [UnityTest]
   public IEnumerator TestPizzaGenerationWithIncreasingSpeed()
   {
      // Load the test scene
      yield return EditorSceneManager.LoadSceneAsyncInPlayMode("Assets/Scenes/TutorialLevel.unity", new LoadSceneParameters(LoadSceneMode.Single));

      
      // Get references to Player and BicycleController components
      Player player = GameObject.FindObjectOfType<Player>();
      BicycleController bicycleController = GameObject.FindObjectOfType<BicycleController>();
      
      /*
      // Create a new GameObject to represent the collision object
      GameObject collisionObject = new GameObject("CollisionObject");
      collisionObject.tag = "Pick-Up";

      // Add a Collider2D component to the collision object
      Collider2D collider = collisionObject.AddComponent<BoxCollider2D>();

      // Create a new Collision2D object and set the collider as the other collider in the collision
      Collision2D collision = new Collision2D();
      collision.gameObject = collisionObject;
      //*/

      // Initial speed for player collision
      float playerSpeed = 1.0f;

      // Loop to double player speed and check pizza generation
      while (playerSpeed < 1000.0f) // Adjust upper limit as needed
      {
         // Set player speed for collision
         bicycleController.SetMaxSpeed(playerSpeed);

         // Simulate collision with "Pick-Up" object
         //player.OnCollisionEnter2D(collision); // Simulate collision
         // Simulate collision with "Pick-Up" object by calling a method in Player class
         player.SimulateCollisionWithPickUp();

         // Check if pizza prefab is instantiated
         Assert.IsNotNull(player.GetPizzaObject(), "Pizza prefab not instantiated at speed: " + playerSpeed);

         // Double the player speed for next iteration
         playerSpeed *= 2.0f;
            
         // Message Player Speed on collision
         //Debug.Log("Player Speed:" + playerSpeed);

         //yield return null; // Wait for next frame
      }
   }
}