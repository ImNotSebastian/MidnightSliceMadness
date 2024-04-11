/*
Name: Dylan Thompson
Role: Team Lead 5 -- AI Specialist
Project: Midnight Slice Madness
This file contains the definition for the Monster Factory
This class deals with spawining monsters
It inherits from MonoBehaviour
This class is part of a Factory pattern
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFactory : MonoBehaviour
{
    [SerializeField] private Transform playerTransform; // Assign this in the Inspector
    [SerializeField] private GameObject ghostPrefab;
    // Additional monster prefabs...
    [SerializeField] private float spawnRadius = 10f; // Minimum distance from the player
    [SerializeField] private int maxGhosts = 10; // Maximum number of ghosts allowed
    private float spawnInterval = 5f; // Time interval between spawns
    private int ghostCount= 0; //Current ghost count

    public enum MonsterType
    {
        Ghost,
        // Add more types as needed
    }

    void Start()
    {
        if (playerTransform == null)
        {
            Debug.LogError("Player Transform is not assigned in MonsterFactory.");
            return;
        }
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            Vector3 spawnPosition = GenerateSpawnPosition();
            if (spawnPosition != Vector3.zero && ghostCount <= maxGhosts)
            {
                SpawnMonsterAtPosition(MonsterType.Ghost, spawnPosition);
                ghostCount++;
                //Debug.Log($"Trying to spawn ghost at: {spawnPosition}");
            }
        }
    }

    Vector3 GenerateSpawnPosition()
    {
        float cameraHeight = Camera.main.orthographicSize * 2;
        float cameraWidth = cameraHeight * Camera.main.aspect;
        Vector3 playerPos = playerTransform.position;

        for (int attempts = 0; attempts < 30; attempts++)
        {
            float x = Random.Range(playerPos.x - cameraWidth / 2 - spawnRadius, playerPos.x + cameraWidth / 2 + spawnRadius);
            float y = Random.Range(playerPos.y - cameraHeight / 2 - spawnRadius, playerPos.y + cameraHeight / 2 + spawnRadius);
            Vector3 potentialPosition = new Vector3(x, y, 0);

            // Check if the position is off-screen
            if (!IsInView(potentialPosition))
            {
                // Check if the position is outside the safe radius from the player
                if (Vector3.Distance(playerPos, potentialPosition) >= spawnRadius)
                {
                    return potentialPosition;
                }
            }
        }

        // Return Vector3.zero if a suitable position isn't found after a number of attempts
        return Vector3.zero;
    }

    bool IsInView(Vector3 position)
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(position);
        return screenPoint.x >= 0 && screenPoint.x <= 1 && screenPoint.y >= 0 && screenPoint.y <= 1;
    }

    public GameObject SpawnMonsterAtPosition(MonsterType type, Vector3 position)
    {
        GameObject monsterInstance = null;
        switch (type)
        {
            case MonsterType.Ghost:
                monsterInstance = Instantiate(ghostPrefab, position, Quaternion.identity);
                // Additional setup for the monster
                Debug.Log($"Spawned {type} at {position}");
                break;
                // Additional monsters
        }
        return monsterInstance;
    }
}


/* The factory pattern is great for when you're going to have multiple instances of objects that all inherit from a
   common superclass because it allows for creation of objects at runtime, allowing for dynamic spawining of ememies
   during gameplay. */

/* A bad time to use the pattern would be */