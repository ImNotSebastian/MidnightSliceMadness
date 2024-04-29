/*
Name: Zoe Abbott, Sebastian Fedane, Andrew Plum, Aiden Shepard
Role: Pair Programming 
Project: Midnight Slice Madness

This is a script for the shop canvas.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    [SerializeField]
    GameObject shop;
    // Start is called before the first frame update
    void Start()
    {

        shop.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowCavnas()
    {

        Time.timeScale = 0f; // Freeze time
        shop.SetActive(true);
    }

    public void HideCanvas()
    {

        shop.SetActive(false);
        Time.timeScale = 1f; // Unfreeze time
    }
}
