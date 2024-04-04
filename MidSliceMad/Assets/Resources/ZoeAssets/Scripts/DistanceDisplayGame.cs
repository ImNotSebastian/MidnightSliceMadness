using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DistanceDisplayGame : MonoBehaviour
{
    public TMP_Text distanceDisplayGame;

    [SerializeField]
    private int distance;
    [SerializeField]
    private int limit;
    private int dist; //distance calculation distance
    private GameObject player;
    private GameObject destination;

    Vector2 a = new Vector2(0,0);
    Vector2 b = new Vector2(0,0);

    // Start is called before the first frame update
    void Start()
    {
        distance = Convert.ToInt32(distanceCalculation());
        player = GameObject.Find("PlayerBicycle");
        destination = GameObject.Find("BlueHouse");
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
}
