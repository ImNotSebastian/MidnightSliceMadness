using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bicycle : VehicleController
{
    public override void ApplySteering()
    {
        // Update the rotation angle based on input
        rotationAngle -= steeringInput * turnFactor;

        // Apply steering by rotation the bicycle
        vehicleRigidBody2D.MoveRotation(rotationAngle);
    }
}
