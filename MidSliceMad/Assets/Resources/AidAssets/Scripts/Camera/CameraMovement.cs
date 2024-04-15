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
    private Transform player;

    // Update is called once per frame
    void Update()
    {
        player = FindObjectOfType<VehicleController>().transform;

        transform.position = new Vector3(player.position.x, player.position.y, -10);
    }
}
