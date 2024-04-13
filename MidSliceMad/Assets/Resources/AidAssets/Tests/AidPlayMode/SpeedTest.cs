/*
Name: Aiden Shepard
Role: Team Lead 3 -- QA Manager
Project: Midnight Slice Madness

This file is composed of the play mode test 
to see if the the player is able to exceed the max speed
*/

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SpeedTest
{
    GameObject playerObject;
    Rigidbody2D rigidbody;

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator MaxSpeedTest()
    {
        playerObject = new GameObject();
        rigidbody = playerObject.AddComponent<Rigidbody2D>();
        playerObject.AddComponent<VehicleController>();

        yield return null;
        VehicleController script = playerObject.GetComponent<VehicleController>();

        float speed = rigidbody.velocity.magnitude;

        float minValue = 0f;
        float maxValue = script.GetMaxSpeed();

        Assert.GreaterOrEqual(speed, minValue);
        Assert.LessOrEqual(speed, maxValue);
    }
}
