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
    [SerializeField] public float detectionRadius = 5f; // Default detection radius

    protected Transform playerTransform;
    [SerializeField] protected float speed = 3f;
    protected int attackCount = 0;

    // The f at the end of the value means float
    //[SerializeField] private float health = 100f;
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float bounceForce = 1f;
    [SerializeField] private float bounceCooldown = 1f; // Time in seconds before pursuing again
    [SerializeField] private float wanderRadius = 5f; // Radius within which the monster will wander
    [SerializeField] private int maxAttacks = 3; // Max number of attacks before de-spawning
    private Vector3 startPosition;
    Vector3 wanderDestination;
    private bool isBouncing = false; // Flag to track bouncing state
    private bool wandering = false;
    private Rigidbody2D rb;

    
    protected virtual void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();

        startPosition = transform.position; // Save the starting position
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
        else if (!isBouncing)
        {
            Wander();
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        // Deal damage if colliding with the player
        if (collision.gameObject.tag == "Player")
        {
            // Damage logic here
            Debug.Log($"Dealt {attackDamage} damage to the player!");
            attackCount++;

            // Check if the attack count has reached the limit
            if (attackCount >= maxAttacks)
            {
                Despawn();
            }

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

    private void Wander()
    {
        if (!wandering)
        {
            wandering = true;
            // Calculate a random position within the wanderRadius of the startPosition
            Vector2 randomDirection = Random.insideUnitCircle * wanderRadius;
            wanderDestination = startPosition + new Vector3(randomDirection.x, randomDirection.y, 0);
        }

        // Move towards the destination
        transform.position = Vector3.MoveTowards(transform.position, wanderDestination, speed * Time.deltaTime);

        // Once the destination is reached, allow for a new destination to be set in the next call
        if (Vector3.Distance(transform.position, wanderDestination) < 0.001f)
        {
            wandering = false;
        }
    }

    private void Despawn()
    {
        Debug.Log("Monster has de-spawned due to reaching attack limit.");
        Destroy(gameObject);
    }
}