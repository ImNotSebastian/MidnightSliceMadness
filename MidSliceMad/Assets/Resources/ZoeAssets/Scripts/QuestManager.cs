using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    [SerializeField]
    public Quest TutorialQuest;
    public Quest MainQuest1 = new MainQuest1();
    public Quest MainQuest2;
    public Quest MainQuest3;
    public Quest MainQuest4;

    public Quest currentQuest;
    // Start is called before the first frame update

    public void QuestRecieve(Quest quest)
    {
        currentQuest = quest;
        GameObject.Find("Observer").GetComponent<QuestObserver>().ObserverUpdate(currentQuest);

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentQuest = MainQuest1;
        currentQuest.SetQuestAttributes();
        QuestRecieve(currentQuest);
    }

    void notifyObserver()
    {

    }



}

