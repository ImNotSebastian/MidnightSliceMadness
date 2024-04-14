/*
Name: Zoe Abbott
Role: Team Lead 2: Software Architect 
Project: Midnight Slice Madness

This observer will be updated and will tell the HUD
that there was an update in the QuestManager
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class HUDObserver : Observer
{
    public void RecieveData(Quest quest)
    {
        GameObject.Find("QuestManager").GetComponent<DistanceDisplayGame>().HUDRecieve(quest);
    }
}
