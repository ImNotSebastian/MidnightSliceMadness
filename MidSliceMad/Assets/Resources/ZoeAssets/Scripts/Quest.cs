/*
Name: Zoe Abbott
Role: Team Lead 2: Software Architect 
Project: Midnight Slice Madness

The class Quest, which is the parent class 
of all Quest objects, MainQuest# and TutorialQuest
*/

using System.Collections;
using System.Collections.Generic;
using Codice.CM.Common;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Quest 
{
    //questMessage is a TMP_Text which can impact TMP textboxes using .text
    private TMP_Text questMessage;              
    
    private GameObject destination;             //destination will be a GameObject like OutPizza and BlueHouse.
    private string questName = "QUESTNAME";     //questName can be used to identify the quest the player is currently on.
    
    //questProgress will be used to track the quest's progress between 0: Intro, 1: In Progress, 2: Complete
    private int questProgress;                  
    void notifyObserver(TMP_Text Text, GameObject Dest, string QName, int QProgress)
    {

    }

    /*
     * The function ChangeQuestProgress will run the change process between 
     * quest states using questProgress at 0,1,2.
     */
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
    /*
     * SetQuestProgress1() class method will be run when quest progress moves from
     * the introduction of the quest to the delivery part of the quest.
     * It will also notify observer
     */
    protected void SetQuestProgress1()
    {
        questMessage.text = "Deliver the pizza to {insertlocation}";
        //destination = GameObject.Find("NextLocation");
        notifyObserver(questMessage, destination, questName, questProgress);
    }
    /*
    * SetQuestProgressComplete() is run when quest progress is set to 2 or above,
    * or below 0. This method will set quest message to quest completion and notify observer.
    */
    protected void SetQuestProgressComplete()
    {
        questMessage.text = "Quest Complete!";
        notifyObserver(questMessage, destination, questName, questProgress);
    }

    /*
     * Virtual function SetQuestAttributes will allow me to display the usage
     * of the Virtual and Override types and how they impact the code. 
     * This function will also notify observer.
     */
    protected virtual void SetQuestAttributes()
    {
        questMessage.text = "GET THAT PIZZA SIS!!! YAAASSSS!!!";
        destination = GameObject.Find("OutPizza");
        questName = "QUEST???";
        questProgress = 0;
        notifyObserver(questMessage, destination, questName, questProgress);
    }


    

}
