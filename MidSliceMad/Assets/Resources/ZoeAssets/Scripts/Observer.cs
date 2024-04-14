/*
Name: Zoe Abbott
Role: Team Lead 2: Software Architect 
Project: Midnight Slice Madness

The Observer. This is using the observer pattern
to notify the HUD and QuestManager to allow 
HUD to update to the current quest information.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.PlayerLoop;

public class Observer : MonoBehaviour
{

    public void ObserverUpdate(Quest quest) 
    {
        Debug.Log("ObserverObserverUpdate");
        GameObject.Find("Observer").GetComponent<HUDObserver>().RecieveData(quest);
    }
}
