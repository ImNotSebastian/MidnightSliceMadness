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
using System;

public class MonsterFactory : MonoBehaviour
{
    [SerializeField] public GameObject ghostPrefab;
    [SerializeField] public GameObject gargoylePrefab;
    // Additional monster prefabs...
    [SerializeField] private int spawnRadius = 10; // Minimum distance from the player
    [SerializeField] private int maxGhosts = 10; // Maximum number of ghosts allowed
    [SerializeField] private int maxGargoyles = 10; // Maximum number of ghosts allowed
    [SerializeField] private int spawnInterval = 5; // Time interval between spawns
    public Transform playerTransform; // Assigned in the Inspector
    private int monsterCount = 0; //Current monster count
    private int ghostCount = 0; //Current ghost count
    private int gargoyleCount = 0; //Current gargoyle count
    private static bool spawningEnabled = true;

    public enum MonsterType
    {
        Ghost,
        Gargoyle,
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
        System.Random random = new System.Random();

        while (true)
        {
            int randomNumber = random.Next(1, 3);
            yield return new WaitForSeconds(spawnInterval);
            Vector3 spawnPosition = GenerateSpawnPosition();
            if (spawnPosition != Vector3.zero && monsterCount <= maxGhosts && spawningEnabled && randomNumber == 1)
            {
                SpawnMonsterAtPosition(MonsterType.Ghost, spawnPosition);
                monsterCount++;
                //Debug.Log($"Trying to spawn ghost at: {spawnPosition}");
            }
            else if (spawnPosition != Vector3.zero && monsterCount <= maxGargoyles && spawningEnabled && randomNumber == 2)
            {
                SpawnMonsterAtPosition(MonsterType.Gargoyle, spawnPosition);
                monsterCount++;
                //Debug.Log($"Trying to spawn ghost at: {spawnPosition}");
            }
        }
    }

    public Vector3 GenerateSpawnPosition()
    {
        float cameraHeight = Camera.main.orthographicSize * 2;
        float cameraWidth = cameraHeight * Camera.main.aspect;
        Vector3 playerPos = playerTransform.position;

        for (int attempts = 0; attempts < 30; attempts++)
        {
            float x = UnityEngine.Random.Range(playerPos.x - cameraWidth / 2 - spawnRadius, playerPos.x + cameraWidth / 2 + spawnRadius);
            float y = UnityEngine.Random.Range(playerPos.y - cameraHeight / 2 - spawnRadius, playerPos.y + cameraHeight / 2 + spawnRadius);
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
            case MonsterType.Gargoyle:
                monsterInstance = Instantiate(gargoylePrefab, position, Quaternion.identity);
                // Additional setup for the monster
                Debug.Log($"Spawned {type} at {position}");
                break;
        }
        return monsterInstance;
    }

    public void IncrementDecrementMonsterCount(bool adjust)
    {
        if (adjust)
        {
            ++monsterCount;
        }
        else
        {
            --monsterCount;
        }
    }

    //public void IncrementDecrementGhostCount(bool adjust)
    //{
    //    if (adjust)
    //    {
    //        ++ghostCount;
    //    }
    //    else
    //    {
    //        --ghostCount;
    //    }
    //}

    //public void IncrementDecrementGargoyleCount(bool adjust)
    //{
    //    if (adjust)
    //    {
    //        ++gargoyleCount;
    //    }
    //    else
    //    {
    //        --gargoyleCount;
    //    }
    //}

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
The state pattern would have also worked well for the ghosts allowing them to change state easily,
i.e. from wantering to pursuing.
*/

/*
A bad choice to use the pattern would be where you have a situation where you are only spawing one type of object
that isn't going to change. This would add unnecesary complexity to your code.
*/