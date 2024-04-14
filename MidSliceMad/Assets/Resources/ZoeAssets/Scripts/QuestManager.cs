/*
Name: Zoe Abbott
Role: Team Lead 2: Software Architect 
Project: Midnight Slice Madness

The Quest Manager will manage quest status and which quest
is the currently active quest.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public Quest TutorialQuest;
    public Quest MainQuest1 = new MainQuest1();
    public Quest MainQuest2 = new MainQuest2();
    public Quest MainQuest3 = new MainQuest3();
    public Quest MainQuest4 = new MainQuest4();
    public Quest currentQuest;

    private bool questProgress;

    //QuestRecieve will receieve current quest data and pass it along to the Quest Observer
    public void QuestRecieve(Quest quest)
    {
        GameObject.Find("Observer").GetComponent<QuestObserver>().ObserverUpdate(currentQuest);

    }
    void Start()
    {
        currentQuest = MainQuest1;
        currentQuest.SetQuestAttributes();
        questProgress = currentQuest.CheckPlayerPizza();
    }
    // Update is called once per frame
    void Update()
    {
        if(currentQuest == null)
        {
            //Debug.LogError("No Active Quest.");
        }
        QuestRecieve(currentQuest);
        if (questProgress != currentQuest.CheckPlayerPizza())
        {
            //Debug.LogError("CheckPlayerPizza quest: " + currentQuest.QuestName);
            questProgress = currentQuest.CheckPlayerPizza();
            currentQuest.ChangeQuestProgress();
        }
    }
    //Quest selector
    public void QuestSelector(int quest)
    {
        Debug.Log("Quest Selector Started.");
        switch (quest)
        {
            case 0:
                currentQuest = TutorialQuest;
                currentQuest.SetQuestAttributes();                
                Debug.Log("Tutorial Quest Start.");
                break;
            case 1:
                currentQuest = MainQuest1;
                currentQuest.SetQuestAttributes();                
                Debug.Log("Main Quest 1 Start. dest: " + currentQuest.Destination.name);
                break;
            case 2:
                currentQuest = MainQuest2;
                currentQuest.SetQuestAttributes();                
                Debug.Log("Main Quest 2 Start. dest: " + currentQuest.Destination.name);
                break;
            case 3:
                currentQuest = MainQuest3;
                currentQuest.SetQuestAttributes();                
                Debug.Log("Main Quest 3 Start.");
                break;
            case 4:
                currentQuest = MainQuest4;
                currentQuest.SetQuestAttributes();                
                Debug.Log("Main Quest 4 Start.");
                break;
            default:
                currentQuest.SetQuestAttributes();
                Debug.LogError("Quest Number Not Found");
                break;
        }
    }
}

