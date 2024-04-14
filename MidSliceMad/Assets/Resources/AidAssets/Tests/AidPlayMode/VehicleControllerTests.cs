using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class VehicleControllerTests
{
    [UnityTest]
    public IEnumerator GetSurface_ReturnsCorrectSurfaceType()
    {
        // Arrange
        GameObject vehicleGameObject = new GameObject();
        VehicleController vehicleController = vehicleGameObject.AddComponent<VehicleController>();
        Rigidbody2D vehicleRigidBody2D = vehicleGameObject.AddComponent<Rigidbody2D>();
        Surface.SurfaceTypes expectedSurfaceType = Surface.SurfaceTypes.Dirt;

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainLevel");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        // Act
        Surface.SurfaceTypes actualSurfaceType = vehicleController.GetSurface();

        // Assert
        Assert.AreEqual(expectedSurfaceType, actualSurfaceType, "Incorrect surface type returned.");
    }

    [UnityTest]
    public IEnumerator TireScreeching_WhenBraking_ReturnsTrue()
    {
        // Arrange
        GameObject vehicleGameObject = new GameObject();
        VehicleController vehicleController = vehicleGameObject.AddComponent<VehicleController>();
        float lateralVelocity;
        bool isBraking;

        // Act
        vehicleController.SetInputVector(new Vector2(1, 0));
        vehicleController.SetInputVector(new Vector2(0, 0));
        bool result = vehicleController.IsTireScreeching(out lateralVelocity, out isBraking);

        // Assert
        Assert.IsTrue(result);
        Assert.IsTrue(isBraking);

        yield return null;
    }

    [UnityTest]
    public IEnumerator TireScreeching_WhenMovingSideways_ReturnsTrue()
    {
        // Arrange
        GameObject vehicleGameObject = new GameObject();
        VehicleController vehicleController = vehicleGameObject.AddComponent<VehicleController>();
        Rigidbody2D vehicleRigidBody2D = vehicleGameObject.AddComponent<Rigidbody2D>();
        float lateralVelocity;
        bool isBraking;

        // Act
        vehicleRigidBody2D.velocity = new Vector2(0, 5); 
        bool result = vehicleController.IsTireScreeching(out lateralVelocity, out isBraking);

        // Assert
        Assert.IsTrue(result);
        Assert.IsFalse(isBraking);

        yield return null;
    }

    [UnityTest]
    public IEnumerator TireScreeching_WhenNotBrakingOrMovingSideways_ReturnsFalse()
    {
        // Arrange
        GameObject vehicleGameObject = new GameObject();
        VehicleController vehicleController = vehicleGameObject.AddComponent<VehicleController>();
        Rigidbody2D vehicleRigidBody2D = vehicleGameObject.AddComponent<Rigidbody2D>();
        float lateralVelocity;
        bool isBraking;

        // Act
        vehicleController.SetInputVector(new Vector2(1, 0));
        vehicleRigidBody2D.velocity = new Vector2(0, 0); // No sideways velocity
        bool result = vehicleController.IsTireScreeching(out lateralVelocity, out isBraking);

        // Assert
        Assert.IsFalse(result);
        Assert.IsFalse(isBraking);

        yield return null;
    }
}