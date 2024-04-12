/*
Name: Zoe Abbott
Role: Team Lead 2: Software Architect 
Project: Midnight Slice Madness

This class inherits from Quest, as it 
is the class for the first quest on the 
main level.
It will also notify it's observer when it functions
*/

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using PlasticPipe.PlasticProtocol.Messages;
using TMPro;
using UnityEngine;

public class MainQuest1 : Quest
{
    private TMP_Text questMessage;
    private GameObject destination; //This destination will be set to location for path 1. 
    private string questName;
    private int questProgress;

    //questMessage.text = "Deliver the pizza to the location.";
    void notifyObserver()
    {
        //insert observer notification here.
        //want to give observer destination/status of quest.
        //observer will give destination and status to HUD which are on the notif list. 
    }
    void ChangeQuestProgress()
    {
        switch(questProgress)
        {
            case 0:
                questProgress += 1;
                SetQuestProgress1();
                break;
            case 1:
                questProgress += 1;
                SetQuestProgressComplete();
                break;
            case 2:
                break;
        }
    }

    protected override void SetQuestAttributes()
    {
        questMessage.text = "Pick up a pizza to deliver.";
        destination = GameObject.Find("OutPizza");
        questName = "Quest 1";
        questProgress = 0;
        notifyObserver();
    }

    protected new void SetQuestProgress1()
    {
        questMessage.text = "Deliver the pizza to {insertlocation1}";
        destination = GameObject.Find("BlueHouse");
        notifyObserver();
    }

    protected new void SetQuestProgressComplete()
    {
        questMessage.text = "Quest Complete!";
        notifyObserver();
    }


    



}
