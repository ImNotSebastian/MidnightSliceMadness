using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class VehicleFactory : MonoBehaviour
{
    [SerializeField] private GameObject[] vehiclePrefabs;

    private GameObject currentVehicle;

    void Awake()
    {
        Transform parent = transform.parent;

        // Initial creation of the first vehicle at the origin with no rotation
        currentVehicle = FindObjectOfType<VehicleController>().gameObject;
    }

    // Example method to demonstrate usage
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // Check if the user pressed 1
        {
            CreateVehicle(0); // Bicycle
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) // Check if the user pressed 2
        {
            CreateVehicle(1); // Motorcycle
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) // Check if the user pressed 3
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

            Player newPlayerScript = newVehicle.GetComponent<Player>();
            Player currentPlayerScript = currentVehicle.GetComponent<Player>();

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
