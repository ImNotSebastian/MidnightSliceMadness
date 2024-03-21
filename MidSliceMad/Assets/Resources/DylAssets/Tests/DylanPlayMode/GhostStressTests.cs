using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System;

public class GhostStressTests
{
    private GameObject player;
    private GameObject ghostPrefab;
    private int maxGhostsBeforeFailure = 0; // Track the number of ghosts spawned before failure.

    [SetUp]
    public void SetUp()
    {
        player = new GameObject("Player");
        player.tag = "Player";
        player.AddComponent<Rigidbody2D>();
        ghostPrefab = Resources.Load<GameObject>("DylAssets/Ghost");
    }

    [TearDown]
    public void TearDown()
    {
        GameObject.Destroy(player);
        foreach (var ghost in GameObject.FindGameObjectsWithTag("Ghost"))
        {
            GameObject.Destroy(ghost);
        }
    }

    [UnityTest]
    public IEnumerator IncrementallySpawnGhostsUntilExceptionOccurs()
    {
        int numberOfGhosts = 1;
        bool spawnNextBatch = true;

        while (spawnNextBatch)
        {
            spawnNextBatch = SpawnGhosts(numberOfGhosts);

            // Wait a frame
            yield return null;

            if (spawnNextBatch)
            {
                // Cleanup before the next iteration
                CleanupGhosts();
                numberOfGhosts++;
            }
        }
    }

    private bool SpawnGhosts(int numberOfGhosts)
    {
        try
        {
            for (int i = 0; i < numberOfGhosts; i++)
            {
                GameObject.Instantiate(ghostPrefab, new Vector3(UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 10), 0), Quaternion.identity);
            }
            return true;
        }
        catch (Exception ex)
        {
            Debug.LogError($"Exception occurred at {numberOfGhosts} ghosts: {ex.Message}");
            Assert.Fail($"Test failed due to exception at {numberOfGhosts} ghosts: {ex.Message}");
            return false; // Stop spawning if an exception occurs
        }
    }

    private void CleanupGhosts()
    {
        foreach (var ghost in GameObject.FindGameObjectsWithTag("Ghost"))
        {
            GameObject.Destroy(ghost);
        }
    }
}
