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

public class Observer : MonoBehaviour
{
    //will get this information from quest and give to HUD elements quest/destination.

    //Data section: The information passed through by the quest's notification.
    private TMP_Text questMessage;
    private GameObject destination;
    private string questName;
    private int questProgress;
    //Data Section Over.

    //Most observers would notify all subscribed subjects,
    //mine will notify as if it were two different observers

    //Observe HUD functions
    public void NotifyHUD (TMP_Text text, GameObject dest, string qName, int qProgress)
    {

    }

    //Observe quest functions
    public void NotifyQuest(TMP_Text text, GameObject dest, string qName, int qProgress)
    {

    }

    public void RecieveHUD(TMP_Text text, GameObject dest, string qName, int qProgress)
    {
        setVariables(text, dest, qName, qProgress);
        NotifyQuest(text, dest, qName, qProgress);
    }

    public void RecieveQuest(TMP_Text text, GameObject dest, string qName, int qProgress)
    {
        setVariables(text, dest, qName, qProgress);
        NotifyHUD(text, dest, qName, qProgress);
    }

    private void setVariables(TMP_Text text, GameObject dest, string qName, int qProgress)
    {
        questMessage = text;
        destination = dest;
        questName = qName;
        questProgress = qProgress;
    }

}
