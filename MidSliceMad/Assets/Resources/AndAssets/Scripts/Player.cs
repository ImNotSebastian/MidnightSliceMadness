///*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   private bool playerHasPizza = false; 
   private GameObject inventory; 
   private GameObject pizzaPrefab;
   private GameObject pizzaObject;

   public void Start()
   {
      // Find the Inventory GameObject in the hierarchy by name
      inventory = GameObject.Find("Inventory");

      if (inventory == null)
      {
         Debug.LogError("Inventory GameObject not found in the hierarchy. Make sure Inventory game object exists.");
      }
   }

   private void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.CompareTag("Pick-Up") && !playerHasPizza)
      {
         GenerateAndPlayerPicksUpPizza();
         //Debug.Log("Pick-Up");
      }
      ///*
      if (other.gameObject.CompareTag("Delivery") && playerHasPizza)
      {
         DeliverPizza();
         //Debug.Log("Delivery");
      }
      //*/
   }

   ///*
   public void GenerateAndPlayerPicksUpPizza()
   { 
      // Get the main camera's transform
      Transform mainCameraTransform = Camera.main.transform;
      if (mainCameraTransform != null)
      {
         // Calculate the position relative to the main camera
         Vector3 offsetFromCamera = new Vector3(7f, -4.25f, 9f); 
         Vector3 spawnPosition = mainCameraTransform.position + mainCameraTransform.forward * offsetFromCamera.z +
                                 mainCameraTransform.right * offsetFromCamera.x +
                                 mainCameraTransform.up * offsetFromCamera.y;

         // Instantiate the PizzaPrefab at the calculated position
         pizzaPrefab = Resources.Load("AndAssets/Prefabs/PizzaPrefab") as GameObject;
         pizzaObject = Instantiate(pizzaPrefab, spawnPosition, Quaternion.identity);
         //Debug.Log("Pizza Created");
        
         inventory = GameObject.Find("Inventory");

         if (inventory != null)
         {
            pizzaObject.transform.SetParent(inventory.transform, false);
            //Debug.Log("Set Inventory as parent");
         }
         
         // Enable Pizza script if needed
         //pizzaObject.GetComponent<Pizza>().enabled = true;

         playerHasPizza = true;
      }
   }
   //*/

   ///*
   private void DeliverPizza()
   {
      
      // remove the pizza object from the player and increment the score 
      
      if (pizzaObject != null)
      {
         Destroy(pizzaObject);
         playerHasPizza = false;
         //GameManager.Instance.IncreaseScore();
         //Debug.Log("Pizza Destroyed");
      }
      else
      {
         Debug.LogWarning("PizzaObject is null or has already been destroyed.");
      }
   }

   public GameObject GetPizzaObject()
   {
      return pizzaObject;
   }

   public GameObject GetInventory()
   {
      inventory = GameObject.Find("Inventory");
      return inventory;
   }

   public void SimulateCollisionWithPickUp()
   {
      if (!playerHasPizza)
      {
         GenerateAndPlayerPicksUpPizza();
         //Debug.Log("Pick-Up");
      }
   }
   //*/
}
//*/
