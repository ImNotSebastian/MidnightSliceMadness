/*
Name: Aiden Shepard
Role: Team Lead 3 -- QA Manager
Project: Midnight Slice Madness

This file sets camera's y position to player's y position while in tutorial level bounds
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform playerBicycle;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerBicycle.position.x, playerBicycle.position.y, -10);
    }
}
