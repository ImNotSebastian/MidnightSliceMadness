using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public string getName() 
    {
        return name;
    }


    //getters
    public int getAffinity()
    {
        return affinity;
    }
    public void setName(string newName)
    {
        name = newName;
    }
    //SETTERS
    public void setAffinity(int x)
    {
        affinity = x;
    }


    public void setPos(int x, int y)
    {
        posX = x;
        posY = y;
    }

}
