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
    public Quest MainQuest2;
    public Quest MainQuest3;
    public Quest MainQuest4;
    public Quest currentQuest;

    private bool questProgress;

    //QuestRecieve will receieve current quest data and pass it along to the Quest Observer
    public void QuestRecieve(Quest quest)
    {
        currentQuest = quest;
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
        QuestRecieve(currentQuest);
        QuestGlorietta();
        if (questProgress != currentQuest.CheckPlayerPizza())
        {
            questProgress = currentQuest.CheckPlayerPizza();
            currentQuest.ChangeQuestProgress();
        }
    }
    //A quest glorietta created to start the next quest when one ends
    void QuestGlorietta()
    {
        switch (currentQuest.QuestName)
        {
            case "TutorialQuest":
                currentQuest = MainQuest1;
                break;
            case "MainQuest1":
                currentQuest = MainQuest2;
                break;
            case "MainQuest2":
                currentQuest = MainQuest3;
                break;
            case "MainQuest3":
                currentQuest = MainQuest4;
                break;
            case "MainQuest4":
                break;
            default:
                Debug.LogError("Quest Name Not Found");
                break;
        }
    }
    //Quest selector for debugging.
    void QuestSelector(int quest)
    {
        switch (quest)
        {
            case 0:
                currentQuest = TutorialQuest;
                break;
            case 1:
                currentQuest = MainQuest1;
                break;
            case 2:
                currentQuest = MainQuest2;
                break;
            case 3:
                currentQuest = MainQuest3;
                break;
            case 4:
                currentQuest = MainQuest3;
                break;
            default:
                Debug.LogError("Quest Number Not Found");
                break;
        }
    }



}

