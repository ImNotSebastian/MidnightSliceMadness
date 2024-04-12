using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Quest 
{
    private TMP_Text questMessage;
    private GameObject destination;
    private string questName = "QUESTNAME";
    private int questProgress;
    void notifyObserver()
    {
        //insert observer notification here.
        //want to give observer destination/status of quest.
        //observer will give destination and status to HUD which are on the notif list. 
    }


}
