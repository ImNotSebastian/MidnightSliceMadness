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
    // Start is called before the first frame update

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
    }

    // Update is called once per frame
    void Update()
    {
        QuestRecieve(currentQuest);
        QuestGlorietta();
        currentQuest.CheckPlayerPizza();
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

