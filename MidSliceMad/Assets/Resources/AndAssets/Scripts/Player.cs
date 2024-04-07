///*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool playerHasPizza = false;
    [SerializeField] private float spawnPizzaCameraOffsetX = 7f;
    [SerializeField] private float spawnPizzaCameraOffsetY = -4f;
    [SerializeField] private float spawnPizzaCameraOffsetZ = 9f;
    [SerializeField] private int pizzaOrderNumber = 0;
    private GameObject inventory;
    private GameObject pizzaPrefab;
    private GameObject pizzaGameObject; // This is the object that will be instantiated from the prefab in the scene
    private CrudePizza currentPizzaObject; // This is the respective pizza class object

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
            Vector3 offsetFromCamera = new Vector3(spawnPizzaCameraOffsetX, spawnPizzaCameraOffsetY, spawnPizzaCameraOffsetZ);
            Vector3 spawnPosition = mainCameraTransform.position + mainCameraTransform.forward * offsetFromCamera.z +
                                    mainCameraTransform.right * offsetFromCamera.x +
                                    mainCameraTransform.up * offsetFromCamera.y;

            // Instantiate the PizzaPrefab at the calculated position

            switch (pizzaOrderNumber)
            {
                case 0: // same as default
                    currentPizzaObject = new CrudePizza();
                    break;
                case 1:
                    currentPizzaObject = new CheesePizza();
                    break;
                case 2:
                    currentPizzaObject = new OnionPizza();
                    break;
                case 3:
                    currentPizzaObject = new MushroomPizza();
                    break;
                default:
                    currentPizzaObject = new CrudePizza();
                    break;
            }
            pizzaPrefab = Resources.Load(currentPizzaObject.GetPrefabAssetPath()) as GameObject;
            pizzaGameObject = Instantiate(pizzaPrefab, spawnPosition, Quaternion.identity);
            //Debug.Log("Pizza Created");

            inventory = GameObject.Find("Inventory");

            if (inventory != null)
            {
                pizzaGameObject.transform.SetParent(inventory.transform, false);
                //Debug.Log("Set Inventory as parent");
            }

            // Enable Pizza script if needed
            //pizzaGameObject.GetComponent<Pizza>().enabled = true;

            playerHasPizza = true;
        }
    }
    //*/

    ///*
    public void DeliverPizza()
    {

        // remove the pizza object from the player and increment the score 

        if (pizzaGameObject != null)
        {
            Destroy(pizzaGameObject);
            playerHasPizza = false;
            GameManager.instance.IncreaseScore();
            GameManager.instance.DisplayScoreText();
            //Debug.Log("Pizza Destroyed");
        }
        else
        {
            Debug.LogWarning("pizzaGameObject is null or has already been destroyed.");
        }
    }

    public GameObject GetPizzaGameObject()
    {
        if (pizzaGameObject == null)
        {
            return pizzaGameObject;
        }
        else
        {
            return null;
        }
    }

    public GameObject GetInventory()
    {
        inventory = GameObject.Find("Inventory");
        return inventory;
    }

    public bool GetPlayerHasPizza()
    {
        return playerHasPizza;
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
