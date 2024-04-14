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
using UnityEngine.Apple;

public class Quest 
{
    public GameObject observer;  
    //questMessage is a TMP_Text which can impact TMP textboxes using .text
    protected TMP_Text questMessage;              
    public TMP_Text QuestMessage
    {
        get { return questMessage;}
    }   
    //destination will be a GameObject like OutPizza and BlueHouse.
    protected GameObject destination;             
    public GameObject Destination
    {
        get {return destination;}
    }
    //questName can be used to identify the quest the player is currently on.
    protected string questName = "QUESTNAME";
    public string QuestName         
    {
        get {return questName;}
    }
    //questProgress will be used to track the quest's progress between 0: Intro, 1: In Progress, 2: Complete
    protected int questProgress; 
    public int QuestProgress
    {
        get {return questProgress;}
    } 

        void FindDestination()
    {
        observer = GameObject.Find("Observer");
    }


    public void NotifyManager(Quest quest)
    {
        GameObject.Find("QuestManager").GetComponent<QuestManager>().QuestRecieve(quest);
    }
    
    /*
     * The function ChangeQuestProgress will run the change process between 
     * quest states using questProgress at 0,1,2.
     */ 
    public virtual void ChangeQuestProgress()
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
    /* Virtual function SetQuestAttributes will allow me to display the usage
    * of the Virtual and Override types and how they impact the code. 
    * This function will also notify observer.
    */
    public virtual void SetQuestAttributes()
    {
        FindDestination();
        questMessage.text = "Pick up a pizza to deliver.";
        destination = GameObject.Find("OutPizza");
        questName = "MainQuest1";
        questProgress = 0;
        NotifyManager(this);
    }
     /*
    * SetQuestProgress1() class method will be run when quest progress moves from
    * the introduction of the quest to the delivery part of the quest.
    * It will also notify observer
    */
    public virtual void SetQuestProgress1()
    {
        questMessage.text = "You're running the wrong quest.";
        destination = GameObject.Find("BlueHouse");
        NotifyManager(this);
    }
    /*
    * SetQuestProgressComplete() is run when quest progress is set to 2 or above,
    * or below 0. This method will set quest message to quest completion and notify observer.
    */
    public virtual void SetQuestProgressComplete()
    {
        destination = GameObject.Find("Outpizza");
        questMessage.text = "Quest Complete!";
        NotifyManager(this);
    } 
    public bool CheckPlayerPizza()
    {
        return GameObject.Find("PlayerBicycle").GetComponent<Player>().GetPlayerHasPizza();
    }


}
