/*
Name: Dylan Thompson
Role: Team Lead 5 -- AI Specialist
Project: Midnight Slice Madness
This file contains the definition for the Main/Game over menu
It inherits from MonoBehaviour
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private VideoPlayer demoVideo; //Attached through inspector
    [SerializeField] private float demoTriggerTime = 10f;
    private float inactivityTimer = 0f;
    private Vector3 lastMousePosition;

    protected virtual void Start()
    {
        inactivityTimer = 0f;
        demoVideo.Stop();

        //demoVideo.prepareCompleted += (source) => {
        //    demoVideo.Play();
        //};
    }

    private void Update()
    {
        //if (Input.anyKey || MouseMoved())
        if (Input.anyKey) // Reset timer if any key is pressed
        {
            Debug.Log($"Detecting input");
            inactivityTimer = 0f;
            demoVideo.Stop();
        }
        else
        {
            inactivityTimer += Time.deltaTime;
            //Debug.Log($"Tiner running");
            //Debug.Log($"Inactivity: {inactivityTimer}, Time.deltaTime {Time.deltaTime}");
            if (inactivityTimer >= demoTriggerTime && !demoVideo.isPlaying)
            {
                Debug.Log($"Attempting to play video");
                demoVideo.Play();
            }
        }
    }

    public void LoadMainGame()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene("TutorialLevel");
    }

    public void QuitGame()
    {
        Debug.Log("Quit game request");
        Application.Quit();

        //#if UNITY_EDITOR
        //        UnityEditor.EditorApplication.isPlaying = false;
        //#endif
    }

    private bool MouseMoved()
    {
        return Input.mousePosition != lastMousePosition;
    }
}