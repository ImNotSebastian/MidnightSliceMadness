using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using TMPro;
using UnityEngine;

public class MainQuest1 : Quest
{
    private TMP_Text questMessage;
    private GameObject destination; //This destination will be set to location for path 1. 
    private string questName = "FDelivery 1!";
    private int questProgress;

    questMessage.text = "Deliver the pizza to the location.";
    void notifyObserver()
    {
        //insert observer notification here.
        //want to give observer destination/status of quest.
        //observer will give destination and status to HUD which are on the notif list. 
    }



}
