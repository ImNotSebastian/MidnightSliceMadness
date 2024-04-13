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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecieveData(Quest quest)
    {
        GameObject.Find("QuestManager").GetComponent<DistanceDisplayGame>().HUDRecieve(quest);
    }
}
