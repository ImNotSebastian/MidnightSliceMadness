using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   private bool playerHasPizza = false;

   private void OnTriggerEnter2D(Collision2D other)
   {
      if (other.CompareTag("OutPizza") && !playerHasPizza)
      {
         GenerateAndPlayerPicksUpPizza();
      }
      if (other.CompareTag("BlueHouse") && playerHasPizza)
      {
         DeliverPizza();
      }
   }

   private void GenerateAndPlayerPicksUpPizza()
   {
      
      // instantiate a pizza object
      
      GameObject pizzaObject = Instantiate(Resources.Load("AndAssets/Prefabs/PizzaPrefab") as GameObject, transform);
      pizzaObject.GetComponent<Pizza>().enabled = false; // disable Pizza script initially
      playerHasPizza = true;
   }

   private void DeliverPizza()
   {
      
      // remove the pizza object from the player and increment the score 
      
      Destroy(transform.Find("PizzaPrefab").gameObject);
      playerHasPizza = false;
      GameManager.Instance.IncreaseScore();
   }
}
