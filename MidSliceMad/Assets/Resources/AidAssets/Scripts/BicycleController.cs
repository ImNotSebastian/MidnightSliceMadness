using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BicycleController : MonoBehaviour
{
    [SerializeField] float driftFactor;
    [SerializeField] float accelerationFactor;
    [SerializeField] float turnFactor;
    [SerializeField] float maxSpeed;
    [SerializeField] float reverseSpeed;

    // Local Variables
    float accelerationInput = 0;
    float steeringInput = 0;

    float rotationAngle = 0;

    float velocityVsUp = 0;

    // Components
    Rigidbody2D carRigidBody2D;

    // Awake is called when the script is being loaded
    void Awake()
    {
        carRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Frame-rate independent for phsyics calculations.
    void FixedUpdate()
    {
        ApplyPeddleForce();

        RemoveSideVelocity();

        ApplySteering();
    }

    void ApplyPeddleForce()
    {
        // Calculate forward velocity
        velocityVsUp = Vector2.Dot(transform.up, carRigidBody2D.velocity);

        // Limit so we can't go faster than the max speed in the forward direction
        if (velocityVsUp > maxSpeed && accelerationInput > 0)
        {
            return;
        }

        // Limit so we can't go faster than reverseSpeed of the max speed in the reverse direction
        if (velocityVsUp < -maxSpeed * reverseSpeed && accelerationInput < 0)
        {
            return;
        }

        // Limit so we can't go faster in any direction while accelerating
        if (carRigidBody2D.velocity.sqrMagnitude > maxSpeed * maxSpeed && accelerationInput > 0)
        {
            return;
        }

        // Apply drag if there is no accelerationInput so bike slows down without input
        if (accelerationInput ==  0)
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

    void ApplySteering()
    {
        // Update the rotation angle based on input
        rotationAngle -= steeringInput * turnFactor;

        // Apply steering by rotation the bicycle
        carRigidBody2D.MoveRotation(rotationAngle);
    }    

    void RemoveSideVelocity()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(carRigidBody2D.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(carRigidBody2D.velocity, transform.right);

        carRigidBody2D.velocity = forwardVelocity + rightVelocity * driftFactor;
    }

    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;
    }

    public void SetMaxSpeed(float newSpeed)
    {
        maxSpeed = newSpeed;
    }

    public float GetMaxSpeed()
    {
        return maxSpeed;
    }
}
