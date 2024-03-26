/*
Name: Aiden Shepard
Role: Team Lead 3 -- QA Manager
Project: Midnight Slice Madness

This file records the player's input for the bicycle 
and then sends the information to BicycleController to move the player
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BicycleInputHandler : MonoBehaviour
{
    // Components
    private BicycleController BicycleController;

    // Awake is called when the script is being loaded
    void Awake()
    {
        BicycleController = GetComponent<BicycleController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = Vector2.zero;

        // Records player's input
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        BicycleController.SetInputVector(inputVector);
    }
}
