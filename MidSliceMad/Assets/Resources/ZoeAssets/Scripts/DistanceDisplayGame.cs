/*
Name: Zoe Abbott
Role: Team Lead 2: Software Architect 
Project: Midnight Slice Madness

This script was created to display the calculated distance
from the player to the destination that is set by the quest.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Runtime.CompilerServices;

public class DistanceDisplayGame : MonoBehaviour
{
    public TMP_Text distanceDisplayGame;
    public TMP_Text questDisplayGame;

    [SerializeField]
    private int distance;
    [SerializeField]
    private int limit;
    private int dist; //distance calculation distance
    private int questProgress;
    private string questName;
    private TMP_Text questMessage;
    private GameObject player;
    private GameObject destination;

    Vector2 a = new Vector2(0,0);
    Vector2 b = new Vector2(0,0);

    // Start is called before the first frame update
    void Start()
    {
        distance = Convert.ToInt32(distanceCalculation());
        player = GameObject.Find("PlayerBicycle");
        destination = GameObject.Find("OutPizza");
        if (destination == null)
        {
            Debug.Log("Did not catch GameObject");
        }
    }

    // Update is called once per frame
    void Update()
    {
        a.x = player.transform.position.x;
        a.y = player.transform.position.y;
        b.x = destination.transform.position.x;
        b.y = destination.transform.position.y;
        distance = Convert.ToInt32(distanceCalculation());
        distanceDisplayGame.text = distance.ToString() + " - Distance to Location";
    }

    int distanceCalculation()
    {
        dist = Convert.ToInt32(Vector2.Distance(a, b));
        return dist;
    }

    public void HUDRecieve(Quest quest)
    {
        if (quest == null)
        {
            Debug.LogError("Did not recieve quest.");
        }
        questMessage = quest.QuestMessage;
        destination = quest.Destination;
        questName = quest.QuestName;
        questProgress = quest.QuestProgress;
        if (destination == null)
        {
            Debug.LogError("HUDRecieve: Did not catch GameObject");
        }

    }

    private string progressSetter(int prog)
    {
        string progressName;
        switch(prog)
        {
            case 0:
                progressName = "Quest Introduction";
                return progressName;
            case 1:
                progressName = "Quest In Progress";
                return progressName;
            case 2:
                progressName = "Quest Complete!";
                return progressName;
            default:
                progressName = "No Quest Active";
                return progressName;
                
        }
    }
}
