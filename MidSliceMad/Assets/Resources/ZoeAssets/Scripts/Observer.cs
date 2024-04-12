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

public class Observer 
{
    //will get this information from quest and give to HUD elements quest/destination.

    //Data section: The information passed through by the quest's notification.
    private TMP_Text questIntro;
    private GameObject destination;
    private string questName;
    private int questProgress;
    //Data Section Over.

    //Most observers would notify all subscribed subjects,
    //mine will notify as if it were two different observers

    //Observe HUD functions
    void NotifyHUD ()
    {

    }

    //Observe quest functions
    void NotifyQuest()
    {

    }

}
