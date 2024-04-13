/*
Name: Zoe Abbott
Role: Team Lead 2: Software Architect 
Project: Midnight Slice Madness

This class observes and receives data from the QuestManager
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestObserver : Observer
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ObserverUpdate(Quest quest)
    {
        GameObject.Find("Observer").GetComponent<Observer>().ObserverUpdate(quest);
    }

}
