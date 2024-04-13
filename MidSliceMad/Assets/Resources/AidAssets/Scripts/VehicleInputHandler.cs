/*
Name: Aiden Shepard
Role: Team Lead 3 -- QA Manager
Project: Midnight Slice Madness

This file records the player's input for the vehicle
and then sends the information to VehicleController to move the player
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleInputHandler : MonoBehaviour
{
    // Components
    private VehicleController vehicleController;

    // Awake is called when the script is being loaded
    void Awake()
    {
        vehicleController = GetComponent<VehicleController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = Vector2.zero;

        // Records player's input
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        vehicleController.SetInputVector(inputVector);
    }
}
