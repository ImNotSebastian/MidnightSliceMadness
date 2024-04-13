/*
Name: Andrew Plum
Role: Team Lead 4 -- Project Manager
Project: Midnight Slice Madness
This file contains the definition for the Inventory Class
This class is used to help display what is contained in 
the player's inventory (which should be a pizza)
It inherits from MonoBehaviour
*/

using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Transform mainCameraTransform;
    private Vector3 offset;

    void Start()
    {
        // Find and store a reference to the Main Camera's transform
        mainCameraTransform = Camera.main.transform;

        // Calculate the initial offset between Inventory and Main Camera
        if (mainCameraTransform != null)
        {
            offset = transform.position - mainCameraTransform.position;
        }
    }

    void LateUpdate()
    {
        // Check if the Main Camera's transform is valid
        if (mainCameraTransform != null)
        {
            // Move the Inventory with an offset relative to the Main Camera's position
            transform.position = mainCameraTransform.position + offset;
        }
    }
}
