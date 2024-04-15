/*
Name: Dylan Thompson
Role: Team Lead 5 -- AI Specialist
Project: Midnight Slice Madness
This file contains the definition for the Monster Class
This is an abstract class that each monster inherits
It inherits from MonoBehaviour
This class is part of a Factory pattern
*/

// using log4net.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    [SerializeField] public float detectionRadius = 5f; // Default detection radius
    [SerializeField] protected float speed = 3f;
    [SerializeField] protected int attackDamage = 1;
    [SerializeField] protected float bounceForce = 1f;
    [SerializeField] protected float bounceCooldown = 1f; // Time in seconds before pursuing again
    [SerializeField] protected int incapacitateDuration = 3;
    [SerializeField] protected int maxAttacks = 3; // Max number of attacks before de-spawning
    protected bool isBouncing = false; // Flag to track bouncing state
    protected Transform playerTransform;
    protected Rigidbody2D rb;
    protected int attackCount = 0;

    // The f at the end of the value means float
    //[SerializeField] private float health = 100f;

    [SerializeField] private float wanderRadius = 5f; // Radius within which the monster will wander
    [SerializeField] private int despawnRadius = 10;
    private Vector3 startPosition;
    private Vector3 wanderDestination;
    private bool wandering = false;
    //private MonsterFactory monsterFactory = FindObjectOfType<MonsterFactory>();
    private MonsterFactory monsterFactory;

    protected virtual void Start()
    {
        playerTransform = FindObjectOfType<VehicleController>().transform;
        rb = GetComponent<Rigidbody2D>();

        startPosition = transform.position; // Save the starting position
        monsterFactory = FindObjectOfType<MonsterFactory>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        playerTransform = FindObjectOfType<VehicleController>().transform;
        PursuePlayer();
        DistanceDespawn();
    }

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

    //Remove virtual and override 
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        // Deal damage if colliding with the player
        if (collision.gameObject.tag == "Player")
        {
            // Damage logic here
            GameManager.instance.DecreaseScore(attackDamage);
            Debug.Log($"Dealt {attackDamage} damage to the player!");
            attackCount++;

            // Check if the attack count has reached the limit
            if (attackCount >= maxAttacks)
            {
                Despawn();
                Debug.Log("Monster has de-spawned due to reaching attack limit.");
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
    protected void ResetBounceState()
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
            wanderDestination = startPosition + new Vector3(randomDirection.x, randomDirection.y, -1);
        }

        // Move towards the destination
        transform.position = Vector3.MoveTowards(transform.position, wanderDestination, speed * Time.deltaTime);

        // Once the destination is reached, allow for a new destination to be set in the next call
        if (Vector3.Distance(transform.position, wanderDestination) < 0.001f)
        {
            wandering = false;
        }
    }

    protected void Despawn()
    {
        Destroy(gameObject);
        monsterFactory.IncrementDecrementGhostCount(false);
    }

    protected void DistanceDespawn()
    {
        if (Vector3.Distance(transform.position, playerTransform.position) >= despawnRadius)
        {
            Despawn();
            Debug.Log("Monster has de-spawned due to distance from player.");
        }
    }

    protected virtual IEnumerable Incapacitate()
    {
        yield return new WaitForSeconds(incapacitateDuration);
    }
}