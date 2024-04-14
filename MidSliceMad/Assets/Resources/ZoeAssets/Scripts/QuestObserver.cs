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
    public override void ObserverUpdate(Quest quest)
    {
        GameObject.Find("Observer").GetComponent<Observer>().ObserverUpdate(quest);
    }

}
