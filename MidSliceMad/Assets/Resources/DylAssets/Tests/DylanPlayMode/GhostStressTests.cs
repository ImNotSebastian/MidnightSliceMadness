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
    private float currentFps = 0;

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
    public IEnumerator SpawnGhostsUntilFailure()
    {
        int numberOfGhosts = 1000;
        int sampleDuration = 1;
        bool spawnNextBatch = true;

        while (spawnNextBatch)
        {
            spawnNextBatch = SpawnGhosts(numberOfGhosts);

            // Wait 1 second
            yield return new WaitForSeconds(sampleDuration);
            currentFps = Time.frameCount / Time.time;
            Debug.Log($"FPS: {currentFps}, # of ghosts: {numberOfGhosts}");

            if (currentFps < 60)
            {
                Debug.LogError($"Sub 60 fps of {currentFps} occurred at {numberOfGhosts} ghosts");
                spawnNextBatch = false; // Stop spawning if an exception occurs
            }

            if (spawnNextBatch)
            {
                // Cleanup before the next iteration
                CleanupGhosts();
                numberOfGhosts += 10;
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
                
                /*currentFps = Time.frameCount / Time.time;
                if (currentFps < 60)
                {
                    Debug.LogError($"Sub 60 fps occurred at {numberOfGhosts} ghosts");
                    return false; // Stop spawning if an exception occurs
                }*/
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
