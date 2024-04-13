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
    public GameObject observer;     //Observer being notified of quest updates

    private TMP_Text questMessage;  //Message the quest will display on the HUD
    private GameObject destination; //This destination will be set to location for path 1. 
    private string questName;       
    private int questProgress;      //Progress on quest from 0: Intro, 1: In Progress, 2: Complete
    
    //FindDestination sets the game object observer to the observer in the scene.
    void FindDestination()
    {
        observer = GameObject.Find("Observer");
    }
    /*
     * Notify the Observer of changes happening in this quest class.
     */
    void NotifyObserver(TMP_Text text, GameObject dest, string qName, int qProgress)
    {
        observer.GetComponent<Observer>().RecieveQuest(text, dest, qName, qProgress);
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
                questProgress += 1;
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
    protected override void SetQuestAttributes()
    {
        FindDestination();
        questMessage.text = "Pick up a pizza to deliver.";
        destination = GameObject.Find("OutPizza");
        questName = "Quest 1";
        questProgress = 0;
        NotifyObserver(questMessage, destination, questName, questProgress);
    }
    /*
    * SetQuestProgressComplete() is run when quest progress is set to 2 or above,
    * or below 0. This method will set quest message to quest completion and notify observer.
    */
    protected new void SetQuestProgress1()
    {
        questMessage.text = "Deliver the pizza to {insertlocation1}";
        destination = GameObject.Find("BlueHouse");
        NotifyObserver(questMessage, destination, questName, questProgress);
    }

    /*
    * Virtual function SetQuestAttributes will allow me to display the usage
    * of the Virtual and Override types and how they impact the code. 
    * This function will also notify observer.
    */
    protected new void SetQuestProgressComplete()
    {
        questMessage.text = "Quest Complete!";
        NotifyObserver(questMessage, destination, questName, questProgress);
    }


    



}
