/*
Name: Dylan Thompson
Role: Team Lead 5 -- AI Specialist
Project: Midnight Slice Madness
This file contains the definition for Dr. BC Mode
It allows Dr. BC Mode to be turned on and off
It inherits from MonoBehaviour
*/

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DRBCMode : MonoBehaviour
{
    // Reference to the TextMeshPro component
    [SerializeField]  private TextMeshProUGUI buttonText;
    private string textOne = "Dr. BC Mode: Off";
    private string textTwo = "Dr. BC Mode: On";
    private bool toggle = false;

    // Function to toggle the text
    public void ToggleDRBCMode()
    {
        if (toggle)
        {
            buttonText.text = textOne; // Set the text to Text 1
        }
        else
        {
            buttonText.text = textTwo; // Set the text to Text 2
        }
        toggle = !toggle; // Switch the toggle state
    }
}
