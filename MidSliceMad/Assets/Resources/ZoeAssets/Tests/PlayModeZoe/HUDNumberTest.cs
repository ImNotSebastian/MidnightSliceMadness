using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using TMPro;

public class HUDNumberTest
{
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator HUDNumberTestWithEnumeratorPasses()
    {
        GameObject GM = GameObject.Find("GameManager");
        //GM.GetComponent<DistanceDisplay>().distance += 1;
        // Use yield to skip a frame.
        yield return null;
    }
}
