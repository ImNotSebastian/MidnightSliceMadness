/*
Name: Aiden Shepard
Role: Team Lead 3 -- QA Manager
Project: Midnight Slice Madness

This file is composed of the edit mode test for the BicycleController.cs file
*/

using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class BicycleTests
{
    private VehicleController vehicleController;

    [SetUp]
    public void SetUp()
    {
        // Create a GameObject with BicycleController attached
        GameObject gameObject = new GameObject();
        vehicleController = gameObject.AddComponent<VehicleController>();
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