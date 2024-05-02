/*
Name: Dylan Thompson
Role: Team Lead 5 -- AI Specialist
Project: Midnight Slice Madness
This file contains the definition for the Ghost Class
This class provides the design for the ghost object
It inherits from MonoBehaviour and Monster
This class is part of a Factory pattern
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angel : Monster
{
    [SerializeField] private AudioClip sfxClip;
    [SerializeField] GameObject detectField;
    private bool isIncapacitated = false;
    bool beingSeen = false;
    bool hitPlayer = false;
    bool inView = false;
    Camera cam = Camera.main;
    
    // Update is called once per frame
    protected override void Update()
    {
        RaycastHit2D hit;
        Vector3 veiwPos = cam.WorldToViewportPoint(gameObject.transform.position);
        
        playerTransform = FindObjectOfType<VehicleController>().transform;
        hit = Physics2D.Raycast(transform.position, playerTransform.position - transform.position, Mathf.Infinity);

        if (hit.collider.gameObject.tag == "Player")
        {
            //textBox.text = "We're In Sight";
            Debug.Log("We're In Sight");
            hitPlayer = true;
        }
        else
        {
            Debug.Log(hit.collider.gameObject.tag + "Was Hit");
            hitPlayer = false;
        }

        if ((veiwPos.x >= 0 && veiwPos.x <= 1) && (veiwPos.y >= 0 && veiwPos.y <= 1))
        {
            inView = hitPlayer;
        }
        else
        {
            inView = false;
        }
        
        if (beingSeen && inView)
        {
            PursuePlayer();
        }
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

    public override void OnCollisionEnter2D(Collision2D collision)
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
    void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log("Entered Field of View");
        if (other.gameObject.tag == "fov")
        {
            beingSeen = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "fov")
        {
            beingSeen = false;
        }
    }
}
