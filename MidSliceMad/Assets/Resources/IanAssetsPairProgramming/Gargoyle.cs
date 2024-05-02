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

public class Gargoyle : Monster
{
    [SerializeField] private AudioClip sfxClip;
    [SerializeField] GameObject detectField;
    private bool isIncapacitated = false;
    bool beingSeen = false;
    bool hitPlayer = false;
    bool inView = false;
    Camera cam;
    GameObject fieldInst;

    private MonsterFactory monsterFactory;
    private Vector3 startPosition;

    protected override void Start()
    {
        playerTransform = FindObjectOfType<VehicleController>().transform;
        rb = GetComponent<Rigidbody2D>();
        fieldInst = Instantiate(detectField, playerTransform);
        startPosition = transform.position; // Save the starting position
        monsterFactory = FindObjectOfType<MonsterFactory>();

    }
    
    // Update is called once per frame
    protected override void Update()
    {
        cam = Camera.main;
        int layer2 = 1 << 9;
        int notLayer2 = ~layer2;
        RaycastHit2D hit;
        Vector3 veiwPos = cam.WorldToViewportPoint(gameObject.transform.position);
        
        playerTransform = FindObjectOfType<VehicleController>().transform;
        fieldInst.transform.SetPositionAndRotation(playerTransform.position, playerTransform.rotation);
        hit = Physics2D.Raycast(transform.position, playerTransform.position - transform.position, Mathf.Infinity, notLayer2);

        if (hit.collider.gameObject.tag == "Player")
        {
            //textBox.text = "We're In Sight";
            Debug.Log("We're In Sight");
            hitPlayer = true;
        }
        else if (hit.collider.gameObject.tag == "Ghost")
        {
            hitPlayer = false;
            hit.collider.gameObject.layer = 9;
        }
        else
        {
            Debug.Log(hit.collider.gameObject.tag + " Was Hit, the name is " + hit.collider.gameObject.name);
            hitPlayer = false;
        }

        inView = hitPlayer;
        /*if ((veiwPos.x >= 0 && veiwPos.x <= 1) && (veiwPos.y >= 0 && veiwPos.y <= 1))
        {
            inView = hitPlayer;
            Debug.Log("Hit Player = " + hitPlayer);
        }
        else
        {
            inView = false;
        }*/
        
        Debug.Log("Being Seen = " + beingSeen + " In View = " + inView);
        Debug.Log("Can Move = " + !(beingSeen && inView));
        if (!(beingSeen && inView))
        {
            Debug.Log("Gargoyle Can Move");
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
        if (other.gameObject.tag == "fov")
        {
            Debug.Log("Entered Field of View");
            beingSeen = true;
        }
    }

    //register that the player is no longer looking at the enemy
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "fov")
        {
            beingSeen = false;
            Debug.Log("Exited Field of View");
        }
    }
}
