/*
Name: Aiden Shepard
Role: Team Lead 3 -- QA Manager
Project: Midnight Slice Madness

This file manages the construction and destruction of
the VehicleController gameObject while adherering to
the FactoryPattern design implementation
*/

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class VehicleFactory : MonoBehaviour
{
    // Types of Vehicles
    [SerializeField] private GameObject[] vehiclePrefabs;

    private GameObject currentVehicle;

    void Awake()
    {
        Transform parent = transform.parent;

        // Gets Initial first vehicle 
        currentVehicle = FindObjectOfType<VehicleController>().gameObject;
    }

    // Example method to demonstrate usage
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // Check if the user pressed the "1" key
        {
            CreateVehicle(0); // Bicycle
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) // Check if the user pressed the "2" key
        {
            CreateVehicle(1); // Motorcycle
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) // Check if the user pressed the "3" key
        {
            CreateVehicle(2); // Car
        }
    }

    // Method to create vehicle based on user input
    public void CreateVehicle(int userInput)
    {
        if (userInput >= 0 && userInput < vehiclePrefabs.Length) // Checking if userInput is within bounds
        {
            Transform parent = transform.parent;

            // Instantiating the selected prefab with the position and rotation of the previous vehicle
            GameObject newVehicle = Instantiate(vehiclePrefabs[userInput], parent);

            // Gets Player script component from new and current
            Player newPlayerScript = newVehicle.GetComponent<Player>();
            Player currentPlayerScript = currentVehicle.GetComponent<Player>();

            // Sets the new vehicle to have the same quest status as the current
            newPlayerScript.SetPlayerHasPizza(currentPlayerScript.GetPlayerHasPizza());
            newPlayerScript.SetPizzaGameObject(currentPlayerScript.GetPizzaGameObject());
            newPlayerScript.SetCurrentPizzaObject(currentPlayerScript.GetCurrentPizzaObject());

            // Removing the previous vehicle
            Destroy(currentVehicle);

            // Updating the reference to the current vehicle
            currentVehicle = newVehicle;
        }
        else
        {
            Debug.LogError("Invalid input! Please input a number between 1 and " + vehiclePrefabs.Length);
        }
    }
}
