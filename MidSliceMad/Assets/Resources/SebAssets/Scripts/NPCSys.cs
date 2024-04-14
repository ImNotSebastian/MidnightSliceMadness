using System.Collections;
using System.Collections.Generic;
using UnityEngine;




/*****************************************************************************
 *NPCSys: Holds the data about each NPC
 * 
 *  
 *  
 *
 *  
 *
 *****************************************************************************/
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

