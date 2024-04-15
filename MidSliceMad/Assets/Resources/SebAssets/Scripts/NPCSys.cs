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

    private int affinity;

    //constructors
    public NPCSys()
    {
        name = "Default";
        affinity = 0;
    }


    public NPCSys(string newName,int x, int xCoord, int yCoord)
    {
        name = newName;
        posX = xCoord;
        posY = yCoord;
        affinity = x;
    }


    //getters
    public int getAffinity()
    {
        return affinity;
    }
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
     public void setAffinity(int x)
    {
       affinity = x;
    }

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
        if(affinity > 0)
        {
            Debug.Log("NPCSys: Nice interaction with NPC.");
        }
        else
        {
             Debug.Log("NPCSys: Normal interaction with NPC.");
        }
    }

}

public class RomanceNPCSys : NPCSys
{
  

   

  

    // Override the Interact method from the base class
    public override void Interact()
    {
        //need to call start dialogue from here based on which npc it is, and the affinity score
        if(getAffinity() > 0)
        {
            Debug.Log("RomanceNPCSys: Romantic interaction with NPC.");
        }
        else
        {
             Debug.Log("NPCSys: Normal interaction with NPC.");
        }
    }
}