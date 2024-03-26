/*
Name: Aiden Shepard
Role: Team Lead 3 -- QA Manager
Project: Midnight Slice Madness

This file is composed of the edit mode test for the BicycleController.cs file
*/

using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class BicycleControllerTests
{
    private BicycleController bicycleController;

    [SetUp]
    public void SetUp()
    {
        // Create a GameObject with BicycleController attached
        GameObject gameObject = new GameObject();
        bicycleController = gameObject.AddComponent<BicycleController>();
    }

    [TearDown]
    public void TearDown()
    {
        // Destroy the GameObject and clean up
        GameObject.DestroyImmediate(bicycleController.gameObject);
    }

    [Test]
    public void TestSetMaxSpeed()
    {
        // Set and get max speed
        bicycleController.SetMaxSpeed(10f);
        Assert.AreEqual(10f, bicycleController.GetMaxSpeed());
    }
}