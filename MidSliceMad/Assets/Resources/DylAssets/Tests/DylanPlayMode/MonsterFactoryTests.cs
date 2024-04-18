using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MonsterFactoryTests
{
    private GameObject testObject;
    private MonsterFactory monsterFactory;

    [SetUp]
    public void SetUp()
    {
        // Create a test GameObject and add the MonsterFactory component
        testObject = new GameObject("TestMonsterFactory");
        monsterFactory = testObject.AddComponent<MonsterFactory>();

        // Create a mock or placeholder GameObject for playerTransform
        GameObject playerObject = new GameObject("Player");
        monsterFactory.playerTransform = playerObject.transform;

        monsterFactory.ghostPrefab = new GameObject("GhostPrefab");

        var cameraObject = new GameObject("MainCamera");
        cameraObject.AddComponent<Camera>();
        cameraObject.tag = "MainCamera";
    }

    [Test]
    public void TestBoundarySpawns()
    {
        // Define corners of the boundary
        Vector3[] corners = new Vector3[]
        {
            new Vector3(-42f, 34f, 0),  // Top-Left
            new Vector3(16f, 34f, 0),   // Top-Right
            new Vector3(-42f, -41f, 0), // Bottom-Left
            new Vector3(16f, -41f, 0)   // Bottom-Right
        };

        foreach (var corner in corners)
        {
            for (int i = 0; i < 30; i++)
            {
                monsterFactory.playerTransform.position = corner;
                Vector3 spawnPosition = monsterFactory.GenerateSpawnPosition();

                // Check if the spawn position is within visual range but still respects game boundaries
                Assert.AreNotEqual(Vector3.zero, spawnPosition, "Spawn position should not be Vector3.zero at corner " + corner);
                Assert.IsTrue(spawnPosition.x >= -42f && spawnPosition.x <= 16f, "Spawn X coordinate out of bounds at corner " + corner);
                Assert.IsTrue(spawnPosition.y >= -41f && spawnPosition.y <= 34f, "Spawn Y coordinate out of bounds at corner " + corner);
            }
        }
    }

    [TearDown]
    public void TearDown()
    {
        GameObject.DestroyImmediate(testObject);
    }
}