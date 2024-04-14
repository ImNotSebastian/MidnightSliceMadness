/*
Name: Aiden Shepard
Role: Team Lead 3 -- QA Manager
Project: Midnight Slice Madness

This file performs physics calculations to accelerate the vehicle
while capping the acceleration at a max speed and eliminated side
velocity so it feels accurate
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    // Private Variables
    [SerializeField] private Semi3DAnimation vehicleAnimation;

    [SerializeField] protected float driftFactor;
    [SerializeField] protected float accelerationFactor;
    [SerializeField] protected float turnFactor;
    [SerializeField] protected float maxSpeed;
    [SerializeField] protected float reverseSpeed;
    [SerializeField] protected float turningDifficulty;

    // Local Variables
    protected float accelerationInput = 0;
    protected float steeringInput = 1;

    protected float rotationAngle = 0;

    protected float velocityVsUp = 0;

    // Components
    protected Rigidbody2D vehicleRigidBody2D;
    CarSurfaceHandler carSurfaceHandler;

    // Awake is called when the script is being loaded
    private void Awake()
    {
        vehicleRigidBody2D = GetComponent<Rigidbody2D>();
        carSurfaceHandler = GetComponent<CarSurfaceHandler>();
    }

    // Frame-rate independent for phsyics calculations.
    private void FixedUpdate()
    {
        ApplyEngineForce();

        RemoveSideVelocity();

        ApplySteering();

        SetSpriteOnRotation();
    }

    // Calculates and applies the different forces for the bicycle based on the accelerationInput
    private void ApplyEngineForce()
    {
        // Calculate forward velocity
        velocityVsUp = Vector2.Dot(transform.up, vehicleRigidBody2D.velocity);

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
        if((vehicleRigidBody2D.velocity.sqrMagnitude > (maxSpeed * maxSpeed)) && (accelerationInput > 0))
        {
            return;
        }

        // Apply drag if there is no accelerationInput so bike slows down without input
        if(accelerationInput ==  0)
        {
            vehicleRigidBody2D.drag = Mathf.Lerp(vehicleRigidBody2D.drag, 10.0f, Time.fixedDeltaTime * 3);
        }
        else
        {
            vehicleRigidBody2D.drag = Mathf.Lerp(vehicleRigidBody2D.drag, 0, Time.fixedDeltaTime * 10);
        }

        // Apply more drag depending on surface
        switch (GetSurface())
        {
            case Surface.SurfaceTypes.Dirt:
                vehicleRigidBody2D.drag = Mathf.Lerp(vehicleRigidBody2D.drag, 8.0f, Time.fixedDeltaTime * 3);
                break;
            case Surface.SurfaceTypes.Grass:
                vehicleRigidBody2D.drag = Mathf.Lerp(vehicleRigidBody2D.drag, 6.5f, Time.fixedDeltaTime * 2);
                break;
        }

        // Create a force
        Vector2 peddleForceVector = transform.up * accelerationInput * accelerationFactor;

        // Apply force and push bicycle forward
        vehicleRigidBody2D.AddForce(peddleForceVector, ForceMode2D.Force);
    }

    // Rotates the bicycle based upon the steeringInput
    public virtual void ApplySteering()
    {
        // Limit the vehicles ability to turn when moving slowly
        float minSpeedBeforeAllowTurning = (vehicleRigidBody2D.velocity.magnitude / turningDifficulty);
        minSpeedBeforeAllowTurning = Mathf.Clamp01(minSpeedBeforeAllowTurning);

        // Update the rotation angle based on input
        rotationAngle -= steeringInput * turnFactor * minSpeedBeforeAllowTurning;

        // Apply steering by rotation the bicycle
        vehicleRigidBody2D.MoveRotation(rotationAngle);
    }    

    // Eliminates side velocity so the bicycle responds more accurately and less like a space ship
    private void RemoveSideVelocity()
    {
        // Get forward and right velocity of the car
        Vector2 forwardVelocity = transform.up * Vector2.Dot(vehicleRigidBody2D.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(vehicleRigidBody2D.velocity, transform.right);

        float currentDriftFactor = driftFactor;

        // Apply more drag depending on surface
        switch (GetSurface())
        {
            case Surface.SurfaceTypes.Grass:
                currentDriftFactor *= 0.95f;
                break;
            case Surface.SurfaceTypes.Dirt:
                currentDriftFactor *= 1.05f;
                break;
        }

        // Remove side velocity based on how much the car should drift.
        vehicleRigidBody2D.velocity = forwardVelocity + rightVelocity * currentDriftFactor;
    }

    // Changes the sprite based on it's rotation to create a 3D effect
    private void SetSpriteOnRotation()
    {
        Vector3 rotation = transform.eulerAngles;
        float angle = rotation.z % 360;

        if ((angle > 337.5) || (angle < 22.5))          // Up Direction
        {
            vehicleAnimation.ChangeAnimation(0);
        }
        else if ((angle > 22.5) && (angle < 67.5))      // Up-Left Direction
        {
            vehicleAnimation.ChangeAnimation(1);
        }
        else if ((angle > 67.5) && (angle < 112.5))     // Left Direction
        {
            vehicleAnimation.ChangeAnimation(2);
        }
        else if ((angle > 112.5) && (angle < 157.5))    // Down-Left Direction      
        {
            vehicleAnimation.ChangeAnimation(3);
        }
        else if ((angle > 157.5) && (angle < 202.5))    // Down Direction
        {
            vehicleAnimation.ChangeAnimation(4);
        }
        else if ((angle > 202.5) && (angle < 247.5))    // Down-Right Direction
        {
            vehicleAnimation.ChangeAnimation(5);
        }
        else if ((angle > 247.5) && (angle < 292.5))    // Right Direction
        {
            vehicleAnimation.ChangeAnimation(6);
        }
        else if ((angle > 292.5) && (angle < 337.5))    // Up-Right Direction
        {
            vehicleAnimation.ChangeAnimation(7);
        }
    }

    // Sets steeringInput and accelerationInput based off the input vector values
    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;
    }

    public Surface.SurfaceTypes GetSurface()
    {
        return carSurfaceHandler.GetCurrentSurface();
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
