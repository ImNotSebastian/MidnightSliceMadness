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
        playerObject.AddComponent<BicycleController>();

        yield return null;
        BicycleController script = playerObject.GetComponent<BicycleController>();

        float speed = rigidbody.velocity.magnitude;

        float minValue = 0f;
        float maxValue = script.GetMaxSpeed();

        Assert.GreaterOrEqual(speed, minValue);
        Assert.LessOrEqual(speed, maxValue);
    }
}
