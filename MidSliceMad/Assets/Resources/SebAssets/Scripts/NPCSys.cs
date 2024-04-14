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
    private int affinity;

    private int posX = 0;
    private int posY = 0;

    //constructors
    public NPCSys()
    {
        name = "Default";
        affinity = 0;
    }


    public NPCSys(string newName, int x, int xCoord, int yCoord)
    {
        name = newName;
        affinity = x;
        posX = xCoord;
        posY = yCoord;
    }


    //getters
    public int getAffinity()
    {
        return affinity;
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

}

