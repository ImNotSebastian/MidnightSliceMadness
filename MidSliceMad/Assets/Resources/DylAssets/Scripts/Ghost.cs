/*
Name: Dylan Thompson
Role: Team Lead 5 -- AI Specialist
Project: Midnight Slice Madness
This file contains the definition for the Ghost Class
This class provides the design for the ghost object
It inherits from MonoBehaviour and Monster
This class is part of a Factory pattern
*/

using Codice.CM.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Monster
{
    private bool isIncapacitated = false;
    
    // Update is called once per frame
    protected override void Update()
    {
        PursuePlayer();
    }

    protected override IEnumerable Incapacitate()
    {
        if (!isIncapacitated)
        {
            isIncapacitated = true;
            speed = 0f;
            yield return new WaitForSeconds(incapacitateDuration);
            speed = 3f;
            isIncapacitated = false;
        }
    }
}
