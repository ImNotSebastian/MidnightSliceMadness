using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Name:Sebastian Fedane
Role: Team Lead 1 -- IT Manager
Project: Midnight Slice Madness
This file contains the definition for the NPC data class
This class contains the private class data of the npcs, 
This class is a private class data pattern class
*/

public class NPCSys
{
    private string name;


    private int posX = 0;
    private int posY = 0;

    //constructors
    public NPCSys()
    {
        name = "Default";
    }


    public NPCSys(string newName, int xCoord, int yCoord)
    {
        name = newName;
        posX = xCoord;
        posY = yCoord;
    }


    //getters
    public string getName()
    {
        return name;
    }


    public int getPosX()
    {
        return posX;
    }
    public int getPosY()
    {
        return posY;
    }

    //setters
    public void setPos(int x, int y)
    {
        posX = x;
        posY = y;
    }

    public void setName(string newName)
    {
        name = newName;
    }

    // Virtual method for interaction
    public virtual void Interact()
    {
        //need to call start dialogue from here based on which npc it is
        //Debug.Log("NPCSys: Basic interaction with NPC.");
    }

}

public class RomanceNPCSys : NPCSys
{
    private int affinity;

    //constructors
    public RomanceNPCSys()
    {
        name = "Default";
        affinity = 0;
    }

    public void setAffinity(int x)
    {
        affinty = x;
    }
    public int getAffinity()
    {
        return affinty;
    }

    // Override the Interact method from the base class
    public override void Interact()
    {
        //need to call start dialogue from here based on which npc it is, and the affinity score
        //Debug.Log("RomanceNPCSys: Romantic interaction with NPC.");
    }
}