/*
Name: Aiden Shepard
Role: Team Lead 3 -- QA Manager
Project: Midnight Slice Madness

This file sets the input for the player to move forward in a straight line
then automatically increase the speed each time it collides with a wall
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollisionScript : MonoBehaviour
{
    [SerializeField] private TMP_Text speedText;

    // Components
    private VehicleController vehicleController;
    private float inputSpeed;

    // Awake is called when the script is being loaded
    void Awake()
    {
        vehicleController = GetComponent<VehicleController>();
        inputSpeed = 1;
        speedText.text = "Max Speed: " + vehicleController.GetMaxSpeed().ToString();        
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 objectPosition = transform.position;

        /*
        If position surpasses the wall then keep forward input
        otherwise changes the text to reflect the breakpoint has been found
        */ 
        if (objectPosition.y < 4)
        {
            vehicleController.SetInputVector(new Vector2(0, inputSpeed));
        }
        else
        {
            vehicleController.SetInputVector(Vector2.zero);
            speedText.text = "Max Speed Breakpoint: " + vehicleController.GetMaxSpeed().ToString();
        }
    }

    // Resets bicycle to starting position and then doubles speed when it hits the wall
    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.position = new Vector3(0, -4, 0);
        vehicleController.SetMaxSpeed(vehicleController.GetMaxSpeed() * 2);
        inputSpeed *= 2;

        speedText.text = "Max Speed: " + vehicleController.GetMaxSpeed().ToString();
    }
}
