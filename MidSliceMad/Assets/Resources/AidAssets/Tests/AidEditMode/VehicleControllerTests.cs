/*
Name: Aiden Shepard
Role: Team Lead 3 -- QA Manager
Project: Midnight Slice Madness

This file is composed of the edit mode test for the VehicleController.cs file
*/

using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class VehicleControllerTests
{
    private VehicleController vehicleController;
    private Rigidbody2D rigidbody2D;

    [SetUp]
    public void SetUp()
    {
        // Create a GameObject with BicycleController attached
        GameObject gameObject = new GameObject();
        vehicleController = gameObject.AddComponent<VehicleController>();
        rigidbody2D = gameObject.AddComponent<Rigidbody2D>();
    }

    [TearDown]
    public void TearDown()
    {
        // Destroy the GameObject and clean up
        GameObject.DestroyImmediate(vehicleController.gameObject);
    }

    [Test]
    public void TestSetMaxSpeed()
    {
        // Set and get max speed
        vehicleController.SetMaxSpeed(10f);
        Assert.AreEqual(10f, vehicleController.GetMaxSpeed());
    }
}