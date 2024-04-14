/*
Name: Dylan Thompson
Role: Team Lead 5 -- AI Specialist
Project: Midnight Slice Madness
This file contains the definition for the Ghost Class
This class provides the design for the ghost object
It inherits from MonoBehaviour and Monster
This class is part of a Factory pattern
*/

using Codice.CM.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Monster
{
    [SerializeField] private AudioClip sfxClip;
    private bool isIncapacitated = false;
    
    // Update is called once per frame
    protected override void Update()
    {
        PursuePlayer();
        DistanceDespawn();
    }

    protected override IEnumerable Incapacitate()
    {
        if (!isIncapacitated)
        {
            isIncapacitated = true;
            speed = 0f;
            yield return new WaitForSeconds(incapacitateDuration);
            speed = 3f;
            isIncapacitated = false;
        }
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        // Deal damage if colliding with the player
        if (collision.gameObject.tag == "Player")
        {
            // Damage logic here
            GameManager.instance.DecreaseScore(attackDamage);
            Debug.Log($"Dealt {attackDamage} damage to the player!");
            attackCount++;
            SoundFxManager.Instance.playSFX(sfxClip, transform, 1f);

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
}
