/*
Name: Zoe Abbott
Role: Team Lead 2: Software Architect 
Project: Midnight Slice Madness

{description}
*/

using System.Collections;
using System.Collections.Generic;
using Codice.CM.Common;
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

    void ChangeQuestProgress()
    {
        switch(questProgress)
        {
            case 0:
                questProgress += 1;
                SetQuestProgress1();
                break;
            case 1:
                questProgress += 2;
                SetQuestProgressComplete();
                break;
            case 2:
                break;
        }
    }
    protected void SetQuestProgress1()
    {
        questMessage.text = "Deliver the pizza to {insertlocation}";
        //destination = GameObject.Find("NextLocation");
        notifyObserver();
    }

    protected void SetQuestProgressComplete()
    {
        questMessage.text = "Quest Complete!";
        notifyObserver();
    }

        protected virtual void SetQuestAttributes()
    {
        questMessage.text = "GET THAT PIZZA SIS!!! YAAASSSS!!!";
        destination = GameObject.Find("OutPizza");
        questName = "QUEST???";
        questProgress = 0;
        notifyObserver();
    }


    

}
