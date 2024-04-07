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
        player = FindObjectOfType<Player>();
        requestPizzaMenuUI.SetActive(false); // Hide the pop-up menu initially
    }

    public void OnCheesePizzaClicked()
    {
        //player.SetPlayerPizzaOrderNumber(cheesePizzaObject.GetPizzaType());
        player.SetPlayerPizzaOrderNumber(1);
        player.GenerateAndPlayerPicksUpPizza();
        requestPizzaMenuUI.SetActive(false); // Hide the pop-up menu
    }

    public void OnOnionPizzaClicked()
    {
        //player.SetPlayerPizzaOrderNumber(onionPizzaObject.GetPizzaType());
        player.SetPlayerPizzaOrderNumber(2);
        player.GenerateAndPlayerPicksUpPizza();
        requestPizzaMenuUI.SetActive(false); // Hide the pop-up menu
    }

    public void OnMushroomPizzaClicked()
    {
        //player.SetPlayerPizzaOrderNumber(mushroomPizzaObject.GetPizzaType());
        player.SetPlayerPizzaOrderNumber(3);
        player.GenerateAndPlayerPicksUpPizza();
        requestPizzaMenuUI.SetActive(false); // Hide the pop-up menu
    }

    public void OnExitClicked()
    {
        requestPizzaMenuUI.SetActive(false); // Hide the pop-up menu
    }
}
//*/