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
    private string modeOff = "Dr. BC Mode: Off";
    private string modeOn = "Dr. BC Mode: On";
    private static bool toggle = false;
    private MonsterFactory monsterFactory;

    protected void Start()
    {
        monsterFactory = FindObjectOfType<MonsterFactory>();
        if (toggle == true)
        {
            buttonText.text = modeOn;
        }
    }

    // Function to toggle the text
    public void ToggleDRBCMode()
    {
        if (toggle)
        {
            buttonText.text = modeOff; // Set the text to Dr. BC Mode: Off
            monsterFactory.ToggleSpawning(true);
        }
        else
        {
            buttonText.text = modeOn; // Set the text to Dr. BC Mode: On
            monsterFactory.ToggleSpawning(false);
        }
        toggle = !toggle; // Switch the toggle state
    }
}
