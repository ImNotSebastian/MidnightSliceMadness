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
using UnityEngine.UIElements;

public class MonsterFactory : MonoBehaviour
{
    [SerializeField] private GameObject ghostPrefab;
    // Additional monster prefabs...
    [SerializeField] private int spawnRadius = 10; // Minimum distance from the player
    [SerializeField] private int maxGhosts = 10; // Maximum number of ghosts allowed
    [SerializeField] private int spawnInterval = 5; // Time interval between spawns
    private Transform playerTransform; // Assign this in the Inspector
    private int ghostCount = 0; //Current ghost count
    private static bool spawningEnabled = true;

    public enum MonsterType
    {
        Ghost,
        // Add more types as needed
    }

    void Start()
    {
        playerTransform = FindObjectOfType<VehicleController>().transform;

        if (playerTransform == null)
        {
            Debug.LogError("Player Transform is not assigned in MonsterFactory.");
            return;
        }
        StartCoroutine(SpawnMonsters());
    }

    private void Update()
    {
        playerTransform = FindObjectOfType<VehicleController>().transform;
    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            Vector3 spawnPosition = GenerateSpawnPosition();
            if (spawnPosition != Vector3.zero && ghostCount <= maxGhosts && spawningEnabled)
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
            if (!IsInView(potentialPosition) && IsInBoundaries(potentialPosition)) // && inside boundaries
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

    bool IsInBoundaries(Vector3 position)
    {
        bool xBoundary = position.x >= -42f && position.x <= 16f;
        bool yBoundary = position.y >= -41f && position.y <= 34f;
        if (xBoundary && yBoundary)
        {
            return true;
        }
        else
        {
            return false;
        }
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

    public void IncrementDecrementGhostCount(bool adjust)
    {
        if (adjust)
        {
            ++ghostCount;
        }
        else
        {
            --ghostCount;
        }
    }

    public void ToggleSpawning(bool toggle)
    {
        if (toggle)
        {
            spawningEnabled = true;
        }
        else
        {
            spawningEnabled = false;
        }
    }
}


/*
The factory pattern is great for when you're going to have multiple instances of objects that all inherit from a
common superclass because it allows for creation of objects at runtime, allowing for dynamic spawining of ememies
during gameplay.
*/

/*
A bad choice to use the pattern would be where you have a situation where you are only spawing one type of object
that isn't going to change. This would add unnecesary complexity to your code.
*/