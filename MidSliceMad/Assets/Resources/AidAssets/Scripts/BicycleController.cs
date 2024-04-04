/*
Name: Aiden Shepard
Role: Team Lead 3 -- QA Manager
Project: Midnight Slice Madness

This file performs physics calculations to accelerate the bicycle 
while capping the acceleration at a max speed and eliminated side
velocity so it feels accurate to the handling of a bicycle
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BicycleController : MonoBehaviour
{
    // Private Variables
    [SerializeField] private BicycleAnimation bicycleAnimation;

    [SerializeField] private float driftFactor;
    [SerializeField] private float accelerationFactor;
    [SerializeField] private float turnFactor;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float reverseSpeed;

    // Local Variables
    private float accelerationInput = 0;
    private float steeringInput = 0;

    private float rotationAngle = 0;

    private float velocityVsUp = 0;

    // Components
    private Rigidbody2D carRigidBody2D;

    // Awake is called when the script is being loaded
    private void Awake()
    {
        carRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Frame-rate independent for phsyics calculations.
    private void FixedUpdate()
    {
        ApplyPeddleForce();

        RemoveSideVelocity();

        ApplySteering();

        SetSpriteOnRotation();
    }

    // Calculates and applies the different forces for the bicycle based on the accelerationInput
    private void ApplyPeddleForce()
    {
        // Calculate forward velocity
        velocityVsUp = Vector2.Dot(transform.up, carRigidBody2D.velocity);

        // Limit so we can't go faster than the max speed in the forward direction
        if((velocityVsUp > maxSpeed) && (accelerationInput > 0))
        {
            return;
        }

        // Limit so we can't go faster than reverseSpeed percentage of the max speed in the reverse direction
        if((velocityVsUp < (-maxSpeed * reverseSpeed)) && (accelerationInput < 0))
        {
            return;
        }

        // Limit so we can't go faster in any direction (generally side) while accelerating
        if((carRigidBody2D.velocity.sqrMagnitude > (maxSpeed * maxSpeed)) && (accelerationInput > 0))
        {
            return;
        }

        // Apply drag if there is no accelerationInput so bike slows down without input
        if(accelerationInput ==  0)
        {
            carRigidBody2D.drag = Mathf.Lerp(carRigidBody2D.drag, 3.0f, Time.fixedDeltaTime * 3);
        }
        else
        {
            carRigidBody2D.drag = 0;
        }

        // Create a force
        Vector2 peddleForceVector = transform.up * accelerationInput * accelerationFactor;

        // Apply force and push bicycle forward
        carRigidBody2D.AddForce(peddleForceVector, ForceMode2D.Force);
    }

    // Rotates the bicycle based upon the steeringInput
    private void ApplySteering()
    {
        // Update the rotation angle based on input
        rotationAngle -= steeringInput * turnFactor;

        // Apply steering by rotation the bicycle
        carRigidBody2D.MoveRotation(rotationAngle);
    }    

    // Eliminates side velocity so the bicycle responds more accurately and less like a space ship
    private void RemoveSideVelocity()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(carRigidBody2D.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(carRigidBody2D.velocity, transform.right);

        carRigidBody2D.velocity = forwardVelocity + rightVelocity * driftFactor;
    }

    // Changes the sprite based on it's rotation as a placeholder for future sprite update
    private void SetSpriteOnRotation()
    {
        Vector3 rotation = transform.eulerAngles;
        float angle = rotation.z % 360;

        if ((angle > 337.5) || (angle < 22.5))          // Up Direction
        {
            bicycleAnimation.ChangeAnimation(0);
        }
        else if ((angle > 22.5) && (angle < 67.5))      // Up-Left Direction
        {
            bicycleAnimation.ChangeAnimation(1);
        }
        else if ((angle > 67.5) && (angle < 112.5))     // Left Direction
        {
            bicycleAnimation.ChangeAnimation(2);
        }
        else if ((angle > 112.5) && (angle < 157.5))    // Down-Left Direction      
        {
            bicycleAnimation.ChangeAnimation(3);
        }
        else if ((angle > 157.5) && (angle < 202.5))    // Down Direction
        {
            bicycleAnimation.ChangeAnimation(4);
        }
        else if ((angle > 202.5) && (angle < 247.5))    // Down-Right Direction
        {
            bicycleAnimation.ChangeAnimation(5);
        }
        else if ((angle > 247.5) && (angle < 292.5))    // Right Direction
        {
            bicycleAnimation.ChangeAnimation(6);
        }
        else if ((angle > 292.5) && (angle < 337.5))    // Up-Right Direction
        {
            bicycleAnimation.ChangeAnimation(7);
        }
    }

    // Sets steeringInput and accelerationInput based off the input vector values
    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;
    }

    // Sets the maxSpeed to the input variable newSpeed
    public void SetMaxSpeed(float newSpeed)
    {
        maxSpeed = newSpeed;
    }

    // Returns the float maxSpeed
    public float GetMaxSpeed()
    {
        return maxSpeed;
    }
}
