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

public class MainQuest2 : Quest
{
    //FindObserver sets the game object observer to the observer in the scene.
    void FindObserver()
    {
        observer = GameObject.Find("Observer");
    }
    /*
     * Notify the QuestManager of changes happening in this quest class.
     */
    public void NotifyManager(Quest quest)
    {
        GameObject.Find("QuestManager").GetComponent<QuestManager>().QuestRecieve(quest);
    }
    /*
    * The function ChangeQuestProgress will run the change process between 
    * quest states using questProgress at 0,1,2.
    */
    public override void ChangeQuestProgress()
    {
        UnityEngine.Debug.LogError("Access ChangeQuestProgress");
        switch(questProgress)
        {
            case 0:
                UnityEngine.Debug.LogError("quest progressing 0");
                questProgress += 1;
                SetQuestProgress1();
                break;
            case 1:
                UnityEngine.Debug.LogError("quest progressing 1");
                questProgress += 1;
                SetQuestProgressComplete();
                break;
            default:
                UnityEngine.Debug.LogError("quest progress default");
                break;
        }
    }
    /*
    * SetQuestAttributes() will run at the beginning of a quest to
    * initialize the quest variables.
    */
    public override void SetQuestAttributes()
    {
        UnityEngine.Debug.LogError("Setting Quest Attributes 2");
        FindObserver();
        questMessage = GameObject.Find("QuestManager").GetComponent<DistanceDisplayGame>().questDisplayGame;
        questMessage.text = "Quest:<br>Pick up a pizza to deliver.";
        destination = GameObject.Find("OutPizza");
        //UnityEngine.Debug.LogError(destination.name); //outputting correct destination.
        questName = "MainQuest2";
        questProgress = 0;
        NotifyManager(this);
    }
    /*
    * SetQuestProgress1() class method will be run when quest progress moves from
    * the introduction of the quest to the delivery part of the quest.
    * It will also notify observer
    */
    public override void SetQuestProgress1()
    {
        UnityEngine.Debug.LogError("SetQuestProgressQuest2" + destination.name);
        questMessage.text = "Quest:<br>Deliver the pizza to the VeryMuchNotAlien's Home";
        destination = GameObject.Find("WooshMachine");
        UnityEngine.Debug.LogError("SetQuestProgressQuest2" + destination.name);
        NotifyManager(this);
    }
    /*
    * SetQuestProgressComplete() is run when quest progress is set to 2 or above,
    * or below 0. This method will set quest message to quest completion and notify observer.
    */
    public override void SetQuestProgressComplete()
    {
        UnityEngine.Debug.LogError("End Quest 2");
        questMessage.text = "Quest Complete!";
        GameObject.Find("QuestManager").GetComponent<QuestManager>().QuestSelector(2);
        NotifyManager(this);
    }
}
