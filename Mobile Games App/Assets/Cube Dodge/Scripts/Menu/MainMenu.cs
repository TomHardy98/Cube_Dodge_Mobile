/// MainMenu.cs
/// Controls the main menu, starting and exiting the game

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;   // Allow for the screen to be rotated on the menu screens
    }

    public void StartGame()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex + 1 );   // Call the next scene Scene(1) (Game scene)
    }

    public void EndGame()
    {
        Application.Quit();   // Close application
    }
}