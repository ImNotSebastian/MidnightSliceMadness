using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCameraMovement : MonoBehaviour
{
    [SerializeField] Transform playerBicycle;

    // Update is called once per frame
    void Update()
    {
        if (playerBicycle.transform.position.y > 0 && playerBicycle.transform.position.y < 22)
        {
            transform.position = new Vector3(0, playerBicycle.position.y, -10);
        }
    }
}
