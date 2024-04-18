using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;

public class GhostTests : MonoBehaviour
{
    private GameObject ghostObject;
    private Ghost ghost;

    // Setup method to initialize before each test
    [SetUp]
    //public void SetUp()
    //{
    //    ghostObject = new GameObject();
    //    ghost = ghostObject.AddComponent<Ghost>();
    //    ghost.maxAttacks = 3; // Ensure the ghost is set to despawn after x attacks
    //}

    public void SetUp()
    {
        ghostObject = new GameObject();
        ghost = ghostObject.AddComponent<Ghost>();
        ghost.maxAttacks = 3; // Ensure the ghost is set to despawn after x attacks

        ghost.rb = ghostObject.AddComponent<Rigidbody2D>();

        // Create a new GameObject for the VehicleController and add necessary components
        GameObject playerObject = new GameObject("Player");
        playerObject.AddComponent<Rigidbody2D>();
        var vehicleController = playerObject.AddComponent<VehicleController>();
        playerObject.transform.position = new Vector3(0, 0, 0);

        ghost.playerTransform = playerObject.transform; // Ensure ghost can reference player transform
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(ghostObject);
    }

    // Test to check despawn after maximum attacks
    [UnityTest]
    public IEnumerator DespawnAfterMaxAttacksTest()
    {
        // Simulate collisions with the player to trigger attacks
        for (int i = 0; i < ghost.maxAttacks; i++)
        {
            ghost.OnCollisionEnter2D(new Collision2D());
        }

        yield return null;

        // Assert that the ghost GameObject has been destroyed
        Assert.IsTrue(ghostObject == null, "Ghost should be destroyed after reaching maximum attacks");
    }
}
