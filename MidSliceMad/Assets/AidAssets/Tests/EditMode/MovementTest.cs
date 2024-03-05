using NUnit.Framework;
using System.Collections;
using UnityEngine;

public class MovementTest
{
    GameObject playerObject;
    BicycleController playerMovement;

    [SetUp]
    public void Setup()
    {
        playerObject = new GameObject();
        playerObject.AddComponent<Rigidbody2D>();
        playerMovement = playerObject.AddComponent<BicycleController>();
    }

    [TearDown]
    public void Teardown()
    {
        GameObject.DestroyImmediate(playerObject);
    }


    // A Test behaves as an ordinary method
    [Test]
    public void CanAccelerateForward()
    {
        // Arrange
        Vector3 startPosition = playerObject.transform.position;

        // Act
        playerMovement.SetInputVector(Vector2.up);

        // Assert
        Assert.Greater(playerObject.transform.position.y, startPosition.y, "Player did not move up.");
    }

    [Test]
    public void CanReverse()
    {
        // Arrange
        Vector3 startPosition = playerObject.transform.position;

        // Act
        playerMovement.SetInputVector(Vector2.down);

        // Assert
        Assert.Less(playerObject.transform.position.y, startPosition.y, "Player did not move down.");
    }
}
