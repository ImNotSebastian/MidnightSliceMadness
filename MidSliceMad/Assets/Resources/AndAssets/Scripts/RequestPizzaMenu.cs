/*
Name: Andrew Plum
Role: Team Lead 4 -- Project Manager
Project: Midnight Slice Madness
This file contains the definition for the RequestPizzaMenu Class
This class is used to manage the player interactions of the pizza ordering menu
It inherits from MonoBehaviour
*/

///*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestPizzaMenu : MonoBehaviour
{
    private Player player;
    // These pizza object variables are unecessary if I create a PizzaInfoManager class object
    private CrudePizza crudePizzaObject; 
    private CheesePizza cheesePizzaObject;
    private OnionPizza onionPizzaObject;
    private MushroomPizza mushroomPizzaObject;
    // End of last comment
    [SerializeField] private GameObject requestPizzaMenuUI;

    private void Start()
    {

        // Find player and activate request menu functionality

        player = FindObjectOfType<Player>();
        requestPizzaMenuUI.SetActive(false); // Hide the pop-up menu initially

        // Pizza Initializations

        crudePizzaObject = new CrudePizza();
        cheesePizzaObject = new CheesePizza();
        onionPizzaObject = new OnionPizza();
        mushroomPizzaObject = new MushroomPizza();

    }

    public void ShowRequestPizzaMenu()
    {
        Time.timeScale = 0f;
        requestPizzaMenuUI.SetActive(true); // Show the pop-up menu
    }

    public void OnCheesePizzaClicked()
    {
        player.SetPlayerPizzaOrderNumber(cheesePizzaObject.GetPizzaType());
        //player.SetPlayerPizzaOrderNumber(1);
        player.GenerateAndPlayerPicksUpPizza();
        requestPizzaMenuUI.SetActive(false); // Hide the pop-up menu
        Time.timeScale = 1f;
    }

    public void OnOnionPizzaClicked()
    {
        player.SetPlayerPizzaOrderNumber(onionPizzaObject.GetPizzaType());
        //player.SetPlayerPizzaOrderNumber(2);
        player.GenerateAndPlayerPicksUpPizza();
        requestPizzaMenuUI.SetActive(false); // Hide the pop-up menu
        Time.timeScale = 1f;
    }

    public void OnMushroomPizzaClicked()
    {
        player.SetPlayerPizzaOrderNumber(mushroomPizzaObject.GetPizzaType());
        //player.SetPlayerPizzaOrderNumber(3);
        player.GenerateAndPlayerPicksUpPizza();
        requestPizzaMenuUI.SetActive(false); // Hide the pop-up menu
        Time.timeScale = 1f;
    }

    public void OnExitClicked()
    {
        requestPizzaMenuUI.SetActive(false); // Hide the pop-up menu
        Time.timeScale = 1f;
    }
}
//*/