/*
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestInventoryPositionTracking
{
    [Test]
    public void TestInventoryPositionUpdatesWithCameraPosition()
    {
        var inventory = new GameObject("Inventory").AddComponent<Inventory>();
        var mainCamera = new GameObject("MainCamera").AddComponent<Camera>();
        mainCamera.transform.position = new Vector3(0f, 0f, 0f);

        inventory.Start();
        mainCamera.transform.position = new Vector3(10f, 10f, 10f);
        inventory.LateUpdate();

        // Check values
        Assert.AreEqual(new Vector3(10f, 10f, 10f) + inventory.offset, inventory.transform.position);
    }
}
*/