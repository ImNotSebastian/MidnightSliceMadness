/*
Name: Dylan Thompson
Role: Team Lead 5 -- AI Specialist
Project: Midnight Slice Madness
This file contains the definition for the Monster Class
This is an abstract class that each monster inherits
It inherits from MonoBehaviour
This class is part of a Factory pattern
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    [SerializeField] public float detectionRadius = 9f; // Default detection radius

    protected Transform playerTransform;
    [SerializeField] protected float speed = 3f;

    // The f at the end of the value means float
    //[SerializeField] private float health = 100f;
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float bounceForce = 1f;
    [SerializeField] private float bounceCooldown = 1f; // Time in seconds before pursuing again
    private bool isBouncing = false; // Flag to track bouncing state
    private Rigidbody2D rb;

    
    protected virtual void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    protected abstract void Update();

    protected void PursuePlayer()
    {
        if (!isBouncing && Vector3.Distance(transform.position, playerTransform.position) <= detectionRadius)
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        // Deal damage if colliding with the player
        if (collision.gameObject.tag == "Player")
        {
            // Damage logic here
            Debug.Log($"Dealt {attackDamage} damage to the player!");

            // Calculate bounce direction
            Vector2 bounceDirection = transform.position - collision.transform.position;
            bounceDirection.Normalize(); // Ensure the direction vector has a magnitude of 1

            // Begin bounce cooldown period
            isBouncing = true;
            Invoke(nameof(ResetBounceState), bounceCooldown); // Schedule reset of bounce state

            rb.velocity = Vector2.zero; // Reset the velocity

            // Debug.Log($"Bounce direction-Bounce force: {bounceDirection} - {bounceForce}");
            // Apply a force to bounce off
            rb.AddForce(bounceDirection * bounceForce, ForceMode2D.Impulse);
        }
    }

    // Reset the bounce state after cooldown
    private void ResetBounceState()
    {
        isBouncing = false;
    }
}