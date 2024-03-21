using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DistanceDisplay : MonoBehaviour
{
    public TMP_Text distanceDisplay;
    public int distance;
    public int limit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceDisplay.text = distance.ToString() + " - Distance to Location";
        crunkDistance();
    }

    void crunkDistance()
    {
        while (distance <= 999999)
        {
            distance += 3333;

        }
    }
}
