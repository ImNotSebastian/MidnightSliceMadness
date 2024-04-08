using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
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
}