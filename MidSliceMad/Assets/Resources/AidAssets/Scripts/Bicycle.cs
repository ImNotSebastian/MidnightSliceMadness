/*
Name: Aiden Shepard
Role: Team Lead 3 -- QA Manager
Project: Midnight Slice Madness

This file is the subclass Bicycle to the 
general VehicleController script
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bicycle : VehicleController
{
    // Allows turning in place
    public override void ApplySteering()
    {
        // Update the rotation angle based on input
        rotationAngle -= steeringInput * turnFactor;

        // Apply steering by rotation the bicycle
        vehicleRigidBody2D.MoveRotation(rotationAngle);
    }
}
