/*
Name: Aiden Shepard
Role: Team Lead 3 -- QA Manager
Project: Midnight Slice Madness

This file changes the player's color based on which direction it is facing
In the future it will change sprites to give the illusion of semi 3D
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    // Reference to the renderer component
    private Renderer shapeRenderer;

    // Awake is called when the script is being loaded
    void Awake()
    {
        // Get the Renderer component attached to the GameObject
        shapeRenderer = GetComponent<Renderer>();
    }

    // Function to change the color of the shape
    public void ChangeColor(Color newColor)
    {
        // Change the color of the material
        shapeRenderer.material.color = newColor;
    }
}
