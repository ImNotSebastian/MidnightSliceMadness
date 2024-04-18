/*
Name: Dylan Thompson
Role: Team Lead 5 -- AI Specialist
Project: Midnight Slice Madness
This file contains the definition for the Ghost Detection Radius Tests
This class contains two tests that test the ghost pursue functionality at its boundaries
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;


public class GhostDetectionRadiusTests
{
    private GameObject player;
    private GameObject ghost;
    private Ghost ghostScript;
    private string ghostPrefabPath = "DylAssets/Ghost";

    [SetUp]
    public void Setup()
    {
        // Setup player
        player = new GameObject("Player");
        player.tag = "Player";
        player.AddComponent<Rigidbody2D>();

        // Instantiate ghost from prefab
        GameObject ghostPrefab = Resources.Load<GameObject>(ghostPrefabPath);
        ghost = Object.Instantiate(ghostPrefab, Vector3.zero, Quaternion.identity);
        ghostScript = ghost.GetComponent<Ghost>();
    }

    // Cleanup method to destroy player and ghost after each test
    [TearDown]
    public void Teardown()
    {
        GameObject.Destroy(player);
        GameObject.Destroy(ghost);
    }

    [UnityTest]
    public IEnumerator CheckPursuesInsideDetectionRadius()
    {
        float detectionRadius = ghostScript.detectionRadius;
        player.transform.position = new Vector3(detectionRadius - 0.1f, 0, 0); // Just inside
        ghost.transform.position = Vector3.zero;

        yield return new WaitForSeconds(1f);

        // Check if the ghost moved towards the player
        //Assert.Less(ghost.transform.position.x, 0);
        Assert.Greater(ghost.transform.position.x, 0);
    }

    [UnityTest]
    public IEnumerator CheckPursuesOutsideDetectionRadius()
    {
        float detectionRadius = ghostScript.detectionRadius;
        player.transform.position = new Vector3(detectionRadius + 0.1f, 0, 0); // Just outside
        ghost.transform.position = Vector3.zero;

        yield return new WaitForSeconds(1f);

        // Check if the ghost did not move
        Assert.AreEqual(0, ghost.transform.position.x);
    }
}
